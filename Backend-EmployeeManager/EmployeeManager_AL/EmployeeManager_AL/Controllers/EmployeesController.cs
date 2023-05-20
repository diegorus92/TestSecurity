using EmployeeManager_BL.Dtos;
using EmployeeManager_BL.Services;
using EmployeeManager_DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManager_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }




        // GET: api/<EmployeesController>
        [HttpGet, Authorize(Roles = "Admin, Supervisor")] //Admin and Supervisor
        public ActionResult<ICollection<Employee>> Get()
        {
            ICollection<Employee> employees = _employeeService.GetEmployees();
            return Ok(employees);
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{id}"),Authorize(Roles = "Admin, Supervisor")] //Admin and Supervisor
        public ActionResult<Employee> Get(long id)
        {
            Employee? employee = _employeeService.GetEmployee(id);
            if(employee == null) return NotFound();
            return Ok(employee);
        }

        // POST api/<EmployeesController>
        [HttpPost, Authorize(Roles = "Admin")] //Only Admin
        public ActionResult<string> Post([FromBody] EmployeeDTO employee)
        {
            _employeeService.AddEmployee(employee);
            return Ok("New employee added to DB");
        }

        
        /*
        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
