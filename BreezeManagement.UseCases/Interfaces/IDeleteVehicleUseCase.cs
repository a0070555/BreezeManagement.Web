

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IDeleteVehicleUseCase
    {
        Task ExecuteAsync(int vehicleId);
    }
}