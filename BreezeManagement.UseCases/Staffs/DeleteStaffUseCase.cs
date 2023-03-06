using BreezeManagement.UseCases.Interfaces.Staffs;
using BreezeManagement.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreezeManagement.UseCases.Staffs
{
    public class DeleteStaffUseCase : IDeleteStaffUseCase
    {
        private readonly IStaffRepository staffRepository;

        public DeleteStaffUseCase(IStaffRepository staffRepository)
        {
            this.staffRepository = staffRepository;
        }

        public async Task ExecuteAsync(int staffId)
        {
            await staffRepository.DeleteStaffAsync(staffId);
        }
    }
}
