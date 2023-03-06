using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Features
{
    public interface IViewFeaturesByIdUseCase
    {
        Task<Feature?> ExecuteAsync(int featureId);
    }
}