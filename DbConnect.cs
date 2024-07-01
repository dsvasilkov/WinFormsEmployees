
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
namespace EmployeeFormsApp
{
    public class DbConnect : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public DbSet <PositionInfo> PositionInfos { get; set; }
        public DbSet<Position > Positions { get; set; }
        public DbSet<Education> Educations {  get; set; } 

        public DbConnect()
        {   
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=emloyees;Username=postgres;Password=admin");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Branch>().ToTable("branches");
            modelBuilder.Entity<Department>().ToTable("departments");
            modelBuilder.Entity<PositionInfo>().ToTable("positioninfos");
            modelBuilder.Entity<Position>().ToTable("positions");
            modelBuilder.Entity<Education>().ToTable("educations");
        }
    }
}
