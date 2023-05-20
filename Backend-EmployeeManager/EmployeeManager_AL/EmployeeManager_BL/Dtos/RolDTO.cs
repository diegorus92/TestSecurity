using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Dtos
{
    public class RolDTO
    {
        public string Name { get; set; }



        public RolDTO(string name)
        {
            Name = name;
        }
    }
}
