using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.PluginInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.Plugins.EFCore
{
    public class FeatureAdditionRepository : IFeatureAdditionRepository
    {
        private readonly BreezeManagementContext db;

        public FeatureAdditionRepository(BreezeManagementContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<FeatureAddition>> GetFeatureAdditionsAsync(
            string featureName)
        { 
            var query = from fa in db.FeatureAdditions
                        join feat in db.Features on fa.FeatureId equals feat.FeatureId
                        where
                            (string.IsNullOrWhiteSpace(featureName) || feat.FeatureName.ToLower().IndexOf(featureName.ToLower()) >= 0)
                        select fa;

            return await query.Include(x => x.Feature).ToListAsync();
        }

        public async Task CreateAsync(Feature feature, double price)
        {
            this.db.FeatureAdditions.Add(new FeatureAddition
            {
                FeatureId = feature.FeatureId,
                UnitPrice = price
            });
            await this.db.SaveChangesAsync();
        }
    }
}
