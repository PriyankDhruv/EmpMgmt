using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using EmpMgmt.DAO.Entites;
using EmpMgmt.Models.Models;
using EmpMgmt.Mapper.Interface;
using EmpMgmt.DataAccess.Interface;
using EmpMgmt.DataAccess.Repository;
using EmpMgmt.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.Mapper.Mapper
{
    public class LoginMapper: ILoginMapper
    {
        private ILoginRepository _loginRepository = new LoginRepository();

        public LoginMapper() { }

        public LoginMapper(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public bool IsMappedLogger(LoginViewModel Lg)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<LoginViewModel, Login>();
            });

            IMapper mapper = config.CreateMapper();
            var dest = mapper.Map<LoginViewModel, Login>(Lg);
            var logger = _loginRepository.IsLoggerDAL(dest);
            return logger;
        }

        [HttpPost]
        public object AddMappedUser(EmployeemasterViewModel master, Registration reg)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<EmployeemasterViewModel, Employeemaster>();
            });

            IMapper mapper = config.CreateMapper();
            var dest = mapper.Map<EmployeemasterViewModel, Employeemaster>(master);
            var visitor = _loginRepository.AddUserDAL(dest, reg);
            return visitor;
        }

        [HttpPost]
        public bool IsMappedEmailAlreadyExists(string email)
        {
            var user = _loginRepository.IsEmailAlreadyExistsDAL(email);
            return user;
        }
    }
}