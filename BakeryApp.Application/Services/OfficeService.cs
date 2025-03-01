using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Application.Interfaces;
using BakeryApp.Domain.Entities;

namespace BakeryApp.Application.Services
{
    public class OfficeService : IOfficeService
    {
        public BakeryOffice GetOfficeByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<string> GetOfficeNames()
        {
            throw new NotImplementedException();
        }
    }
}
