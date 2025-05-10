using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Infrastructure.Persistence.Entities
{
    public class OrderDetailEntity
    {
        public int Id { get; set; }
        public int BreadId { get; set; }
        public string BreadName { get; set; }
        public BreadEntity Bread { get; set; }
        public int Amount { get; set; }
    }
}
