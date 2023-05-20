using EmployeeManager_BL.Dtos;
using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Services
{
    public interface IUserService
    {
        public void AddUser(UserDTO user);
        public ICollection<User> GetUsers();
        public User? GetUserById(long id);
        public void UpdateUser(long id, UserDTO user);
        public void DeleteUser(long id);
    }
}
