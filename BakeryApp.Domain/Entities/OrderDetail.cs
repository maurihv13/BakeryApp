using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class OrderDetail
    {
        public Bread Bread { get; }
        public int Amount { get; }

        public OrderDetail(Bread bread, int amount) 
        {
            this.Bread = bread;
            this.Amount = amount;
        }
        public double GetPrice() 
        {
            return Bread.Price * Amount;
        }
    }
}
