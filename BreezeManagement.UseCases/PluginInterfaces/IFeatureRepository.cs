using BreezeManagement.CoreBusiness.Models;

namespace Breeze.UseCases.PluginInterfaces
{
    public interface IFeatureRepository
    {
        Task AddFeatureAsync(Feature feature);
        Task<Feature?> GetFeaturesByIdAsync(int featureId);
        Task<IEnumerable<Feature>> GetFeaturesByName(string name);
        Task UpdateFeatureAsync(Feature feature);
    }
}