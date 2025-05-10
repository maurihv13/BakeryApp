
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Application.UseCases
{
    public class AddOrderUseCase
    {
        private readonly IOrderService _orderService;
        private readonly IOfficeService _officeService;

        public AddOrderUseCase(IOrderService orderService, IOfficeService officeService)
        {
            _orderService = orderService;
            _officeService = officeService;
        }

        public string Execute(string officeName, List<(string BreadType, int Quantity)> breadItems, string customer)
        {
            string result = "Order added succesfully";
            var order = MapItemsToOrder(breadItems);
            order.CustomerName = customer;
            _orderService.AddOrderToDbAsync(officeName, order).Wait();
            /*if (_orderService.AddOrder(officeName, order))
            {
                result = "Order added succesfully";
            }
            else 
            {
                result = $"The order can't be added. The remaining capacity is: {_officeService.GetRemainingCapacity(officeName)}";
            }*/
            return result;
        }

        public double GetPrice(List<(string BreadType, int Quantity)> breadItems) 
        {
            var order = MapItemsToOrder(breadItems);
            return order.TotalPrice();
        }

        private OrderList MapItemsToOrder(List<(string BreadType, int Quantity)> breadItems) 
        {
            var order = new OrderList();

            foreach (var item in breadItems)
            {
                Bread? type = item.BreadType switch
                {
                    "Baguette" => new Baguette(),
                    "White Bread" => new WhiteBread(),
                    "Milk Bread" => new MilkBread(),
                    "Hamburguer Bun" => new HamburguerBun(),
                    _ => null,
                };

                if (type != null) order.AddOrder(type, item.Quantity);
            }

            return order;
        }
    }
}
