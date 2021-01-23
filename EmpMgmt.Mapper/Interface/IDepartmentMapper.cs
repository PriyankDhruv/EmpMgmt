using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.Mapper.Interface
{
    public interface IDepartmentMapper
    {
        [HttpGet]
        IQueryable<DepartmentViewModel> GetMappedDepts();

        [HttpGet]
        DepartmentViewModel GetMappedDeptById(int id);

        [HttpGet]
        DepartmentViewModel GetMappedDeptByName(string name);

        [HttpPost]
        void PostMappedDept(DepartmentViewModel dept);

        [HttpPut]
        void PutMappedDept(DepartmentViewModel dept);

        [HttpDelete]
        void DeleteMappedDept(DepartmentViewModel dept);
    }
}