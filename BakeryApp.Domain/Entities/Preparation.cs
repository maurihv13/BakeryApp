
namespace BakeryApp.Domain.Entities
{
    public class Preparation
    {
        public string CookingTime { get; }
        public string RestingTime { get; }
        public string FermentTime { get; }
        public string CookingTemp { get; }
        public List<Ingredient> Ingredients { get; private set; }

        public Preparation(string cookingTime, string restingTime, string fermentTime, string cookingTemp) 
        {
            CookingTime = cookingTime;
            RestingTime = restingTime;
            FermentTime = fermentTime;
            CookingTemp = cookingTemp;
            Ingredients = [];
        }

        public void AddIngredients(List<Ingredient> ingredients) 
        {
            Ingredients = ingredients;
        }

        public void AddIngredient(string name, int quantity) 
        {
            Ingredients.Add(new Ingredient(name, quantity));
        }
    }
}
