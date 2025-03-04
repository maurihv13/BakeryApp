using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Application.Interfaces
{
    public interface IOfficeService
    {
        public List<BakeryOffice> GetAllOffices();
        public BakeryOffice GetOfficeByName(string name);
    }
}
