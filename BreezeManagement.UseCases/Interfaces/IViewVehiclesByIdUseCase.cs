using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IViewVehiclesByIdUseCase
    {
        Task<Vehicle> ExecuteAsync(int vehicleId);
    }
}