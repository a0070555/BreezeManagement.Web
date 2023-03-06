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
    public class EditStaffUseCase : IEditStaffUseCase
    {
        private readonly IStaffRepository staffRepository;

        public EditStaffUseCase(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        public async Task ExecuteAsync(Staff staff)
        {
            await staffRepository.UpdateStaffAsync(staff);
        }
    }
}
