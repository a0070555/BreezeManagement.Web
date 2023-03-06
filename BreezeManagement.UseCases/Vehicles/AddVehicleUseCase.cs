using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces.Vehicles;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Vehicles
{
    public class AddVehicleUseCase : IAddVehicleUseCase
    {
        private readonly IVehicleRepository vehicleFeature;

        public AddVehicleUseCase(IVehicleRepository vehicleFeature)
        {
            this.vehicleFeature = vehicleFeature;
        }

        public async Task ExecuteAsync(Vehicle vehicle)
        {
            if (vehicle == null) return;

            await vehicleFeature.AddVehicleAsync(vehicle);
        }
    }
}
