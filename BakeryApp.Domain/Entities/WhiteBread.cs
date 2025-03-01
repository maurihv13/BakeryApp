using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class WhiteBread : Bread
    {
        public WhiteBread(Preparation preparation, double price) : base(preparation, price, "White Bread")
        {
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

        protected override void MixIngredients(int Amount)
        {
            throw new NotImplementedException();
        }

        protected override void ShapeDough(int Amount)
        {
            throw new NotImplementedException();
        }
    }
}
