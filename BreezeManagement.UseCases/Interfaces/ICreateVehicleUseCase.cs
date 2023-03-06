using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface ICreateVehicleUseCase
    {
        Task ExecuteAsync(string creationNumber, Vehicle vehicle, string doneBy);
    }
}