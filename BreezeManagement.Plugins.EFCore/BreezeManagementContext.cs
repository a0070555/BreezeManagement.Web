using BreezeManagement.CoreBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.Plugins.EFCore
{
    public class BreezeManagementContext : DbContext
    {
        public BreezeManagementContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feature>().HasData(
                new Feature { FeatureId = 1, FeatureName = "Sun Roof", AddedPrice = 500, Description = "Adds a luxurious sunroof to the vehicle" },
                new Feature { FeatureId = 2, FeatureName = "Extra Cameras", AddedPrice = 600, Description = "Installs additional cameras" },
                new Feature { FeatureId = 3, FeatureName = "Heated seats", AddedPrice = 75.5, Description = "Adds heating to vehicle seats" },
                new Feature { FeatureId = 4, FeatureName = "WiFi", AddedPrice = 500, Description = "Adds the option of in-car wifi" }
                );
        }
    }
}
