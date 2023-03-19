using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Vehicles
{
    public interface ISellVehicleUseCase
    {
        Task ExecuteAsync(string salesOrderNumber, Vehicle vehicle, double price, string doneBy);
    }
}