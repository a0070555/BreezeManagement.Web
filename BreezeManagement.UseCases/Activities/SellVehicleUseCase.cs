using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces.Vehicles;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Activities
{
    public class SellVehicleUseCase : ISellVehicleUseCase
    {
        private readonly IVehicleTransactionRepository vehicleTransactionRepository;
        private readonly IVehicleRepository vehicleRepository;

        public SellVehicleUseCase(IVehicleTransactionRepository vehicleTransactionRepository, IVehicleRepository vehicleRepository)
        {
            this.vehicleTransactionRepository = vehicleTransactionRepository;
            this.vehicleRepository = vehicleRepository;
        }

        public async Task ExecuteAsync(string salesOrderNumber, Vehicle vehicle, string doneBy)
        {
            await vehicleTransactionRepository.SellVehicleAsync(salesOrderNumber, vehicle, vehicle.Price, doneBy);

            await vehicleRepository.UpdateVehicleAsync(vehicle);
        }
    }
}
