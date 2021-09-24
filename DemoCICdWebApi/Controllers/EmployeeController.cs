using BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCICdWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeBL<Employee> employeeBL;

        public EmployeeController(IEmployeeBL<Employee> employeeBL)
        {
            this.employeeBL = employeeBL;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Employee> employees = employeeBL.GetAll();
            return Ok(employees);
        }
        // GET: api/Employee/5
        [HttpGet("{id}", Name = "GetEmployee")]
        public IActionResult Get(long id)
        {
            Employee employee = employeeBL.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            return Ok(employee);
        }
        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }
            if(employeeBL.Add(employee))
            {
                return Ok(new { success = true, Message= "Post employee successful" });
            }
            else
            {
                return BadRequest(new { success = false, Message = "Post employee unsuccessful" });
            }
        }
        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }
            Employee employeeToUpdate = employeeBL.Get(id);
            if (employeeToUpdate == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            if (employeeBL.Update(employeeToUpdate, employee))
            {
                return Ok(new { success = true, Message = "put employee successful" });
            }
            else
            {
                return BadRequest(new { success = false, Message = "put employee unsuccessful" });
            }
            return NoContent();
        }
        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Employee employee = employeeBL.Get(id);
            if (employee == null)
            {
                return NotFound("The Employee record couldn't be found.");
            }
            employeeBL.Delete(employee);
            return NoContent();
        }
    }
}
