using EmployeeManager_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManager_DAL.Data
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) 
        { 
        
        }

        //Entities
        public virtual DbSet<Rol>Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(options => options.EnableRetryOnFailure());
        }
    }
}
