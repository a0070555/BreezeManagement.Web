using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces.VehicleTransactions;
using BreezeManagement.UseCases.PluginInterfaces;

namespace BreezeManagement.UseCases.Reports
{
    public class SearchVehicleTransactionsUseCase : ISearchVehicleTransactionsUseCase
    {
        private readonly IVehicleTransactionRepository vehicleTransactionRepository;

        public SearchVehicleTransactionsUseCase(IVehicleTransactionRepository vehicleTransactionRepository)
        {
            this.vehicleTransactionRepository = vehicleTransactionRepository;
        }

        public async Task<IEnumerable<VehicleTransaction>> ExecuteAsync(string registration, DateTime? dateFrom, DateTime? dateTo)
        {
            return await this.vehicleTransactionRepository.GetVehicleTransactionsAsync(registration, dateFrom, dateTo);
        }
    }
}
