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
    public class BreadRepository : IBreadRepository
    {
        private readonly BakeryDbContext _context;

        public BreadRepository(BakeryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BreadEntity>> GetBreadsByOfficeNameAsync(string officeName)
        {
            return await _context.BakeryOffices
                .Where(bo => bo.Name == officeName)
                .Join(
                    _context.Set<Dictionary<string, object>>("BakeryOfficeBread"),
                    bo => bo.Id,
                    bob => (int)bob["BakeryOfficesId"],
                    (bo, bob) => (string)bob["MenuName"]
                )
                .Join(
                    _context.Breads,
                    menuName => menuName,
                    b => b.Name,
                    (menuName, b) => b
                )
                .ToListAsync();
        }
    }
}
