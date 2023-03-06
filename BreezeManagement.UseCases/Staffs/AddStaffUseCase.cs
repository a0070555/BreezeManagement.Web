using BreezeManagement.CoreBusiness.Models;
using BreezeManagement.UseCases.Interfaces;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Staffs
{
    public class AddStaffUseCase : IAddStaffUseCase
    {
        private readonly IStaffRepository staffRepository;

        public AddStaffUseCase(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        public async Task ExecuteAsync(Staff staff)
        {
            await staffRepository.AddStaffAsync(staff);
        }
    }
}
