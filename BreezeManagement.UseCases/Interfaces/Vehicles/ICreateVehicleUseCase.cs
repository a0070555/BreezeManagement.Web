using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Vehicles
{
    public interface ICreateVehicleUseCase
    {
        Task ExecuteAsync(string creationNumber, Vehicle vehicle, string doneBy);
    }
}