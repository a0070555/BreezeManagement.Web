using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Features
{
    public interface IViewFeaturesByNameUseCase
    {
        Task<IEnumerable<Feature>> ExecuteAsync(string name = "");
    }
}