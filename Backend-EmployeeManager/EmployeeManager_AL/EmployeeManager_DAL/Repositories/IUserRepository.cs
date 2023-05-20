using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Repositories
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public ICollection<User> GetUsers();
        public User? GetUserById(long id);
        public void UpdateUser(User user);
        public void DeleteUser(long id);
    }
}
