
using BakeryApp.Application.DTOs;

namespace BakeryApp.Application.Interfaces
{
    public interface IOfficeService
    {
        public List<(string Type, double Price)> GetBreads(string name);
        public int GetRemainingCapacity(string name);
        public List<string> GetOfficesNames();
        public OfficeData GetOfficeData(string name);
        public EarningData GetAllEarnings();
        public Task<List<string>> GetAllOfficeNamesFromDbAsync();
        public Task<OfficeData> GetOfficeDataFromDbAsync(string name);
        public Task<List<(string Type, double Price)>> GetBreadsFromDbAsync(string name);
    }
}
