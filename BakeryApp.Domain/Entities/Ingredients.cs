using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class Ingredients
    {
        public int FlourGrams { get; private set; }
        public int WaterGrams { get; private set; }
        public int SaltGrams { get; private set; }
        public int YeastGrams { get; private set; }
        public Ingredients() { }
    }
}
