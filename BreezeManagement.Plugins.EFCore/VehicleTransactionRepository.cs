using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.PluginInterfaces;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.Plugins.EFCore
{
    public class VehicleTransactionRepository : IVehicleTransactionRepository
    {
        private readonly BreezeManagementContext db;
        private readonly IVehicleRepository vehicleRepository;
        private readonly IStaffRepository staffRepository;
        public VehicleTransactionRepository(BreezeManagementContext db, IVehicleRepository vehicleRepository, IStaffRepository staffRepository)
        {
            this.db = db;
            this.vehicleRepository = vehicleRepository;
            this.staffRepository = staffRepository;
        }

        public async Task<IEnumerable<VehicleTransaction>> GetVehicleTransactionsAsync(string vehicleName, DateTime? dateFrom, DateTime? dateTo)
        {
            if (dateTo.HasValue) dateTo = dateTo.Value.AddDays(1);

            var query = from vt in db.VehicleTransactions
                        join veh in db.Vehicles on vt.VehicleId equals veh.VehicleId
                        where
                            (string.IsNullOrWhiteSpace(vehicleName) || veh.Registration.ToLower().IndexOf(vehicleName.ToLower()) >= 0) &&
                            (!dateFrom.HasValue || vt.TransactionDate >= dateFrom.Value.Date) &&
                            (!dateTo.HasValue || vt.TransactionDate <= dateTo.Value.Date)
                        select vt;

            return await query.Include(x => x.Vehicle).ToListAsync();
        }

        public async Task CreateAsync(string creationNumber, Vehicle vehicle, double price, string doneBy)
        {
            var veh = await this.vehicleRepository.GetVehicleByIdAsync(vehicle.VehicleId);
            if (veh == null)
            {
                foreach (var vi in veh.VehicleFeatures)
                {
                    this.db.FeatureAdditions.Add(new FeatureAddition
                    {
                        FeatureId = vi.Feature.FeatureId,
                        UnitPrice = price
                    });
                }
            }

            this.db.VehicleTransactions.Add(new VehicleTransaction
            {
                CreationNumber = creationNumber,
                VehicleId = vehicle.VehicleId,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });
            await this.db.SaveChangesAsync();
        }

        public async Task SellVehicleAsync(string salesOrderNumber, Vehicle vehicle, double price, string doneBy)
        {
            this.db.VehicleTransactions.Add(new VehicleTransaction
            {
                SalesOrderNumber = salesOrderNumber,
                VehicleId = vehicle.VehicleId,
                TransactionDate = DateTime.Now,
                DoneBy = doneBy,
                UnitPrice = price
            });

            var staff = await this.db.Staff.FirstOrDefaultAsync(x => x.Email.ToLower() == doneBy.ToLower());

            if (staff != null)
            {
                staff.NumberOfSales++;
            }

            vehicle.IsDeleted = true;
            await this.db.SaveChangesAsync();
        }
    }
}
