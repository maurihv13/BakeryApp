using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class HamburguerBun : Bread
    {
        public HamburguerBun()
            : base(new Preparation("15 min", "0.5 hr", "4 hrs", "180°"), 1.0, "Hamburguer Bun")
        {
            Preparation.AddIngredient("Flour", 100);
            Preparation.AddIngredient("Water", 25);
            Preparation.AddIngredient("Salt", 2);
            Preparation.AddIngredient("Yeast", 4);
            Preparation.AddIngredient("Sugar", 6);
            Preparation.AddIngredient("Egg", 10);
            Preparation.AddIngredient("Milk", 5);
            Preparation.AddIngredient("Butter", 6);
            Preparation.AddIngredient("Sweet potato", 25);
            Preparation.AddIngredient("Sesame seed", 10);
            Preparation.AddIngredient("Gilding", 5);
        }
        protected override void Cook(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void CutDough(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void LetDoughFerment(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void LetDoughRest(int Amount)
        {
            throw new NotImplementedException();
        }

        /*protected override void MixIngredients(int Amount)
        {
            throw new NotImplementedException();
        }*/

        protected override void ShapeDough(int Amount)
        {
            throw new NotImplementedException();
        }

        private void PlaceOnTop(int Amount) 
        {
            throw new NotImplementedException();
        }
    }
}
