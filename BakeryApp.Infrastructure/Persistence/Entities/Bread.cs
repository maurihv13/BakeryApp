using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Infrastructure.Persistence.Entities
{
    public class BreadEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int PreparationId { get; set; }
        public PreparationEntity Preparation { get; set; }
        public List<BakeryOfficeEntity> BakeryOffices { get; set; } = [];
    }
}
