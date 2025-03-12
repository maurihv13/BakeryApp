
using BakeryApp.Application.DTOs;
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;
using BakeryApp.Infrastructure.Persistence.Contracts;
using BakeryApp.Infrastructure.Persistence.Repositories;
using BakeryApp.Infrastructure.Repositories;

namespace BakeryApp.Application.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly IBakeryOfficeRepository _repository;
        private readonly IBreadRepository _breadRepository;
        private readonly FakeBakeryOfficeRepository _repositoryFake;

        public OfficeService(IBakeryOfficeRepository repository, IBreadRepository breadRepository)
        {
            _repository = repository;
            _breadRepository = breadRepository;
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

        public async Task<List<string>> GetAllOfficeNamesFromDbAsync()
        {
            var offices = await _repository.GetAllAsync();
            return offices.Select(o => o.Name).ToList();
        }

        public async Task<OfficeData> GetOfficeDataFromDbAsync(string name)
        {
            var officeEntity = await _repository.GetByNameAsync(name);
            if (officeEntity == null)
            {
                throw new InvalidOperationException($"Office with name {name} not found.");
            }

            return new OfficeData
            {
                Name = officeEntity.Name,
                Address = officeEntity.Address,
                RemainingCapacity = officeEntity.MaxCapacity, // Assuming MaxCapacity is the remaining capacity
                OrderCount = officeEntity.Orders.Count
            };
        }

        public async Task<List<(string Type, double Price)>> GetBreadsFromDbAsync(string name)
        {
            var breads = await _breadRepository.GetBreadsByOfficeNameAsync(name);
            return breads.Select(b => (b.Name, b.Price)).ToList();
        }
    }
}
