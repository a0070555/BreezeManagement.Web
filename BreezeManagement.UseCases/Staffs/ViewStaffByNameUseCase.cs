using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces.Staffs;
using BreezeManagement.UseCases.PluginInterfaces;

namespace BreezeManagement.UseCases.Staffs
{
    public class ViewStaffByNameUseCase : IViewStaffByNameUseCase
    {
        private readonly IStaffRepository staffRepository;

        public ViewStaffByNameUseCase(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        public async Task<IEnumerable<Staff>> ExecuteAsync(string name = "")
        {
            return await staffRepository.GetStaffByName(name);
        }
    }
}
