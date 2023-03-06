using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces.Features;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Activities
{
    public class CreateFeatureUseCase : ICreateFeatureUseCase
    {
        private readonly IFeatureAdditionRepository featureAdditionRepository;
        private readonly IFeatureRepository featureRepository;

        public CreateFeatureUseCase(IFeatureAdditionRepository featureAdditionRepository, IFeatureRepository featureRepository)
        {
            this.featureAdditionRepository = featureAdditionRepository;
            this.featureRepository = featureRepository;
        }

        public async Task ExecuteAsync(Feature feature)
        {
            await featureAdditionRepository.CreateAsync(feature, feature.AddedPrice);

            await featureRepository.UpdateFeatureAsync(feature);
        }
    }
}
