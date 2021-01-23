using System;
using Xunit;
using System.Linq;
using EmpMgmt.Business.Interface;
using EmpMgmt.Business.Manager;
using EmpMgmt.ViewModels.ViewModels;
using System.Threading;

namespace EmpMgmt.UnitTest
{
    public class EmpTest
    {
        private IEmpManager _empManager = new EmpManager();

        [Fact]
        public void TestGetEmps()
        {
            var emps = _empManager.GetEmpsBAL();
            Assert.IsAssignableFrom<IQueryable<EmployeeViewModel>>(emps);
            Assert.NotNull(emps);
        }

        [Fact]
        public void TestGetEmpDepts()
        {
            var depts = _empManager.GetEmpDeptsBAL();
            Assert.IsAssignableFrom<IQueryable<DepartmentViewModel>>(depts);
            Assert.NotNull(depts);
        }

        [Fact]
        public void TestGetEmpById()
        {
            var empName = "Abhijeet Trivedi";
            var emp = _empManager.GetEmpByIdBAL(20008);
            Assert.Equal(empName, emp.EmployeeName);
        }

        [Fact]
        public void TestCreateEmp()
        {
            var emp = new EmployeeViewModel
            {
                EmployeeName = "Hemant.Mohapatra",
                Department = "Autofacets",
                MailId = "hemant.mohapatra@thegatewaycorp.com",
                Doj = Convert.ToDateTime("2020-10-10 18:30:00.000"),
                Phone = 8900366424,
                Address = "02, 3-Prahladnagar Society, Dr. Yagnik Rd, Surat-394105",
                Salary = 32000,
                Age = 23
            };

            _empManager.PostEmpBAL(emp);

            var x = _empManager.GetEmpByNameBAL(emp.EmployeeName);
            Assert.Equal(emp.EmployeeName, x.EmployeeName);

        }

        [Fact]
        public void TestDeleteEmp()
        {
            var empName = "Hemant.Mohapatra";
            var emp = _empManager.GetEmpByNameBAL(empName);

            _empManager.DeleteEmpBAL(emp);

            var empX = _empManager.GetEmpByNameBAL(empName);
            Assert.Null(empX);
        }

        [Fact]
        public void TestUpdateEmp()
        {
            var emp = _empManager.GetEmpByIdBAL(20008);

            emp.Department = "AutoDAP";
            _empManager.PutEmpBAL(emp);

            emp.Department = "Autofacets";
            _empManager.PutEmpBAL(emp);

            Assert.Equal("Autofacets", emp.Department);
        }
    }
}