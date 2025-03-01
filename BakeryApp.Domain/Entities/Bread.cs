using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public abstract class Bread
    {
        private readonly Ingredients ingredients;
        private readonly Preparation preparation;
        public double Price { get; }
        public Bread(Ingredients ingredients, Preparation preparation, double Price) 
        {
            this.ingredients = ingredients;
            this.preparation = preparation;
            this.Price = Price;
        }

        public virtual void makeBread(int Amount) 
        {
            Console.WriteLine($"Preparing {Amount} breads...");
            Console.WriteLine("Preparation completed");
        }
        protected abstract void mixIngredients();
        protected abstract void cutDough();
        protected abstract void letDoughRest();
        protected abstract void shapeDough();
        protected abstract void letDoughFerment();
        protected abstract void cook();
    }
}
