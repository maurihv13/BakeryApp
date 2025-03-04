using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class MilkBread : Bread
    {
        public MilkBread()
            : base(new Preparation("15 min", "10 min", "4 hrs", "180°"), 1.5, "Milk Bread")
        {
            Preparation.AddIngredient("Flour", 55);
            Preparation.AddIngredient("Water", 25);
            Preparation.AddIngredient("Salt", 1);
            Preparation.AddIngredient("Yeast", 3);
            Preparation.AddIngredient("Sugar", 6);
            Preparation.AddIngredient("Egg", 10);
            Preparation.AddIngredient("Milk", 20);
            Preparation.AddIngredient("Butter", 10);
            Preparation.AddIngredient("Honey", 2);
            Preparation.AddIngredient("Lemon zest", 1);
            Preparation.AddIngredient("Vanilla essence", 1);
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
    }
}
