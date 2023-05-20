using EmployeeManager_DAL.Data;
using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly EmployeeContext _employeeContext;

        public UserRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }


        public void AddUser(User user)
        {
            _employeeContext.Users.Add(user);
            _employeeContext.SaveChanges();
        }

        public void DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public User? GetUserById(long id)
        {
            User? user = _employeeContext.Users.Find(id);
            if (user == null)
                return null;

            _employeeContext.Entry(user).Collection(user => user.Roles).Load();
            _employeeContext.Entry(user).Collection(user => user.Employees).Load();

            return user;
        }

        public ICollection<User> GetUsers()
        {
            return _employeeContext.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _employeeContext.Users.Update(user);
            _employeeContext.SaveChanges();
        }
    }
}
