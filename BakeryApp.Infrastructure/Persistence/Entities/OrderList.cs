using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Infrastructure.Persistence.Entities
{
    public class OrderListEntity
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public List<OrderDetailEntity> Orders { get; set; } = [];
    }
}
