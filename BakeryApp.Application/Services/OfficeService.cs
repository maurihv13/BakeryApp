using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public List<BakeryOffice> GetAllOffices() => _repository.GetAllBakeryOffices();

        public BakeryOffice GetOfficeByName(string name)
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
    }
}
