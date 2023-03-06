using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Vehicles
{
    public class ViewVehiclesByIdUseCase : IViewVehiclesByIdUseCase
    {
        private readonly IVehicleRepository vehicleRepository;

        public ViewVehiclesByIdUseCase(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task<Vehicle> ExecuteAsync(int vehicleId)
        {
            return await vehicleRepository.GetVehicleByIdAsync(vehicleId);
        }
    }
}
