using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.PluginInterfaces
{
    public interface IVehicleTransactionRepository
    {
        Task<IEnumerable<VehicleTransaction>> GetVehicleTransactionsAsync(string vehicleName, DateTime? dateFrom, DateTime? dateTo, VehicleTransactionType? transactionType);
        Task CreateAsync(string creationNumber, Vehicle vehicle, double price, string doneBy);
        Task SellVehicleAsync(string salesOrderNumber, Vehicle vehicle, double price, string doneBy);
    }
}