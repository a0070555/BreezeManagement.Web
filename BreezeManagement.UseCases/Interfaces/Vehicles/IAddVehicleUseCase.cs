using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Vehicles
{
    public interface IAddVehicleUseCase
    {
        Task ExecuteAsync(Vehicle vehicle);
    }
}