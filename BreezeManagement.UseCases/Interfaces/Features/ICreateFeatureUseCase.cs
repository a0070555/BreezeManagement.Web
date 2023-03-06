using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Features
{
    public interface ICreateFeatureUseCase
    {
        Task ExecuteAsync(Feature feature);
    }
}