using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmpMgmt.Models.Models;
using EmpMgmt.ViewModels.ViewModels;
using EmpMgmt.Business.Manager;
using EmpMgmt.Business.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmpMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginManager _loginManager = new LoginManager();

        //public LoginController() { }

        public LoginController(ILoginManager loginManager)
        {
            _loginManager = loginManager;
        }

        [HttpPost]
        [Route("UserLogin")]
        public Response Login(LoginViewModel Lg)
        {
            var IsValidUser = _loginManager.IsLoggerBAL(Lg);
            if (IsValidUser)
            {
                return new Response
                {
                    Status = "Success",
                    Message = Lg.UserName
                };
            }
            else
            {
                return new Response
                {
                    Status = "Invalid",
                    Message = "Invalid User"
                };
            }
        }

        [HttpPost]
        [Route("UserRegistration")]
        public object CreateUser(Registration reg)
        {
            var master = new EmployeemasterViewModel();
            if (master.UserId == 0)
            {
                return _loginManager.AddUserBAL(master, reg);
            }
            else
            {
                return new Response
                {
                    Status = "Error",
                    Message = "Invalid Data."
                };
            }
        }
    }
}