using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public abstract class Bread
    {
        public Preparation Preparation { get; protected set; }
        public double Price { get; }
        public string Name { get; }

        public Bread(Preparation preparation, double price, string name) 
        {
            Preparation = preparation;
            Price = price;
            Name = name;
        }

        public virtual void MakeBread(int amount) 
        {
            Console.WriteLine($"Making {amount} {Name} breads...");
            MixIngredients(amount);
            Console.WriteLine($"{Name} preparation completed...");
        }
        protected virtual void MixIngredients(int amount) 
        {
            Console.Write("Mixing the ");
            foreach (var ingredient in Preparation.Ingredients) 
            {
                Console.Write($"{ingredient.Quantity * amount} {ingredient.Unit} of {ingredient.Name}, ");
            }
            Console.WriteLine();
        }
        protected abstract void CutDough(int amount);
        protected abstract void LetDoughRest(int amount);
        protected abstract void ShapeDough(int amount);
        protected abstract void LetDoughFerment(int amount);
        protected abstract void Cook(int amount);
    }
}
