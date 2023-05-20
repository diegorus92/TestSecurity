using EmployeeManager_BL.Dtos;
using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Services
{
    public interface IRolService
    {
        public void AddRol(RolDTO rol);
        public ICollection<RolDTO> GetRoles();
        public RolDTO? GetRolById(long id);
        public Rol? GetRolByName(string name);
        public void UpdateRol(long id,  RolDTO rol);
        public void DeleteRol(long id);
    }
}
