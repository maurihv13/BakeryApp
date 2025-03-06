
using System.Text;

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

        public override string MakeBread(int amount)
        {
            if (amount == 0) return "";
            var sb = new StringBuilder();
            sb.AppendLine($"Making {amount} {Name} breads...");
            sb.AppendLine(base.MixIngredients(amount, 2)); // Ignore sesame and gilding
            if (amount > 1) sb.AppendLine(base.CutDough());
            sb.AppendLine(base.LetDoughRest());
            sb.AppendLine(base.ShapeDough());
            sb.AppendLine(base.LetDoughFerment());
            sb.AppendLine(PlaceOnTop());
            sb.AppendLine(base.Cook());
            return sb.ToString();
        }

        private string PlaceOnTop() 
        {
            return "Place on top of the dough the seamed seen and the gilding.";
        }
    }
}
