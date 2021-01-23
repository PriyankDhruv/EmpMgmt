using System;
using System.Linq;
using System.Text;
using EmpMgmt.DAO.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmpMgmt.DataAccess.Interface
{
    public interface IDepartmentRepository
    {
        [HttpGet]
        IQueryable<Department> GetDeptsDAL();

        [HttpGet]
        Department GetDeptByIdDAL(int id);

        [HttpGet]
        Department GetDeptByNameDAL(string name);

        [HttpPost]
        void PostDeptDAL(Department dept);

        [HttpPut]
        void PutDeptDAL(Department dept);

        [HttpDelete]
        void DeleteDeptDAL(Department dept);
    }
}