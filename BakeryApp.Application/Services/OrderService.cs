using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Application.Services
{
    public class OrderService : IOrderService
    {
        private OfficeService _officeService;

        public OrderService(OfficeService officeService) 
        {
            _officeService = officeService;
        }

        public bool AddOrder(string officeName, OrderList order)
        {
            var office = _officeService.GetOfficeByName(officeName);
            if (office == null)
                throw new ArgumentException($"{officeName} does not exist");

            return office.AddOrder(order);
        }

        public void ProcessOrders(string officeName)
        {
            var office = _officeService.GetOfficeByName(officeName);

            if (office == null)
                throw new ArgumentException($"{officeName} does not exist");

            if (office.Orders.Count == 0) 
            {
                Console.WriteLine("No orders to process.");
                return;
            }

            foreach (var order in office.Orders) 
            {
                foreach (var detail in order.Details) 
                { 
                    Console.WriteLine($"Preparing: {detail.Bread}, amount ordered: {detail.Amount}");
                    var bread = detail.Bread;
                    bread.makeBread(detail.Amount); // Show preparation in console log
                }
            }
            office.CleanOrders(); // Clear processed orders ...
            Console.WriteLine("All orders have been processed");
        }
    }
}
