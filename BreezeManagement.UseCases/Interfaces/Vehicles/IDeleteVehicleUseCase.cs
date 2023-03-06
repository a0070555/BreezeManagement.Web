namespace BreezeManagement.UseCases.Interfaces.Vehicles
{
    public interface IDeleteVehicleUseCase
    {
        Task ExecuteAsync(int vehicleId);
    }
}