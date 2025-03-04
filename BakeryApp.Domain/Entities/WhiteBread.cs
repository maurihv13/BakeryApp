using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class WhiteBread : Bread
    {
        public WhiteBread()
            : base(new Preparation("30 min", "1 hr", "4 hrs", "180°"), 2.5, "White Bread")
        {
            Preparation.AddIngredient("Flour", 1000);
            Preparation.AddIngredient("Water", 280);
            Preparation.AddIngredient("Salt", 20);
            Preparation.AddIngredient("Yeast", 20);
            Preparation.AddIngredient("Sugar", 80);
            Preparation.AddIngredient("Milk", 60);
            Preparation.AddIngredient("Butter", 100);
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
