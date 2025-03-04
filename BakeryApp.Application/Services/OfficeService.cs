
using BakeryApp.Application.DTOs;
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;
using BakeryApp.Infrastructure.Repositories;

namespace BakeryApp.Application.Services
{
    public class OfficeService : IOfficeService
    {
        private readonly FakeBakeryOfficeRepository _repository;

        public OfficeService(FakeBakeryOfficeRepository repository)
        {
            _repository = repository;
        }

        internal BakeryOffice GetOfficeByName(string name)
        {
            return _repository.GetBakeryOfficeByName(name) ?? throw new InvalidOperationException($"Office with name {name} not found.");
        }

        public List<string> GetBreads(string name) 
        {
            var breads = new List<string>();
            var office = GetOfficeByName(name);
            if (office != null) 
            {
                foreach (var bread in office.Menu) 
                {
                    breads.Add(bread.Name);
                }
            }
            return breads;
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
            var offices = _repository.GetAllBakeryOffices();
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
    }
}
