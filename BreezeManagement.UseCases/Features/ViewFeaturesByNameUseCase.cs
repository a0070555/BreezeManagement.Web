﻿using Breeze.UseCases.Interfaces;
using Breeze.UseCases.PluginInterfaces;
using BreezeManagement.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breeze.UseCases.Features
{
    public class ViewFeaturesByNameUseCase : IViewFeaturesByNameUseCase
    {
        private readonly IFeatureRepository featureRepository;

        public ViewFeaturesByNameUseCase(IFeatureRepository featureRepository)
        {
            this.featureRepository = featureRepository;
        }

        public async Task<IEnumerable<Feature>> ExecuteAsync(string name = "")
        {
            return await featureRepository.GetFeaturesByName(name);
        }
    }
}
