using EmployeeManager_DAL.Data;
using EmployeeManager_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }




        public void AddEmployee(Employee employee)
        {
            _employeeContext.Employees.Add(employee);
            _employeeContext.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }

        public Employee? GetEmployeeById(long id)
        {
            Employee? employee = _employeeContext.Employees.Find(id);
            
            if (employee == null) return null;

            _employeeContext.Entry(employee).Collection(employee => employee.Users).Load();

            return employee;
        }

        public ICollection<Employee> GetEmployees()
        {
            return _employeeContext.Employees.ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeContext.Employees.Update(employee);
            _employeeContext.SaveChanges();
        }
    }
}
