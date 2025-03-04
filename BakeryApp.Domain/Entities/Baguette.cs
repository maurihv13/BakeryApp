using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class Baguette : Bread
    {
        public Baguette()
            : base(new Preparation("15 min", "0.5 hr", "1 day", "270°"), 2.0, "Baguette")
        {
            Preparation.AddIngredient("Flour", 280);
            Preparation.AddIngredient("Water", 210);
            Preparation.AddIngredient("Salt", 10);
            Preparation.AddIngredient("Yeast", 5);
        }
        /*protected override void MixIngredients(int Amount)
        {
            throw new NotImplementedException();
        }*/

        protected override void CutDough(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void LetDoughRest(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void ShapeDough(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void LetDoughFerment(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void Cook(int Amount)
        {
            throw new NotImplementedException();
        }

        private void FoldDough(int Amount)
        {
            throw new NotImplementedException();
        }
    }
}
