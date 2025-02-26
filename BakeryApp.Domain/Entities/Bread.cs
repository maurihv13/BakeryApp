using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public abstract class Bread
    {
        public required Ingredients Ingredients;
        public required Preparation Preparation;
        public Bread() { 
        }

        public abstract void makeBread(int Amount);
        protected abstract void mixIngredients();
        protected abstract void cutDough();
        protected abstract void letDoughRest();
        protected abstract void shapeDough();
        protected abstract void letDoughFerment();
        protected abstract void cook();
    }
}
