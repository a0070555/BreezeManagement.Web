using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces.Staffs;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Staffs
{
    public class ViewStaffByIdUseCase : IViewStaffByIdUseCase
    {
        private readonly IStaffRepository staffRepository;

        public ViewStaffByIdUseCase(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        public async Task<Staff?> ExecuteAsync(int staffId)
        {
            return await staffRepository.GetStaffByIdAsync(staffId);
        }
    }
}
