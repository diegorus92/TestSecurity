using EmployeeManager_DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        public string createToken(User user)
        {
            
            string rolUser = user.Roles.FirstOrDefault() != null ? user.Roles.First().Name : "Default";
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, rolUser)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
