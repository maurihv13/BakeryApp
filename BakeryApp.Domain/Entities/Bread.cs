
using System.Text;

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

        public abstract string MakeBread(int amount);
        protected virtual string MixIngredients(int amount, int ignore = 0) 
        {
            var sb = new StringBuilder();
            sb.Append("Mixing the ");
            for (int i = 0; i < Preparation.Ingredients.Count - ignore; i++)
            {
                var ingredient = Preparation.Ingredients[i];
                sb.Append($"{ingredient.Quantity * amount} {ingredient.Unit} of {ingredient.Name}");
                if (i < Preparation.Ingredients.Count - (1 + ignore)) sb.Append(", ");
                else sb.Append('.');
            }
            return sb.ToString();
        }
        protected virtual string CutDough() {
            return "Cut the dough.";
        }
        protected virtual string LetDoughRest() 
        {
            return $"Let the dough rest {Preparation.RestingTime}.";
        }
        protected virtual string ShapeDough() 
        {
            return "Shape the dough.";
        }
        protected virtual string LetDoughFerment() 
        {
            return $"Let the dough ferment {Preparation.FermentTime}.";
        }
        protected virtual string Cook() 
        {
            return $"Cook for {Preparation.CookingTime} at {Preparation.CookingTemp}.";
        }
    }
}
