using EmployeeManager_BL.Dtos;
using EmployeeManager_DAL.Models;
using EmployeeManager_DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Services
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;

        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }




        public void AddRol(RolDTO rol)
        {
            Rol newRol = new Rol()
            {
                RolId = 0,
                Name = rol.Name,
                Users = null
            };

            _rolRepository.AddRol(newRol);
        }

        public void DeleteRol(long id)
        {
            throw new NotImplementedException();
        }

        public RolDTO? GetRolById(long id)
        {
            throw new NotImplementedException();
        }

        public Rol? GetRolByName(string name)
        {
            return _rolRepository.GetRolByName(name);
        }

        public ICollection<RolDTO> GetRoles()
        {
            ICollection<Rol> rolesRecovered = _rolRepository.GetRoles();
            ICollection<RolDTO> rolesDtos = new List<RolDTO>();

            foreach(var rol in rolesRecovered)
            {
                rolesDtos.Add(new RolDTO(rol.Name));
            }

            return rolesDtos;
        }

        public void UpdateRol(long id, RolDTO rol)
        {
            throw new NotImplementedException();
        }
    }
}
