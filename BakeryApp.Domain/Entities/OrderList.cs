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
        public List<OrderDetail> OrdersDetails { get; set; }
    }
}
