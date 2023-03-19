using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces;
using BreezeManagement.UseCases.PluginInterfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.Plugins.EFCore
{
    public class StaffRepository : IStaffRepository
    {
        private readonly BreezeManagementContext db;

        public StaffRepository(BreezeManagementContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Staff>> GetStaffByName(string name)
        {
            return await this.db.Staff.Where(s => s.FirstName.ToLower().IndexOf(name.ToLower()) >= 0 && s.IsDeleted == false ||
            s.LastName.ToLower().IndexOf(name.ToLower()) >= 0 && s.IsDeleted == false ||
            (s.FirstName + " " + s.LastName).ToLower().IndexOf(name.ToLower()) >= 0 && s.IsDeleted == false).ToListAsync();
        }

        public async Task AddStaffAsync(Staff staff)
        {
            if (db.Staff.Any(x => x.Email.ToLower() == staff.Email.ToLower() && x.IsDeleted == false))
            {
                return;
            }

            this.db.Staff.Add(staff);
            await this.db.SaveChangesAsync();
        }

        public async Task UpdateStaffAsync(Staff staff)
        {
            if (db.Staff.Any(x => x.Email.ToLower() == staff.Email.ToLower() && x.IsDeleted == false && x.StaffId != staff.StaffId))
            {
                return;
            }

            var sf = await this.db.Staff.FindAsync(staff.StaffId);
            if (sf != null)
            {
                sf.FirstName = staff.FirstName;
                sf.LastName = staff.LastName;
                sf.PhoneNumber = staff.PhoneNumber;
                sf.DateOfBirth = staff.DateOfBirth;
                sf.Address = staff.Address;
                sf.Title = staff.Title;
                sf.Email = staff.Email;
                sf.NumberOfSales = staff.NumberOfSales;

                await db.SaveChangesAsync();
            }
        }

        public async Task<Staff?> GetStaffByIdAsync(int staffId)
        {
            return await this.db.Staff.FindAsync(staffId);
        }

        public async Task DeleteStaffAsync(int staffId)
        {
            var staff = await db.Staff.FindAsync(staffId);
            if (staff != null)
            {
                staff.IsDeleted = true;
                await db.SaveChangesAsync();
            }
        }
    }
}
