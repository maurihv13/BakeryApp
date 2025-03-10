﻿
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
            var baguette = new Baguette();
            var whiteBread = new WhiteBread();
            var milkBread = new MilkBread();
            var hamburguerBun = new HamburguerBun();

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

        public BakeryOffice? GetBakeryOfficeByName(string name)
        {
            return _bakeryOffices.Find(office => office.Name == name);
        }

        public void AddBakeryOffice(BakeryOffice office) 
        {
            _bakeryOffices.Add(office);
        }
    }
}
