using CrudProjectWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProjectWebAPI.Controllers.DAL
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Product> Products { get; set; }
        public DbSet<Employee> tblEmployee { get; set; }
        public DbSet<EmployeeAttendance> tblEmployeeAttendance { get; set; }
        

    }
}
