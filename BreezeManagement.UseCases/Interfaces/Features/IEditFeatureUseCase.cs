using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Features
{
    public interface IEditFeatureUseCase
    {
        Task ExecuteAsync(Feature feature);
    }
}