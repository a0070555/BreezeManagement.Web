using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IViewStaffByIdUseCase
    {
        Task<Staff?> ExecuteAsync(int staffId);
    }
}