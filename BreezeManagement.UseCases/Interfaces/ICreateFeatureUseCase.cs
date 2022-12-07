using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface ICreateFeatureUseCase
    {
        Task ExecuteAsync(Feature feature);
    }
}