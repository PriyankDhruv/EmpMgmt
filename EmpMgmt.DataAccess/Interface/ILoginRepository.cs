using System;
using System.Collections.Generic;
using System.Text;
using EmpMgmt.DAO.Entites;
using EmpMgmt.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.DataAccess.Interface
{
    public interface ILoginRepository
    {
        [HttpPost]
        bool IsLoggerDAL(Login Lg);

        [HttpPost]
        object AddUserDAL(Employeemaster master, Registration reg);

        [HttpPost]
        bool IsEmailAlreadyExistsDAL(string email);
    }
}