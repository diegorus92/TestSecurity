using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Dtos
{
    public class UserDTO
    {
        public string Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        //Asignar variable long para agregar rol inicial
    }
}
