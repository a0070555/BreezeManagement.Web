using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Activities
{
    public class CreateVehicleUseCase : ICreateVehicleUseCase
    {
        private readonly IFeatureRepository featureRepository;
        private readonly IFeatureAdditionRepository featureAdditionRepository;
        private readonly IVehicleTransactionRepository vehicleTransactionRepository;

        public CreateVehicleUseCase(IFeatureRepository featureRepository,
            IVehicleRepository vehicleRepository,
            IFeatureAdditionRepository featureAdditionRepository,
            IVehicleTransactionRepository vehicleTransactionRepository)
        {
            this.featureRepository = featureRepository;
            VehicleRepository = vehicleRepository;
            this.featureAdditionRepository = featureAdditionRepository;
            this.vehicleTransactionRepository = vehicleTransactionRepository;
        }

        public IVehicleRepository VehicleRepository { get; }

        public async Task ExecuteAsync(string creationNumber, Vehicle vehicle, string doneBy)
        {
            await vehicleTransactionRepository.CreateAsync(creationNumber, vehicle, vehicle.Price, doneBy);

            await VehicleRepository.UpdateVehicleAsync(vehicle);
        }
    }
}
