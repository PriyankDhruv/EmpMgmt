using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EmpMgmt.Business.Manager;
using EmpMgmt.Business.Interface;
using EmpMgmt.ViewModels.ViewModels;

namespace EmpMgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDeptManager _deptManager = new DeptManager();

        //public DepartmentController() { }

        public DepartmentController(IDeptManager deptManager)
        {
            _deptManager = deptManager;
        }

        [HttpGet]
        [Route("AllDepartments")]
        public IQueryable<DepartmentViewModel> GetDepartments()
        {
            try
            {
                var depts = _deptManager.GetDeptsBAL();
                return depts;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetDepartmentsById/{DepartmentID}")]
        public ActionResult GetDepartmentById(string DepartmentID)
        {
            var objDept = new DepartmentViewModel();
            int Id = Convert.ToInt32(DepartmentID);
            try
            {
                objDept = _deptManager.GetDeptByIdBAL(Id);
                if (objDept == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objDept);
        }

        [HttpPost]
        [Route("InsertDepartments")]
        public ActionResult PostDepartment(DepartmentViewModel dept)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _deptManager.PostDeptBAL(dept);
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(dept);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("UpdateDepartments")]
        public ActionResult PutDepartment(DepartmentViewModel dept)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _deptManager.PutDeptBAL(dept);
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(dept);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("DeleteDepartments")]
        public ActionResult DeleteDepartment(int id)
        {
            var dept = _deptManager.GetDeptByIdBAL(id);
            if (dept == null)
            {
                return NotFound();
            }
            _deptManager.DeleteDeptBAL(dept);
            return Ok(dept);
        }
    }
}