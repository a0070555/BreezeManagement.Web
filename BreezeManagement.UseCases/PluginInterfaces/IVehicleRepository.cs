using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.PluginInterfaces
{
    public interface IVehicleRepository
    {
        Task AddVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int vehicleId);
        Task<Vehicle> GetVehicleByIdAsync(int vehicleId);
        Task<List<Vehicle>> GetVehiclesByNameAsync(string name);
        Task UpdateVehicleAsync(Vehicle vehicle);
    }
}