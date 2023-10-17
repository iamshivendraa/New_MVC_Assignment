using Assignment.Models;
using Microsoft.EntityFrameworkCore;
using NewProject.Models;

namespace Assignment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AccountModel> Accounts { get; set; }

        public DbSet<UserModelDictionary> Users { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        
        public DbSet<EmployeeViewModel> Employees { get; set; }


    }
}
