using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Vehicles
{
    public interface IViewVehiclesByNameUseCase
    {
        Task<List<Vehicle>> ExecuteAsync(string name = "");
    }
}