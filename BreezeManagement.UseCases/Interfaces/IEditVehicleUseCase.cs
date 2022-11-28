using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IEditVehicleUseCase
    {
        Task ExecuteAsync(Vehicle vehicle);
    }
}