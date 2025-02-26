using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class OrderDetail
    {
        public Bread Bread { get; set; }
        public int Amount;
    }
}
