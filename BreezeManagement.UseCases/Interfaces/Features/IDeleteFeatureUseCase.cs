namespace BreezeManagement.UseCases.Interfaces.Features
{
    public interface IDeleteFeatureUseCase
    {
        Task ExecuteAsync(int featureId);
    }
}