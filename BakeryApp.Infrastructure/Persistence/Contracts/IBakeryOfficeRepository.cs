using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryApp.Infrastructure.Persistence.Entities;

namespace BakeryApp.Infrastructure.Persistence.Contracts
{
    public interface IBakeryOfficeRepository
    {
        Task<IEnumerable<BakeryOfficeEntity>> GetAllAsync();
        Task<BakeryOfficeEntity> GetByIdAsync(int id);
        Task AddAsync(BakeryOfficeEntity bakeryOffice);
        Task UpdateAsync(BakeryOfficeEntity bakeryOffice);
        Task DeleteAsync(int id);
    }
}
