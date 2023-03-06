namespace BreezeManagement.UseCases.Interfaces
{
    public interface IDeleteFeatureUseCase
    {
        Task ExecuteAsync(int featureId);
    }
}