using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.Business.Interface
{
    public interface IDeptManager
    {
        [HttpGet]
        IQueryable<DepartmentViewModel> GetDeptsBAL();

        [HttpGet]
        DepartmentViewModel GetDeptByIdBAL(int id);

        [HttpGet]
        DepartmentViewModel GetDeptByNameBAL(string name);

        [HttpPost]
        void PostDeptBAL(DepartmentViewModel dept);

        [HttpPut]
        void PutDeptBAL(DepartmentViewModel dept);

        [HttpDelete]
        void DeleteDeptBAL(DepartmentViewModel dept);
    }
}