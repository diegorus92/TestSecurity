using EmployeeManager_BL.Dtos;
using EmployeeManager_BL.Services;
using EmployeeManager_DAL.Data;
using EmployeeManager_DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography;
using System.Text;

namespace EmployeeManager_AL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase //AuthController aka AccountController
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ITokenService _tokenService;

        public AuthController(EmployeeContext employeeContext, ITokenService tokenService)
        {
            _employeeContext = employeeContext;
            _tokenService = tokenService;
        }

        //PASSWORD TO TEST: "123"    EMAIL: manolo23@hotmail.com    ROL: Admin
        //PASSWORD TO TEST: "123"   EMAIL: juancho23@gmail.com      ROL: Supervisor

        //Register
        [HttpPost("register")]
        public ActionResult<UserResponseDTO> Register(UserRegisterDTO userReg)
        {
            //Check if user alredy exist in DB
            var user = _employeeContext.Users.FirstOrDefault(u => u.Email == userReg.Username);

            if (user != null)
                return BadRequest("This User already exist");

            //Check the repeated Password
            if (userReg.Password != userReg.RepetedPassword)
                return BadRequest("The passsword and repeated password must be equals");

            //Everithing it's ok, so now going to register de new user
            var hmac = new HMACSHA512();

            Rol? rol = _employeeContext.Roles.FirstOrDefault(rol => userReg.Rol == rol.Name);
            if (rol == null)
                return BadRequest("Role doesnt exist");

            User newUser = new User() {
                UserId = 0,
                Email = userReg.Username,
                //Encrypt Password
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userReg.Password)),
                PasswordSalt = hmac.Key,
                Roles = new List<Rol>(),
                Employees = new List<Employee>()
            };
            
            newUser.Roles.Add(rol);
            rol.Users.Add(newUser);

            _employeeContext.Users.Add(newUser);
            _employeeContext.Roles.Update(rol);
            _employeeContext.SaveChanges();

            return Ok(new UserResponseDTO() { Username = newUser.Email });
        }




        //Login
        [HttpPost("login")]
        public ActionResult<UserResponseDTO> Login(LoginDTO loginDto)
        {
            //Check if user exist into DB
            User? user = _employeeContext.Users.FirstOrDefault(user => user.Email == loginDto.Username);

            if (user == null)
                return BadRequest("Invalid Credentials");

            _employeeContext.Entry(user).Collection(user => user.Roles).Load();//If User exist, Load his Roles

            //If user exist, bring it bacck and compare the password like byte array
            var hmac = new HMACSHA512(user.PasswordSalt);
            var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            if (!computedPass.SequenceEqual(user.PasswordHash))
                return Unauthorized("Invalid credentials");

            string token = _tokenService.createToken(user);
            return Ok(new UserResponseDTO() { Username = user.Email, Token = token});
        }
    }
}
