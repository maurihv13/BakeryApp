using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryApp.Domain.Entities
{
    public class Preparation
    {
        public string Cookingtime { get; }
        public string RestingTime { get; }
        public string FermentTime { get; }
        public string CookingTemp { get; }
        public Preparation() { }
    }
}
