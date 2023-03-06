using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.PluginInterfaces
{
    public interface IStaffRepository
    {
        Task AddStaffAsync(Staff staff);
        Task<Staff?> GetStaffByIdAsync(int staffId);

        Task UpdateStaffAsync(Staff staff);

        Task DeleteStaffAsync(int staffId);

        Task<IEnumerable<Staff>> GetStaffByName(string name);
    }
}