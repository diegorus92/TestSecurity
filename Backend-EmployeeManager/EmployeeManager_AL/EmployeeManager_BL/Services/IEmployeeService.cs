using EmployeeManager_BL.Dtos;
using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_BL.Services
{
    public interface IEmployeeService
    {
        public void AddEmployee(EmployeeDTO employee);
        public ICollection<Employee> GetEmployees();
        public Employee? GetEmployee(long id);
        public void UpdateEmployee(long id, EmployeeDTO employee);
        public void DeleteEmployee(long id);
    }
}
