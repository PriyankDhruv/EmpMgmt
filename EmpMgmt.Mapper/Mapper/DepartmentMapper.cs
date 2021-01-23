using System;
using AutoMapper;
using System.Linq;
using System.Text;
using EmpMgmt.DAO.Entites;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.Mapper.Interface;
using System.Collections.Generic;
using EmpMgmt.ViewModels.ViewModels;
using EmpMgmt.DataAccess.Interface;
using EmpMgmt.DataAccess.Repository;

namespace EmpMgmt.Mapper.Mapper
{
    public class DepartmentMapper: IDepartmentMapper
    {
        private IDepartmentRepository _deptRepository = new DepartmentRepository();

        public DepartmentMapper() { }

        public DepartmentMapper(IDepartmentRepository departmentRepository)
        {
            _deptRepository = departmentRepository;
        }

        [HttpGet]
        public IQueryable<DepartmentViewModel> GetMappedDepts()
        {
            var depts = _deptRepository.GetDeptsDAL();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<IQueryable<Department>, IList<DepartmentViewModel>>(depts);
            return dest.AsQueryable();
        }

        [HttpGet]
        public DepartmentViewModel GetMappedDeptById(int id)
        {
            var dept = _deptRepository.GetDeptByIdDAL(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<Department, DepartmentViewModel>(dept);
            return dest;
        }

        [HttpGet]
        public DepartmentViewModel GetMappedDeptByName(string name)
        {
            var dept = _deptRepository.GetDeptByNameDAL(name);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Department, DepartmentViewModel>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<Department, DepartmentViewModel>(dept);
            return dest;
        }

        [HttpPost]
        public void PostMappedDept(DepartmentViewModel dept)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DepartmentViewModel, Department>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<DepartmentViewModel, Department>(dept);
            
            _deptRepository.PostDeptDAL(dest);
        }

        [HttpPut]
        public void PutMappedDept(DepartmentViewModel dept)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DepartmentViewModel, Department>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<DepartmentViewModel, Department>(dept);
            _deptRepository.PutDeptDAL(dest);
        }

        [HttpDelete]
        public void DeleteMappedDept(DepartmentViewModel dept)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DepartmentViewModel, Department>();
            });

            IMapper mapper = config.CreateMapper();

            var dest = mapper.Map<DepartmentViewModel, Department>(dept);
            _deptRepository.DeleteDeptDAL(dest);
        }
    }
}