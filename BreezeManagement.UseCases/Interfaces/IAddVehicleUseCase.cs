using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IAddVehicleUseCase
    {
        Task ExecuteAsync(Vehicle vehicle);
    }
}