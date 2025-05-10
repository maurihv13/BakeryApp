
using BakeryApp.Domain.Entities;

namespace BakeryApp.Application.Interfaces
{
    public interface IOrderService
    {
        public bool AddOrder(string officeName, OrderList order);
        public List<OrderList> GetOrders(string officeName);
        public void ProcessOrders(string officeName);
        public Task<bool> AddOrderToDbAsync(string officeName, OrderList order);
    }
}
