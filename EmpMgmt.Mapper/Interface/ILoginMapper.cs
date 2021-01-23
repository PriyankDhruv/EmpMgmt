using System;
using System.Collections.Generic;
using System.Text;
using EmpMgmt.Models.Models;
using EmpMgmt.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.Mapper.Interface
{
    public interface ILoginMapper
    {
        [HttpPost]
        bool IsMappedLogger(LoginViewModel Lg);

        [HttpPost]
        object AddMappedUser(EmployeemasterViewModel master, Registration reg);

        [HttpPost]
        bool IsMappedEmailAlreadyExists(string email);

    }
}