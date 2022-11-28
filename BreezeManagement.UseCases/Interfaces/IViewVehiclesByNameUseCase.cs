using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IViewVehiclesByNameUseCase
    {
        Task<List<Vehicle>> ExecuteAsync(string name = "");
    }
}