
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;
using BakeryApp.Infrastructure.Persistence.Contracts;
using BakeryApp.Infrastructure.Persistence.Entities;

namespace BakeryApp.Application.Services
{
    public class OrderService : IOrderService
    {
        public IOrderListRepository _repository;
        public IBakeryOfficeRepository _officeRepository;
        public OfficeService _officeService; // DELETE

        public OrderService(IOrderListRepository repository, IBakeryOfficeRepository officeRepository) 
        {
            _repository = repository;
            _officeRepository = officeRepository;
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

            var officeId = await GetOfficeIdByName(officeName);

            var orderEntity = new OrderListEntity
            {
                CustomerName = order.CustomerName,
                Orders = order.Details.Select(d => new OrderDetailEntity
                {
                    Amount = d.Amount,
                    BreadName = d.Bread.Name,
                    BreadId = 0, // TO be deleted
                }).ToList(),
                BakeryOfficeEntityId = officeId
            };

            await _repository.AddAsync(orderEntity);
            return true;
        }

        private async Task<int> GetOfficeIdByName(string name)
        {
            var officeEntity = await _officeRepository.GetByNameAsync(name);
            if (officeEntity == null)
            {
                throw new InvalidOperationException($"Office with name {name} not found.");
            }
            return officeEntity.Id;
        }
    }
}
