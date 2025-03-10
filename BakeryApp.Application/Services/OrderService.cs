﻿
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
