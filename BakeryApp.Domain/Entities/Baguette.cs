using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class Baguette : Bread
    {
        public Baguette(Ingredients ingredients, Preparation preparation, int Price) : base(ingredients, preparation, Price)
        {
        }

        public override void makeBread(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void cook()
        {
            throw new NotImplementedException();
        }

        protected override void cutDough()
        {
            throw new NotImplementedException();
        }

        protected override void letDoughFerment()
        {
            throw new NotImplementedException();
        }

        protected override void letDoughRest()
        {
            throw new NotImplementedException();
        }

        protected override void mixIngredients()
        {
            throw new NotImplementedException();
        }

        protected override void shapeDough()
        {
            throw new NotImplementedException();
        }

        public void foldDough()
        {
            throw new NotImplementedException();
        }
    }
}
