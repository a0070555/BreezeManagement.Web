using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreezeManagement.UseCases.Interfaces;
using BreezeManagement.UseCases.PluginInterfaces;

namespace BreezeManagement.UseCases.Features
{
    public class DeleteFeatureUseCase : IDeleteFeatureUseCase
    {
        private readonly IFeatureRepository featureRepository;

        public DeleteFeatureUseCase(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public async Task ExecuteAsync(int featureId)
        {
            await featureRepository.DeleteFeatureAsync(featureId);
        }
    }
}
