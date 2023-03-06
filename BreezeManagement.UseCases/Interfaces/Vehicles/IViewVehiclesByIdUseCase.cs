using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Vehicles
{
    public interface IViewVehiclesByIdUseCase
    {
        Task<Vehicle> ExecuteAsync(int vehicleId);
    }
}