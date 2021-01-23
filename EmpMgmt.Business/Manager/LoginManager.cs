using System;
using System.Collections.Generic;
using System.Text;
using EmpMgmt.Models.Models;
using EmpMgmt.Mapper.Mapper;
using EmpMgmt.Mapper.Interface;
using EmpMgmt.Business.Interface;
using EmpMgmt.ViewModels.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.Business.Manager
{
    public class LoginManager: ILoginManager
    {
        private ILoginMapper _loginMapper = new LoginMapper(); 

        public LoginManager() { }

        public LoginManager(ILoginMapper loginMapper)
        {
            _loginMapper = loginMapper;
        }

        [HttpPost]
        public bool IsLoggerBAL(LoginViewModel Lg)
        {
            return _loginMapper.IsMappedLogger(Lg);
        }

        [HttpPost]
        public object AddUserBAL(EmployeemasterViewModel master, Registration reg)
        {
            return _loginMapper.AddMappedUser(master, reg);
        }

        [HttpPost]
        public bool IsEmailAlreadyExistsBAL(string email)
        {
            return _loginMapper.IsMappedEmailAlreadyExists(email);
        }
    }
}