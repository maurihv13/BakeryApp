using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class OrderList
    {
        public string customerName;
        public List<OrderDetail> Details { get; }

        public OrderList(string customerName) 
        { 
            this.customerName = customerName;
            Details = [];
        }

        public void AddOrder(OrderDetail order) 
        {
            Details.Add(order);
        }

        public int OrderAmount() {
            int totalAmount = 0;
            foreach (OrderDetail order in Details) { 
                totalAmount += order.Amount;
            }
            return totalAmount;
        }
    }
}
