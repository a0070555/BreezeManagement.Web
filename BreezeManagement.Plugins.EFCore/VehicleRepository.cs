using Breeze.Plugins.EFCore;
using BreezeManagement.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.Plugins.EFCore
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly BreezeManagementContext db;

        public VehicleRepository(BreezeManagementContext db)
        {
            this.db = db;
        }

        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            //if (db.Vehicles.Any(x => x.VehicleName.Equals(vehicle.VehicleName, StringComparison.OrdinalIgnoreCase)))
            if (db.Vehicles.Any(x => x.Registration.ToLower() == vehicle.Registration.ToLower()))
            {
                return;
            }

            db.Vehicles.Add(vehicle);
            await db.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            var vehicle = await db.Vehicles.FindAsync(vehicleId);
            if (vehicle != null)
            {
                vehicle.IsDeleted = true;
                await db.SaveChangesAsync();
            }
        }

        public async Task<Vehicle> GetVehicleByIdAsync(int vehicleId)
        {
            return await db.Vehicles.Include(x => x.VehicleFeatures)
                .ThenInclude(x => x.Feature)
                .FirstOrDefaultAsync(x => x.VehicleId == vehicleId);
        }

        public async Task<List<Vehicle>> GetVehiclesByNameAsync(string name)
        {
            return await this.db.Vehicles.Where(x => (x.Registration.ToLower().IndexOf(name.ToLower()) >= 0 ||
                                                    string.IsNullOrWhiteSpace(name)) &&
                                                    x.IsDeleted == false).ToListAsync();
        }

        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            //prevents same name
            if (db.Vehicles.Any(x => x.Registration.ToLower() == vehicle.Registration.ToLower()))
            {
                return;
            }

            var prod = await db.Vehicles.FindAsync(vehicle.VehicleId);
            if (prod != null)
            {
                prod.Registration = vehicle.Registration;
                prod.ModelName = vehicle.ModelName;
                prod.Colour = vehicle.Colour;
                prod.Price = vehicle.Price;
                prod.DateOfManufacture = vehicle.DateOfManufacture;
                prod.NumberOfOwners = vehicle.NumberOfOwners;
                prod.Mileage = vehicle.Mileage;
                prod.VehicleFeatures = vehicle.VehicleFeatures;

                await db.SaveChangesAsync();
            }
        }
    }
}
