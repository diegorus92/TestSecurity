using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Models
{
    public class Rol
    {
        public long RolId { get; set; }
        public string Name { get; set; }
        public ICollection<User>? Users { get; set; }

        public Rol()
        {
            Users = new List<User>();
        }
    }
}
