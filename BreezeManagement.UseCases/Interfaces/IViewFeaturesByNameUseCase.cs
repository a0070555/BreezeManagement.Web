using BreezeManagement.CoreBusiness.Models;

namespace Breeze.UseCases.Interfaces
{
    public interface IViewFeaturesByNameUseCase
    {
        Task<IEnumerable<Feature>> ExecuteAsync(string name = "");
    }
}