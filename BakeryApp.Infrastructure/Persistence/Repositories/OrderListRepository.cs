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
    public class OrderListRepository : IOrderListRepository
    {
        private readonly BakeryDbContext _context;

        public OrderListRepository(BakeryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderListEntity>> GetAllAsync()
        {
            return await _context.OrderLists.ToListAsync();
        }

        public async Task<OrderListEntity> GetByIdAsync(int id)
        {
            return await _context.OrderLists.FindAsync(id);
        }

        public async Task AddAsync(OrderListEntity orderList)
        {
            await _context.OrderLists.AddAsync(orderList);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(OrderListEntity orderList)
        {
            _context.OrderLists.Update(orderList);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderList = await _context.OrderLists.FindAsync(id);
            if (orderList != null)
            {
                _context.OrderLists.Remove(orderList);
                await _context.SaveChangesAsync();
            }
        }
    }
}
