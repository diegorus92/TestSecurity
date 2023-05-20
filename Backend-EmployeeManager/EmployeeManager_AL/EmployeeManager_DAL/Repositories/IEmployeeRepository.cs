using EmployeeManager_DAL.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Repositories
{
    public interface IEmployeeRepository
    {
        public void AddEmployee(Employee employee);
        public ICollection<Employee> GetEmployees();
        public Employee? GetEmployeeById(long id);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(Employee employee);
    }
}
