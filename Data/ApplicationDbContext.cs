using Microsoft.EntityFrameworkCore;
using SElab5.Models;

namespace SElab5.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Hearing> Hearings { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships if needed
            // For example, Hearing has two Users (Citizen and Employee)
            modelBuilder.Entity<Hearing>()
                .HasOne(h => h.Citizen)
                .WithMany()
                .HasForeignKey(h => h.CitizenID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Hearing>()
                .HasOne(h => h.Employee)
                .WithMany()
                .HasForeignKey(h => h.EmployeeID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

