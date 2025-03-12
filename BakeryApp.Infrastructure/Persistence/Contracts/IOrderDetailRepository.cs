using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Infrastructure.Persistence.Entities;

namespace BakeryApp.Infrastructure.Persistence.Contracts
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetailEntity>> GetAllAsync();
        Task<OrderDetailEntity> GetByIdAsync(int id);
        Task AddAsync(OrderDetailEntity orderDetail);
        Task UpdateAsync(OrderDetailEntity orderDetail);
        Task DeleteAsync(int id);
    }
}
