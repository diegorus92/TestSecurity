using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public ICollection<Rol>? Roles { get; set; } = new List<Rol>();
        public ICollection<Employee>? Employees { get; set; } = new List<Employee>();
    }
}
