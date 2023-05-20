using EmployeeManager_BL.Dtos;
using EmployeeManager_BL.Services;
using EmployeeManager_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManager_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IRolService _rolService;

        public RolesController(IRolService rolService)
        {
            _rolService = rolService;
        }





        // GET: api/<RolesController>
        [HttpGet]
        public ActionResult<ICollection<RolDTO>> Get()
        {
            ICollection<RolDTO> roles = _rolService.GetRoles();   

            return Ok(roles);
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //GET api/<RolesController/name/name>
        [HttpGet("name/{name}")]
        public ActionResult<Rol> Get(string name)
        {
            Rol? rol = _rolService.GetRolByName(name);

            if (rol == null)
                return NotFound();
            return Ok(rol);
        } 

        // POST api/<RolesController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] RolDTO rol)
        {
            _rolService.AddRol(rol);
            return Ok("new Rol added into DB");
        }

        // PUT api/<RolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
