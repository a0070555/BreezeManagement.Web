using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Vehicles
{
    public interface IEditVehicleUseCase
    {
        Task ExecuteAsync(Vehicle vehicle);
    }
}