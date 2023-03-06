using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Staffs
{
    public interface IViewStaffByIdUseCase
    {
        Task<Staff?> ExecuteAsync(int staffId);
    }
}