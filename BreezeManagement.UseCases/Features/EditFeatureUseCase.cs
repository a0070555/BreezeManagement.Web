using BreezeManagement.UseCases.PluginInterfaces;
using BreezeManagement.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreezeManagement.UseCases.Interfaces.Features;

namespace Breeze.UseCases.Features
{
    public class EditFeatureUseCase : IEditFeatureUseCase
    {
        private readonly IFeatureRepository featureRepository;

        public EditFeatureUseCase(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public async Task ExecuteAsync(Feature feature)
        {
            await featureRepository.UpdateFeatureAsync(feature);
        }
    }
}
