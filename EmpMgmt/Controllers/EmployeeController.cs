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
    public class EmployeeController : ControllerBase
    {
        private IEmpManager _empManager = new EmpManager();

        //public EmployeeController() { }

        public EmployeeController(IEmpManager empManager)
        {
            _empManager = empManager;
        }

        [HttpGet]
        [Route("AllEmployees")]
        public IQueryable<EmployeeViewModel> GetEmployees()
        {
            try
            {
                return _empManager.GetEmpsBAL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("Department")]
        public IQueryable<DepartmentViewModel> GetDepartments()
        {
            try
            {
                return _empManager.GetEmpDeptsBAL();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("GetEmployeesById/{employeeId}")]
        public ActionResult GetEmployeeById(string employeeId)
        {
            var objEmp = new EmployeeViewModel();
            int Id = Convert.ToInt32(employeeId);
            try
            {
                objEmp = _empManager.GetEmpByIdBAL(Id);
                if (objEmp == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(objEmp);
        }

        [HttpPost]
        [Route("InsertEmployees")]
        public ActionResult PostEmployee(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _empManager.PostEmpBAL(emp);
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(emp);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut]
        [Route("UpdateEmployees")]
        public ActionResult PutEmployee(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _empManager.PutEmpBAL(emp);
                }
                catch (Exception)
                {
                    throw;
                }
                return Ok(emp);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployees")]
        public ActionResult DeleteEmployee(int id)
        {
            var emp = _empManager.GetEmpByIdBAL(id);
            if (emp == null)
            {
                return NotFound();
            }
            _empManager.DeleteEmpBAL(emp);
            return Ok(emp);
        }
    }
}