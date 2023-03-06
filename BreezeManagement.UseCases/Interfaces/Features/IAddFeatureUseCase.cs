using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Features
{
    public interface IAddFeatureUseCase
    {
        Task ExecuteAsync(Feature feature);
    }
}