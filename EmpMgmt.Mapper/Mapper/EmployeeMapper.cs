using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmpMgmt.DAO.Entites;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.Mapper.Interface;
using EmpMgmt.DataAccess.Interface;
using EmpMgmt.DataAccess.Repository;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.Mapper.Mapper
{
    public class EmployeeMapper: IEmployeeMapper
    {
        private IEmployeeRepository _empRepository = new EmployeeRepository();

        public EmployeeMapper() { }

        public EmployeeMapper(IEmployeeRepository empRepository)
        {
            _empRepository = empRepository;
        }

        [HttpGet]
        public IQueryable<EmployeeViewModel> GetMappedEmps()
        {
            var emps = _empRepository.GetEmpsDAL();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<IQueryable<Employee>, IList<EmployeeViewModel>>(emps);
            return dest.AsQueryable();
        }

        [HttpGet]
        public IQueryable<DepartmentViewModel> GetMappedDepts()
        {
            var depts = _empRepository.GetEmpDeptsDAL();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<IQueryable<Department>, IList<DepartmentViewModel>>(depts);
            return dest.AsQueryable();
        }

        [HttpGet]
        public EmployeeViewModel GetMappedEmpById(int id)
        {
            var emp = _empRepository.GetEmpByIdDAL(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<Employee, EmployeeViewModel>(emp);
            return dest;
        }

        [HttpGet]
        public EmployeeViewModel GetMappedEmpByName(string name)
        {
            var emp = _empRepository.GetEmpByNameDAL(name);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Employee, EmployeeViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<Employee, EmployeeViewModel>(emp);
            return dest;
        }

        [HttpPost]
        public void PostMappedEmp(EmployeeViewModel emp)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeViewModel, Employee>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<EmployeeViewModel, Employee>(emp);

            _empRepository.PostEmpDAL(dest);
        }

        [HttpPut]
        public void PutMappedEmp(EmployeeViewModel emp)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeViewModel, Employee>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<EmployeeViewModel, Employee>(emp);
            _empRepository.PutEmpDAL(dest);
        }

        [HttpDelete]
        public void DeleteMappedEmp(EmployeeViewModel emp)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeeViewModel, Employee>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<EmployeeViewModel, Employee>(emp);
            _empRepository.DeleteEmpDAL(dest);
        }
    }
}