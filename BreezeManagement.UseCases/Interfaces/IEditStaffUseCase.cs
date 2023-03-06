using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IEditStaffUseCase
    {
        Task ExecuteAsync(Staff staff);
    }
}