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
        public DbSet<Staff> Staff { get; set; }
        public DbSet<FeatureAddition> FeatureAdditions { get; set; }
        public DbSet<VehicleTransaction> VehicleTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Test data
            modelBuilder.Entity<VehicleFeature>()
                .HasKey(vf => new { vf.VehicleId, vf.FeatureId });

            modelBuilder.Entity<VehicleFeature>()
                .HasOne(vf => vf.Vehicle)
                .WithMany(f => f.VehicleFeatures)
                .HasForeignKey(vf => vf.VehicleId);

            modelBuilder.Entity<VehicleFeature>()
                .HasOne(vf => vf.Feature)
                .WithMany(f => f.VehicleFeatures)
                .HasForeignKey(vf => vf.FeatureId);

            modelBuilder.Entity<Feature>().HasData(
                new Feature { FeatureId = 1, FeatureName = "Sun Roof", AddedPrice = 500, Description = "Adds a luxurious sunroof to the vehicle" },
                new Feature { FeatureId = 2, FeatureName = "Extra Cameras", AddedPrice = 600, Description = "Installs additional cameras" },
                new Feature { FeatureId = 3, FeatureName = "Heated seats", AddedPrice = 75.5, Description = "Adds heating to vehicle seats" },
                new Feature { FeatureId = 4, FeatureName = "WiFi", AddedPrice = 500, Description = "Adds the option of in-car wifi" }
                );

            modelBuilder.Entity<VehicleFeature>().HasData(
                new VehicleFeature { FeatureId = 1, VehicleId = 1 }
                );

        }
    }
}
