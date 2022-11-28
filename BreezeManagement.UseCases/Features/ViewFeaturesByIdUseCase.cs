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
    public class ViewFeaturesByIdUseCase : IViewFeaturesByIdUseCase
    {
        private readonly IFeatureRepository featureRepository;

        public ViewFeaturesByIdUseCase(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public async Task<Feature?> ExecuteAsync(int featureId)
        {
            return await featureRepository.GetFeaturesByIdAsync(featureId);
        }
    }
}
