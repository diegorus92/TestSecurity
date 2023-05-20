using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Dtos
{
    public class UserRegisterDTO
    {
        public string Username { get; set; } //The user email
        public string Password { get; set; }
        public string RepetedPassword { get; set; }
        public string Rol { get; set; } 
    }
}
