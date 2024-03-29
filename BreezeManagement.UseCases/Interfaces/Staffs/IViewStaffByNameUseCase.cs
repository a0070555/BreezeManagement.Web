﻿using BreezeManagement.CoreBusiness.Models;

namespace BreezeManagement.UseCases.Interfaces.Staffs
{
    public interface IViewStaffByNameUseCase
    {
        Task<IEnumerable<Staff>> ExecuteAsync(string name = "");
    }
}