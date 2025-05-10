using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Infrastructure.Persistence.Entities
{
    public class PreparationEntity
    {
        public int Id { get; set; }
        public string CookingTime { get; set; }
        public string RestingTime { get; set; }
        public string FermentTime { get; set; }
        public string CookingTemp { get; set; }
        public List<IngredientEntity> Ingredients { get; set; } = [];
    }
}
