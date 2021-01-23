using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.Business.Interface
{
    public interface IEmpManager
    {
        [HttpGet]
        IQueryable<EmployeeViewModel> GetEmpsBAL();

        [HttpGet]
        IQueryable<DepartmentViewModel> GetEmpDeptsBAL();

        [HttpGet]
        EmployeeViewModel GetEmpByIdBAL(int id);

        [HttpGet]
        EmployeeViewModel GetEmpByNameBAL(string name);

        [HttpPost]
        void PostEmpBAL(EmployeeViewModel emp);

        [HttpPut]
        void PutEmpBAL(EmployeeViewModel emp);

        [HttpDelete]
        void DeleteEmpBAL(EmployeeViewModel emp);
    }
}