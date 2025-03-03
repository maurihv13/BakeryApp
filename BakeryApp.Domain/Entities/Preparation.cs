using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class Preparation
    {
        public string CookingTime { get; }
        public string RestingTime { get; }
        public string FermentTime { get; }
        public string CookingTemp { get; }
        public List<Ingredient> Ingredients { get; }

        public Preparation(string cookingTime, string restingTime, string fermentTime, string cookingTemp) 
        {
            CookingTime = cookingTime;
            RestingTime = restingTime;
            FermentTime = fermentTime;
            CookingTemp = cookingTemp;
            Ingredients = new List<Ingredient>();
        }

        public void AddIngredient(Ingredient ingredient) 
        {
            Ingredients.Add(ingredient);
        }
    }
}
