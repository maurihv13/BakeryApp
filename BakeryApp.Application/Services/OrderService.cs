
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;
using BakeryApp.Infrastructure.Persistence.Contracts;

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
    }
}
