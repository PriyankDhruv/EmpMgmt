using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmpMgmt.Mapper.Mapper;
using EmpMgmt.Mapper.Interface;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.Business.Interface;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.Business.Manager
{
    public class EmpManager: IEmpManager
    {
        private IEmployeeMapper _empMapper = new EmployeeMapper();

        public EmpManager() { }

        public EmpManager(IEmployeeMapper empMapper)
        {
            _empMapper = empMapper;
        }

        [HttpGet]
        public IQueryable<EmployeeViewModel> GetEmpsBAL()
        {
            return _empMapper.GetMappedEmps();
        }

        [HttpGet]
        public IQueryable<DepartmentViewModel> GetEmpDeptsBAL()
        {
            return _empMapper.GetMappedDepts();
        }

        [HttpGet]
        public EmployeeViewModel GetEmpByIdBAL(int id)
        {
            return _empMapper.GetMappedEmpById(id);
        }

        [HttpGet]
        public EmployeeViewModel GetEmpByNameBAL(string name)
        {
            return _empMapper.GetMappedEmpByName(name);
        }

        [HttpPost]
        public void PostEmpBAL(EmployeeViewModel emp)
        {
            _empMapper.PostMappedEmp(emp);
        }

        [HttpPut]
        public void PutEmpBAL(EmployeeViewModel emp)
        {
            _empMapper.PutMappedEmp(emp);
        }

        [HttpDelete]
        public void DeleteEmpBAL(EmployeeViewModel emp)
        {
            _empMapper.DeleteMappedEmp(emp);
        }
    }
}