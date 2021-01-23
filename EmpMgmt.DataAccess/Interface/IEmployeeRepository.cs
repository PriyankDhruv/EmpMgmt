using System;
using System.Linq;
using System.Text;
using EmpMgmt.DAO.Entites;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.DataAccess.Interface
{
    public interface IEmployeeRepository
    {
        [HttpGet]
        IQueryable<Employee> GetEmpsDAL();

        [HttpGet]
        IQueryable<Department> GetEmpDeptsDAL();

        [HttpGet]
        Employee GetEmpByIdDAL(int id);

        [HttpGet]
        Employee GetEmpByNameDAL(string name);

        [HttpPost]
        void PostEmpDAL(Employee emp);

        [HttpPut]
        void PutEmpDAL(Employee emp);

        [HttpDelete]
        void DeleteEmpDAL(Employee emp);
    }
}