using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Infrastructure.Persistence.Contracts;
using BakeryApp.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BakeryApp.Infrastructure.Persistence.Repositories
{
    public class BakeryOfficeRepository : IBakeryOfficeRepository
    {
        private readonly BakeryDbContext _context;

        public BakeryOfficeRepository(BakeryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BakeryOfficeEntity>> GetAllAsync()
        {
            return await _context.BakeryOffices.ToListAsync();
        }

        public async Task<BakeryOfficeEntity?> GetByIdAsync(int id)
        {
            return await _context.BakeryOffices.FindAsync(id);
        }

        public async Task<BakeryOfficeEntity?> GetByNameAsync(string name)
        {
            return await _context.BakeryOffices.FirstOrDefaultAsync(bo => bo.Name == name);
        }

        public async Task AddAsync(BakeryOfficeEntity bakeryOffice)
        {
            await _context.BakeryOffices.AddAsync(bakeryOffice);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BakeryOfficeEntity bakeryOffice)
        {
            _context.BakeryOffices.Update(bakeryOffice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bakeryOffice = await _context.BakeryOffices.FindAsync(id);
            if (bakeryOffice != null)
            {
                _context.BakeryOffices.Remove(bakeryOffice);
                await _context.SaveChangesAsync();
            }
        }
    }
}
