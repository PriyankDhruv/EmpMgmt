using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmpMgmt.DAO.Entites;
using EmpMgmt.Models.Models;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.DataAccess.Interface;

namespace EmpMgmt.DataAccess.Repository
{
    public class LoginRepository: ILoginRepository
    {
        private GatewayDigitalContext _db = new GatewayDigitalContext();

        [HttpPost]
        public bool IsLoggerDAL(Login Lg)
        {
            var logger = _db.Employeemaster.Any(x => x.UserName == Lg.UserName && x.Password == Lg.Password);
            return logger;
        }

        [HttpPost]
        public object AddUserDAL(Employeemaster master, Registration reg)
        {
            master.UserName = reg.UserName;
            master.Email = reg.Email;
            master.Password = reg.Password;
            master.ContactNo = reg.ContactNo;
            master.Address = reg.Address;
            master.IsApporved = reg.IsApporved;
            master.Status = reg.Status;

            if (IsEmailAlreadyExistsDAL(reg.Email))
            {
                return new Response
                {
                    Status = "Failure",
                    Message = "Email already Exists!"
                };
            }
            else
            {
                _db.Employeemaster.Add(master);
                _db.SaveChanges();
                return new Response
                {
                    Status = "Success",
                    Message = "SuccessFully Saved"
                };
            }

        }

        [HttpPost]
        public bool IsEmailAlreadyExistsDAL(string email)
        {
            var user = _db.Employeemaster.Any(y => y.Email == email);
            return user;
        }
    }
}