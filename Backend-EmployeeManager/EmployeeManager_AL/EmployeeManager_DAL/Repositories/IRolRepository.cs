using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Repositories
{
    public interface IRolRepository
    {
        public void AddRol(Rol rol);
        public ICollection<Rol> GetRoles();
        public Rol? GetRolById(long id);
        public Rol? GetRolByName(string name);
        public void UpdateRol(long id, Rol rol);
        public void DeleteRol(long id);
    }
}
