using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public abstract class Bread
    {
        private readonly Preparation _preparation;
        public double Price { get; }
        public string Name { get; }

        public Bread(Preparation preparation, double price, string name) 
        {
            _preparation = preparation;
            Price = price;
            Name = name;
        }

        public virtual void MakeBread(int Amount) 
        {
            Console.WriteLine($"Preparing {Amount} breads type {Name}...");
            Console.WriteLine("Preparation completed");
        }
        protected abstract void MixIngredients(int Amount);
        protected abstract void CutDough(int Amount);
        protected abstract void LetDoughRest(int Amount);
        protected abstract void ShapeDough(int Amount);
        protected abstract void LetDoughFerment(int Amount);
        protected abstract void Cook(int Amount);
    }
}
