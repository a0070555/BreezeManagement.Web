using BreezeManagement.CoreBusiness.Models;

namespace Breeze.UseCases.Interfaces
{
    public interface IViewFeaturesByIdUseCase
    {
        Task<Feature?> ExecuteAsync(int featureId);
    }
}