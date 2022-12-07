using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.Plugins.EFCore;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface ICreateVehicleUseCase
    {
        Task ExecuteAsync(string creationNumber, Vehicle vehicle, string doneBy);
    }
}