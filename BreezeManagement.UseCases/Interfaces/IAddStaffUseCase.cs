using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IAddStaffUseCase
    {
        Task ExecuteAsync(Staff staff);
    }
}