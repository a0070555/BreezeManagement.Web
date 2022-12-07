using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface ISellVehicleUseCase
    {
        Task ExecuteAsync(string salesOrderNumber, Vehicle vehicle, string doneBy);
    }
}