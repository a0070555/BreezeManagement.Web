using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IViewStaffByNameUseCase
    {
        Task<IEnumerable<Staff>> ExecuteAsync(string name = "");
    }
}