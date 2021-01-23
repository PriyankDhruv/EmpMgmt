using System;
using Xunit;
using System.Collections.Generic;
using System.Text;
using EmpMgmt.Business.Manager;
using EmpMgmt.Business.Interface;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.UnitTest
{
    public class LoginTest
    {
        private ILoginManager _loginManager = new LoginManager();

        [Fact]
        public void TestIsLogger()
        {
            var Lg = new LoginViewModel
            {
                UserName = "Priyank.Dhruv",
                Password = "M@havir@1998"
            };

            var logger = _loginManager.IsLoggerBAL(Lg);
            Assert.True(logger);
        }

        [Fact]
        public void TestIsEmailAlreadyExists()
        {
            string email = "priyank.dhruv@thegatewaycorp.com";

            var user = _loginManager.IsEmailAlreadyExistsBAL(email);
            Assert.True(user);
        }
    }
}