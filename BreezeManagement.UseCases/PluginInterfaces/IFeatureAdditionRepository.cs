using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.PluginInterfaces
{
    public interface IFeatureAdditionRepository
    {
        Task<IEnumerable<FeatureAddition>> GetFeatureAdditionsAsync(string featureName);
        Task CreateAsync(Feature feature, double addedPrice);
    }
}