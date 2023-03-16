using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.VehicleTransactions
{
    public interface ISearchVehicleTransactionsUseCase
    {
        Task<IEnumerable<VehicleTransaction>> ExecuteAsync(string registration, DateTime? dateFrom, DateTime? dateTo);
    }
}