using BreezeManagement.CoreBusiness.Models;

namespace Breeze.UseCases.Interfaces
{
    public interface IAddFeatureUseCase
    {
        Task ExecuteAsync(Feature feature);
    }
}