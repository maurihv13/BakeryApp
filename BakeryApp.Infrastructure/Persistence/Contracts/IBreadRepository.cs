using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Infrastructure.Persistence.Entities;

namespace BakeryApp.Infrastructure.Persistence.Contracts
{
    public interface IBreadRepository
    {
        Task<IEnumerable<BreadEntity>> GetBreadsByOfficeNameAsync(string officeName);
    }
}
