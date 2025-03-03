using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Application.Interfaces
{
    public interface IOrderService
    {
        public bool AddOrder(string officeName, OrderList order);
        public void ProcessOrders(string officeName);


    }
}
