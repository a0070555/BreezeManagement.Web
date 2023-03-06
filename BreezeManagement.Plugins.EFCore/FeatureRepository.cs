using BreezeManagement.UseCases.PluginInterfaces;
using BreezeManagement.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.Plugins.EFCore
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly BreezeManagementContext db;

        public FeatureRepository(BreezeManagementContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Feature>> GetFeaturesByName(string name)
        {
            return await this.db.Features.Where(f => f.FeatureName.Contains(name, StringComparison.OrdinalIgnoreCase) && f.IsDeleted == false ||
                                                    string.IsNullOrWhiteSpace(name) && f.IsDeleted == false).ToListAsync();
        }

        public async Task AddFeatureAsync(Feature feature)
        {
            //To prevent different features from having the same name
            if (db.Features.Any(x => x.FeatureName.ToLower() == feature.FeatureName.ToLower() && x.IsDeleted == false))
            {
                return;
            }

            this.db.Features.Add(feature);
            await this.db.SaveChangesAsync();
        }

        public async Task UpdateFeatureAsync(Feature feature)
        {
            //To prevent different featentories from having the same name
            if (db.Features.Any(x => x.FeatureId != feature.FeatureId &&
                                      x.FeatureName.ToLower() == feature.FeatureName.ToLower())) return;

            var feat = await this.db.Features.FindAsync(feature.FeatureId);
            if (feat != null)
            {
                feat.FeatureName = feature.FeatureName;
                feat.Description = feature.Description;
                feat.AddedPrice = feature.AddedPrice;

                await db.SaveChangesAsync();
            }
        }

        public async Task<Feature?> GetFeaturesByIdAsync(int featureId)
        {
            return await this.db.Features.FindAsync(featureId);
        }

        public async Task DeleteFeatureAsync(int featureId)
        {
            var feature = await db.Features.FindAsync(featureId);
            if (feature != null)
            {
                feature.IsDeleted = true;
                await db.SaveChangesAsync();
            }
        }
    }
}
