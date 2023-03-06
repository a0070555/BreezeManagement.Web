using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces.Vehicles;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Vehicles
{
    public class EditVehicleUseCase : IEditVehicleUseCase
    {
        private readonly IVehicleRepository vehicleRepository;

        public EditVehicleUseCase(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task ExecuteAsync(Vehicle vehicle)
        {
            await vehicleRepository.UpdateVehicleAsync(vehicle);
        }
    }
}
