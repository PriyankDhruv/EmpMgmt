using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.Mapper.Interface;
using EmpMgmt.Mapper.Mapper;
using System.Collections.Generic;
using EmpMgmt.Business.Interface;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.Business.Manager
{
    public class DeptManager: IDeptManager
    {
        private IDepartmentMapper _deptMapper = new DepartmentMapper();

        public DeptManager() { }

        public DeptManager(IDepartmentMapper deptMapper)
        {
            _deptMapper = deptMapper;
        }

        [HttpGet]
        public IQueryable<DepartmentViewModel> GetDeptsBAL()
        {
            return _deptMapper.GetMappedDepts();
        }

        [HttpGet]
        public DepartmentViewModel GetDeptByIdBAL(int id)
        {
            return _deptMapper.GetMappedDeptById(id);
        }

        [HttpGet]
        public DepartmentViewModel GetDeptByNameBAL(string name)
        {
            return _deptMapper.GetMappedDeptByName(name);
        }

        [HttpPost]
        public void PostDeptBAL(DepartmentViewModel dept)
        {
            _deptMapper.PostMappedDept(dept);
        }

        [HttpPut]
        public void PutDeptBAL(DepartmentViewModel dept)
        {
            _deptMapper.PutMappedDept(dept);
        }

        [HttpDelete]
        public void DeleteDeptBAL(DepartmentViewModel dept)
        {
            _deptMapper.DeleteMappedDept(dept);
        }
    }
}