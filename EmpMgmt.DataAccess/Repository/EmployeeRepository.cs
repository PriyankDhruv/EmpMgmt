using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmpMgmt.DAO.Entites;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.DataAccess.Interface;

namespace EmpMgmt.DataAccess.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private GatewayDigitalContext _db = new GatewayDigitalContext();

        [HttpGet]
        public IQueryable<Employee> GetEmpsDAL()
        {
            return _db.Employees;
        }

        [HttpGet]
        public IQueryable<Department> GetEmpDeptsDAL()
        {
            return _db.Departments;
        }

        [HttpGet]
        public Employee GetEmpByIdDAL(int id)
        {
            var b = _db.Employees.Where(a => a.EmployeeId == id).FirstOrDefault();
            return b;
        }

        [HttpGet]
        public Employee GetEmpByNameDAL(string name)
        {
            var y = _db.Employees.Where(x => x.EmployeeName == name).FirstOrDefault();
            return y;
        }

        [HttpPost]
        public void PostEmpDAL(Employee emp)
        {
            _db.Employees.Add(emp);
            _db.SaveChanges();
        }

        [HttpPut]
        public void PutEmpDAL(Employee emp)
        {
            var objEmp = new Employee();
            objEmp = _db.Employees.Find(emp.EmployeeId);
            if (objEmp != null)
            {
                objEmp.EmployeeName = emp.EmployeeName;
                objEmp.Department = emp.Department;
                objEmp.MailId = emp.MailId;
                objEmp.Doj = emp.Doj;
                objEmp.Address = emp.Address;
                objEmp.Phone = emp.Phone;
                objEmp.Salary = emp.Salary;
                objEmp.Age = emp.Age;
                _db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteEmpDAL(Employee emp)
        {
            var y = (from x in _db.Employees
                     where x.EmployeeName == emp.EmployeeName
                     select x).FirstOrDefault();
            _db.Employees.Remove(y);
            _db.SaveChanges();
        }
    }
}