using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte[]? ProfileImage { get; set; }
        public string Dni { get; set; }
        public string Area { get; set;}
        public double Salary { get; set;}
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
