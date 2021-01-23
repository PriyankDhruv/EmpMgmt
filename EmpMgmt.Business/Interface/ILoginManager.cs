using System;
using System.Collections.Generic;
using System.Text;
using EmpMgmt.Models.Models;
using EmpMgmt.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.Business.Interface
{
    public interface ILoginManager
    {
        [HttpPost]
        bool IsLoggerBAL(LoginViewModel Lg);

        [HttpPost]
        object AddUserBAL(EmployeemasterViewModel master, Registration reg);

        [HttpPost]
        bool IsEmailAlreadyExistsBAL(string email);
    }
}