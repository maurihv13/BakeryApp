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

        public override void MakeBread(int amount)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Making {amount} {Name} breads...");
            sb.AppendLine(base.MixIngredients(amount));
            if (amount > 1) sb.AppendLine(base.CutDough());
            sb.AppendLine(base.LetDoughFerment());
            sb.AppendLine(base.ShapeDough());
            sb.AppendLine(base.LetDoughRest());
            sb.AppendLine(base.Cook());
            Console.WriteLine(sb.ToString());
        }
    }
}
