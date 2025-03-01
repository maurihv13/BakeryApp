using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class Ingredients
    {
        public int FlourGrams { get; }
        public int WaterGrams { get; }
        public int SaltGrams { get; }
        public int YeastGrams { get; }
        public Ingredients() { }
    }
}
