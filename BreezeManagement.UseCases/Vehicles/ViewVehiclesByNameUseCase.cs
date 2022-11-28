using BreezeManagement.Plugins.EFCore;
using BreezeManagement.CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreezeManagement.UseCases.Interfaces;

namespace BreezeManagement.UseCases.Vehicles
{
    public class ViewVehiclesByNameUseCase : IViewVehiclesByNameUseCase
    {
        private readonly IVehicleRepository vehicleRepository;

        public ViewVehiclesByNameUseCase(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task<List<Vehicle>> ExecuteAsync(string name = "")
        {
            return await vehicleRepository.GetVehiclesByNameAsync(name);
        }
    }
}
