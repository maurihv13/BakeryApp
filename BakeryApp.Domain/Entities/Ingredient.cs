

namespace BakeryApp.Domain.Entities
{
    public class Ingredient
    {
        public string Name { get; }
        public int Quantity { get; }
        public string Unit { get; }

        public Ingredient(string name, int quantity, string unit = "grams") 
        { 
            Name = name;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
