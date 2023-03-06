using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Staffs
{
    public interface IEditStaffUseCase
    {
        Task ExecuteAsync(Staff staff);
    }
}