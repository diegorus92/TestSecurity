using EmployeeManager_BL.Dtos;
using EmployeeManager_DAL.Models;
using EmployeeManager_DAL.Repositories;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUserRepository _userRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IUserRepository userRepository)
        {
            _employeeRepository = employeeRepository;
            _userRepository = userRepository;
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            User? user = _userRepository.GetUserById(employee.UserId);
            if (user == null) return;

            Employee newEmployee = new Employee()
            {
                EmployeeId = 0,
                Name = employee.Name,
                Surname = employee.Surname,
                ProfileImage = new byte[0],
                Dni = employee.Dni,
                Area = employee.Area,
                Salary = employee.Salary
            };
            
            newEmployee.Users.Add(user);
            user.Employees.Add(newEmployee);
            
            _employeeRepository.AddEmployee(newEmployee);
            _userRepository.UpdateUser(user);
        }

        public void DeleteEmployee(long id)
        {
            throw new NotImplementedException();
        }

        public Employee? GetEmployee(long id)
        {
            Employee? employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null) return null;
            return employee;
        }

        public ICollection<Employee> GetEmployees()
        {
            return _employeeRepository.GetEmployees();
        }

        public void UpdateEmployee(long id, EmployeeDTO employee)
        {
            throw new NotImplementedException();
        }
    }
}
