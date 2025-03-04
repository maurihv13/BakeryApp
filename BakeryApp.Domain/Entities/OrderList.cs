using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class OrderList
    {
        public string CustomerName { get; set; }
        public List<OrderDetail> Details { get; }

        public OrderList() 
        {
            Details = [];
        }
        
        public OrderList(string customerName) 
        { 
            CustomerName = customerName;
            Details = [];
        }

        public void AddOrder(OrderDetail order) 
        {
            Details.Add(order);
        }

        public void AddOrder(Bread bread, int amount) 
        {
            Details.Add(new OrderDetail(bread, amount));
        }

        public int OrderAmount() {
            int totalAmount = 0;
            foreach (OrderDetail order in Details) { 
                totalAmount += order.Amount;
            }
            return totalAmount;
        }

        public double TotalPrice() 
        { 
            double totalPrice = 0;
            foreach (OrderDetail order in Details) 
            {
                totalPrice += order.GetPrice(); 
            }
            return totalPrice;
        }
    }
}
