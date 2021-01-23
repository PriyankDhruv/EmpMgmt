using System;
using Xunit;
using System.Linq;
using EmpMgmt.Business.Interface;
using EmpMgmt.Business.Manager;
using EmpMgmt.ViewModels.ViewModels;
using System.Threading;

namespace EmpMgmt.UnitTest
{
    [TestCaseOrderer("EmpMgmt.UnitTest.PriorityOrderer", "EmpMgmt.UnitTest")]
    public class DeptTest
    {
        private IDeptManager _deptManager = new DeptManager();

        [Fact, TestPriority(0)]
        public void TestGetDepts()
        { 
            var depts = _deptManager.GetDeptsBAL();
            Assert.IsAssignableFrom<IQueryable<DepartmentViewModel>>(depts);
            Assert.NotNull(depts);
        }

        [Fact, TestPriority(1)]
        public void TestGetDeptById()
        {
            var deptName = "Gateway Digital";
            var dept = _deptManager.GetDeptByIdBAL(20019);
            Assert.Equal(deptName, dept.DepartmentName);
        }

        [Fact, TestPriority(2)]
        public void TestCreateDept()
        {
            var dept = new DepartmentViewModel
            {
                DepartmentName = "TecBridge"
            };

            _deptManager.PostDeptBAL(dept);

            var x = _deptManager.GetDeptByNameBAL(dept.DepartmentName);
            Assert.Equal(dept.DepartmentName, x.DepartmentName);
        }

        [Fact, TestPriority(3)]
        public void TestDeleteDept()
        {
            var deptName = "TecBridge";
            var dept = _deptManager.GetDeptByNameBAL(deptName);

            _deptManager.DeleteDeptBAL(dept);

            var deptX = _deptManager.GetDeptByNameBAL(deptName);
            Assert.Null(deptX);
        }

        [Fact, TestPriority(4)]
        public void TestUpdtedDept()
        {
            var dept = _deptManager.GetDeptByIdBAL(20004);

            dept.DepartmentName = "Yemo";
            _deptManager.PutDeptBAL(dept);

            dept.DepartmentName = "DILX";
            _deptManager.PutDeptBAL(dept);

            Assert.Equal("DILX", dept.DepartmentName);
        }
    }
}