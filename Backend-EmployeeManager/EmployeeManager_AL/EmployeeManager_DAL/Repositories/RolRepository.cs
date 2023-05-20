using EmployeeManager_DAL.Data;
using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly EmployeeContext _employeeContext;

        public RolRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }





        public void AddRol(Rol rol)
        {
            _employeeContext.Roles.Add(rol);
            _employeeContext.SaveChanges();
        }

        public void DeleteRol(long id)
        {
            throw new NotImplementedException();
        }

        public Rol? GetRolById(long id)
        {
            throw new NotImplementedException();
        }

        public Rol? GetRolByName(string name)
        {
            Rol? rol = _employeeContext.Roles.FirstOrDefault(r => r.Name.ToLower() == name.ToLower());
            if (rol == null)
                return null;

            _employeeContext.Entry(rol).Collection(rol => rol.Users).Load();

            return rol;
        }

        public ICollection<Rol> GetRoles()
        {
            return _employeeContext.Roles.ToList();
        }

        public void UpdateRol(long id, Rol rol)
        {
            throw new NotImplementedException();
        }
    }
}
