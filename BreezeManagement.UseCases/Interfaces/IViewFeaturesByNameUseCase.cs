using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces
{
    public interface IViewFeaturesByNameUseCase
    {
        Task<IEnumerable<Feature>> ExecuteAsync(string name = "");
    }
}