using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.Mapper.Interface
{
    public interface IEmployeeMapper
    {
        [HttpGet]
        IQueryable<EmployeeViewModel> GetMappedEmps();

        [HttpGet]
        IQueryable<DepartmentViewModel> GetMappedDepts();

        [HttpGet]
        EmployeeViewModel GetMappedEmpById(int id);

        [HttpGet]
        EmployeeViewModel GetMappedEmpByName(string name);

        [HttpPost]
        void PostMappedEmp(EmployeeViewModel emp);

        [HttpPut]
        void PutMappedEmp(EmployeeViewModel emp);

        [HttpDelete]
        void DeleteMappedEmp(EmployeeViewModel emp);
    }
}