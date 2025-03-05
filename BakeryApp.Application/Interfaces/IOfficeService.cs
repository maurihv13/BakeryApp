
using BakeryApp.Application.DTOs;

namespace BakeryApp.Application.Interfaces
{
    public interface IOfficeService
    {
        public List<string> GetBreads(string name);
        public int GetRemainingCapacity(string name);
        public List<string> GetOfficesNames();
        public OfficeData GetOfficeData(string name);
        public EarningData GetAllEarnings();
    }
}
