using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Application.Services;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Application.UseCases
{
    public class AddOrderUseCase
    {
        private readonly OrderService _orderService;

        public AddOrderUseCase(OrderService orderService)
        {
            _orderService = orderService;
        }

        public string Execute(string officeName, List<(string BreadType, int Quantity)> breadItems, string customer)
        {
            string result = "";
            var order = MapItemsToOrder(breadItems);
            order.CustomerName = customer;
            if (_orderService.AddOrder(officeName, order))
            {
                result = "Order added succesfully";
            }
            else 
            {
                result = $"The order can't be added. The remaining capacity is: {_orderService.GetRemainingCapacity(officeName)}";
            }
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
