using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IViewFeaturesByIdUseCase
    {
        Task<Feature?> ExecuteAsync(int featureId);
    }
}