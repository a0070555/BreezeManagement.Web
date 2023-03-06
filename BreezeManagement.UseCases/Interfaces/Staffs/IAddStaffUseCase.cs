using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Staffs
{
    public interface IAddStaffUseCase
    {
        Task ExecuteAsync(Staff staff);
    }
}