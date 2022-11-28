using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IAddFeatureUseCase
    {
        Task ExecuteAsync(Feature feature);
    }
}