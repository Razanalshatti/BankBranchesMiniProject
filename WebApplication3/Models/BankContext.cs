//using Microsoft.EntityFrameworkCore;

//namespace WebApplication3.Models
//{
//    public class BankContext : DbContext
//    {

//        // DbSet for BankBranch
//        public DbSet<BankBranch> BankBranches { get; set; }

//        //DbSet for Employee
//        public DbSet<Employee> Employees { get; set; }
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                optionsBuilder.UseSqlite("Data Source=blog.db");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Employee>()
//                .HasIndex(e => e.civilId)
//                .IsUnique();
//        }
//    }


//}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata;

namespace WebApplication3.Models
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankBranch>().HasData(
                new BankBranch
                {
                    Id = 1,
                    location = "Alshamyia",
                    branchManager = "Abdulrahman",
                    employeeCount = 7,
                    locationURL = "https://maps.app.goo.gl/k5DD4wvKX38Y6RFQ7"
                }
            );
        }

        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
