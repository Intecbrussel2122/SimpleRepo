using Microsoft.EntityFrameworkCore;
using SimpleRepo.Models;

namespace SimpleRepo.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCV> EmployeeCVs { get; set; }

    }
}
