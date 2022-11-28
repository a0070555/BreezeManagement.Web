using BreezeManagement.UseCases.Interfaces;
using BreezeManagement.UseCases.PluginInterfaces;
using BreezeManagement.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breeze.UseCases.Features
{
    public class AddFeatureUseCase : IAddFeatureUseCase
    {
        private readonly IFeatureRepository featureRepository;

        public AddFeatureUseCase(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public async Task ExecuteAsync(Feature feature)
        {
            await featureRepository.AddFeatureAsync(feature);
        }
    }
}
