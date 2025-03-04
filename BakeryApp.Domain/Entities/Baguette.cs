
using System.Text;

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

        public override string MakeBread(int amount) 
        {
            if (amount == 0) return "";
            var sb = new StringBuilder();
            sb.AppendLine($"Making {amount} {Name} breads...");
            sb.AppendLine(base.MixIngredients(amount));
            sb.AppendLine(base.LetDoughRest());
            sb.AppendLine(FoldDough());
            sb.AppendLine(base.LetDoughRest());
            sb.AppendLine(FoldDough());
            sb.AppendLine(base.LetDoughFerment());
            if (amount > 1) sb.AppendLine(base.CutDough());
            sb.AppendLine(base.ShapeDough());
            sb.AppendLine(base.LetDoughRest());
            sb.AppendLine(base.Cook());

            return sb.ToString();
        }
        
        private string FoldDough()
        {
            return "Fold the dough.";
        }
    }
}
