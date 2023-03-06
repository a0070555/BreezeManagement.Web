using BreezeManagement.UseCases.Interfaces.Vehicles;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Vehicles
{
    public class DeleteVehicleUseCase : IDeleteVehicleUseCase
    {
        private readonly IVehicleRepository vehicleRepository;

        public DeleteVehicleUseCase(IVehicleRepository vehicleRepository)
        {
            this.vehicleRepository = vehicleRepository;
        }

        public async Task ExecuteAsync(int vehicleId)
        {
            await vehicleRepository.DeleteVehicleAsync(vehicleId);
        }
    }
}
