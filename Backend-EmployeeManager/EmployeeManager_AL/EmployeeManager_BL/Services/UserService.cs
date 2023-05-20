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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        public void AddUser(UserDTO user)
        {
            User newUser = new User()
            {
                UserId = 0,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt,
                Roles = null,
                Employees = null
            };

            _userRepository.AddUser(newUser);
        }

        public void DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public User? GetUserById(long id)
        {
            return _userRepository.GetUserById(id);
        }

        public ICollection<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void UpdateUser(long id, UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}
