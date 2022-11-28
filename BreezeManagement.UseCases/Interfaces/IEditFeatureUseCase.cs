using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IEditFeatureUseCase
    {
        Task ExecuteAsync(Feature feature);
    }
}