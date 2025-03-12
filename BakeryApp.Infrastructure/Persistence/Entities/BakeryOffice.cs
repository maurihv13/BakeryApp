using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Infrastructure.Persistence.Entities
{
    public class BakeryOfficeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int MaxCapacity { get; set; }
        public List<BreadEntity> Menu { get; set; } = [];
        public List<OrderListEntity> Orders { get; set; } = [];
    }
}
