using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Infrastructure.Repositories
{
    public class FakeBakeryOfficeRepository
    {
        private readonly List<BakeryOffice> _bakeryOffices;

        public FakeBakeryOfficeRepository() 
        {
            _bakeryOffices =
            [
                new BakeryOffice("Main Office", "742 Evergreen Terrace", 150),
                new BakeryOffice("Second Office", "P. Sherman, 42 Wallaby, Sydney", 100)
            ];

            InitializeBreads();
        }

        private void InitializeBreads() 
        {
            var baguette = new Baguette(new Preparation("", "", "", ""), 2.0);
            var whiteBread = new WhiteBread(new Preparation("", "", "", ""), 2.5);
            var milkBread = new MilkBread(new Preparation("", "", "", ""), 1.5);
            var hamburguerBun = new HamburguerBun(new Preparation("", "", "", ""), 1.0);

            var mainOffice = _bakeryOffices[0];
            mainOffice.AddBread(baguette);
            mainOffice.AddBread(whiteBread);
            mainOffice.AddBread(milkBread);

            var secondOffice = _bakeryOffices[1];
            secondOffice.AddBread(baguette);
            secondOffice.AddBread(whiteBread);
            secondOffice.AddBread(hamburguerBun);
        }

        public List<BakeryOffice> GetAllBakeryOffices() 
        {
            return _bakeryOffices;
        }

        public BakeryOffice? GetBakeryOffice(string name)
        {
            return _bakeryOffices.Find(office => office.Name == name);
        }

        public void AddBakeryOffice(BakeryOffice office) 
        {
            _bakeryOffices.Add(office);
        }
    }
}
