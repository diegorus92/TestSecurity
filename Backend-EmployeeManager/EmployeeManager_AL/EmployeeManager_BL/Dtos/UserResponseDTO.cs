using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Dtos
{
    public class UserResponseDTO
    {
        public string Username { get; set; } //The user email
        public string? Token { get; set; }
    }
}
