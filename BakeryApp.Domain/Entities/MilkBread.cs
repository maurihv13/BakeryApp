
using System.Text;

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

        public override string MakeBread(int amount)
        {
            if (amount == 0) return "";
            var sb = new StringBuilder();
            sb.AppendLine($"Making {amount} {Name} breads...");
            sb.AppendLine(base.MixIngredients(amount));
            if (amount > 1) sb.AppendLine(base.CutDough());
            sb.AppendLine(base.LetDoughRest());
            sb.AppendLine(base.ShapeDough());
            sb.AppendLine(base.LetDoughFerment());
            sb.AppendLine(base.Cook());
            return sb.ToString();
        }
    }
}
