using System;
using System.Linq;
using System.Text;
using EmpMgmt.DAO.Entites;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmpMgmt.DataAccess.Interface;

namespace EmpMgmt.DataAccess.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        private GatewayDigitalContext _db = new GatewayDigitalContext();

        [HttpGet]
        public IQueryable<Department> GetDeptsDAL()
        {
            return _db.Departments;
        }

        [HttpGet]
        public Department GetDeptByIdDAL(int id)
        {
            var y = _db.Departments
                    .Where(x => Convert.ToInt32(x.DepartmentId) == id)
                    .FirstOrDefault();
            return y;
        }

        [HttpGet]
        public Department GetDeptByNameDAL(string name)
        {
            var y = _db.Departments.Where(x => x.DepartmentName == name).FirstOrDefault();
            return y;
        }

        [HttpPost]
        public void PostDeptDAL(Department dept)
        {
            _db.Departments.Add(dept);
            _db.SaveChanges();
        }

        [HttpPut]
        public void PutDeptDAL(Department dept)
        {
            var objDept = GetDeptByIdDAL(Convert.ToInt32(dept.DepartmentId));
            if (objDept != null)
            {
                objDept.DepartmentName = dept.DepartmentName;
                _db.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteDeptDAL(Department dept)
        {
            var y = (from x in _db.Departments
                     where x.DepartmentName == dept.DepartmentName
                     select x).FirstOrDefault();
            _db.Departments.Remove(y);
            _db.SaveChanges();
        }
    }
}