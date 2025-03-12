
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;
using BakeryApp.Infrastructure.Persistence.Contracts;
using BakeryApp.Infrastructure.Persistence.Entities;

namespace BakeryApp.Application.Services
{
    public class OrderService : IOrderService
    {
        private OfficeService _officeService;
        public IOrderListRepository _repository;

        public OrderService(IOrderListRepository repository) 
        {
            //_officeService = new OfficeService();
            _repository = repository;
        }

        public bool AddOrder(string officeName, OrderList order)
        {
            var office = _officeService.GetOfficeByName(officeName);
            return office.AddOrder(order);
        }

        public List<OrderList> GetOrders(string officeName) 
        {
            var office = _officeService.GetOfficeByName(officeName);
            return office.Orders;
        }

        public void ProcessOrders(string officeName)
        {
            var office = _officeService.GetOfficeByName(officeName);
            office.CleanOrders();
        }

        public async Task<bool> AddOrderToDbAsync(string officeName, OrderList order)
        {
            // Pending validation

            var orderEntity = new OrderListEntity
            {
                CustomerName = order.CustomerName,
                Orders = order.Details.Select(d => new OrderDetailEntity
                {
                    Amount = d.Amount,
                    BreadName = d.Bread.Name,
                    BreadId = 0, // TO be deleted
                }).ToList()
            };

            await _repository.AddAsync(orderEntity);
            return true;
        }
    }
}
