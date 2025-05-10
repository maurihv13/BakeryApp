using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Infrastructure.Persistence.Entities;

namespace BakeryApp.Infrastructure.Persistence.Contracts
{
    public interface IOrderListRepository
    {
        Task<IEnumerable<OrderListEntity>> GetAllAsync();
        Task<OrderListEntity> GetByIdAsync(int id);
        Task AddAsync(OrderListEntity orderList);
        Task UpdateAsync(OrderListEntity orderList);
        Task DeleteAsync(int id);
    }
}
