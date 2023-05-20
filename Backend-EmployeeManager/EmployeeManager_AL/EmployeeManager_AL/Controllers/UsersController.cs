using EmployeeManager_BL.Dtos;
using EmployeeManager_BL.Services;
using EmployeeManager_DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManager_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        // GET: api/<UsersController>
        [HttpGet]
        public ActionResult<ICollection<User>> Get()
        {
            ICollection<User> users = _userService.GetUsers();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(long id)
        {
            User? user = _userService.GetUserById(id);
            if (user == null)
                return BadRequest("User not found");
            return Ok(user);
        }


        /*Post endpoint shoul'd deleted in the future, 
         * because we're going to do the User Post trough Register in AuthController
         */
        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<string> Post([FromBody] UserDTO user)
        {
            _userService.AddUser(user);
            return Ok("New user added into DB");
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
