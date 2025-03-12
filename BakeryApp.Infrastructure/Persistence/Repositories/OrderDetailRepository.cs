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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly BakeryDbContext _context;

        public OrderDetailRepository(BakeryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderDetailEntity>> GetAllAsync()
        {
            return await _context.OrderDetails.ToListAsync();
        }

        public async Task<OrderDetailEntity> GetByIdAsync(int id)
        {
            return await _context.OrderDetails.FindAsync(id);
        }

        public async Task AddAsync(OrderDetailEntity orderDetail)
        {
            await _context.OrderDetails.AddAsync(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderDetailEntity orderDetail)
        {
            _context.OrderDetails.Update(orderDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetail = await _context.OrderDetails.FindAsync(id);
            if (orderDetail != null)
            {
                _context.OrderDetails.Remove(orderDetail);
                await _context.SaveChangesAsync();
            }
        }
    }
}
