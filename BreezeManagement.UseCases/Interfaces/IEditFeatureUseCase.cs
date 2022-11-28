using BreezeManagement.CoreBusiness.Models;

namespace Breeze.UseCases.Interfaces
{
    public interface IEditFeatureUseCase
    {
        Task ExecuteAsync(Feature feature);
    }
}