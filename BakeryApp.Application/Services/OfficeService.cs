
using BakeryApp.Application.DTOs;
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;
using BakeryApp.Infrastructure.Persistence.Contracts;
using BakeryApp.Infrastructure.Repositories;

namespace BakeryApp.Application.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IBakeryOfficeRepository _repository;
        private readonly FakeBakeryOfficeRepository _repositoryFake;

        public OfficeService(IBakeryOfficeRepository repository)
        {
            _repository = repository;
            _repositoryFake = new FakeBakeryOfficeRepository();
        }

        internal BakeryOffice GetOfficeByName(string name)
        {
            return _repositoryFake.GetBakeryOfficeByName(name) ?? throw new InvalidOperationException($"Office with name {name} not found.");
        }

        public List<(string Type, double Price)> GetBreads(string name) 
        {
            var breads = new List<string>();
            var breadItems = new List<(string Type, double Price)>();
            var office = GetOfficeByName(name);
            if (office != null) 
            {
                foreach (var bread in office.Menu) 
                {
                    breads.Add(bread.Name);
                    breadItems.Add((bread.Name, bread.Price));
                }
            }
            return breadItems;
        }

        public int GetRemainingCapacity(string name) 
        {
            var office = GetOfficeByName(name);
            if (office != null)
            {
                return office.RemainingCapacity();
            }
            return -1;
        }

        public List<string> GetOfficesNames() 
        {
            var officesNames = new List<string>();
            var offices = _repositoryFake.GetAllBakeryOffices();
            foreach (var office in offices) 
            {
                officesNames.Add(office.Name);
            }
            return officesNames;
        }

        public OfficeData GetOfficeData(string name)
        {
            var office = GetOfficeByName(name); // Throws error if doesn't exist
            return new OfficeData
            {
                Name = office.Name,
                Address = office.Address,
                RemainingCapacity = office.RemainingCapacity(),
                OrderCount = office.Orders.Count
            };

        }

        public EarningData GetAllEarnings()
        {
            var earnings = new EarningData();
            var offices = _repositoryFake.GetAllBakeryOffices();
            foreach (var office in offices)
            {
                earnings.TotalEarned += office.GetTotalEarned();
                earnings.Prepared += office.GetNumberPrepared();
            }
            return earnings;
        }

        public async Task GetRepositoriesAsync()
        {
            var result = await _repository.GetAllAsync();
            Console.WriteLine(result);
        }
    }
}
