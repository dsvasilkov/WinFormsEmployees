
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        public DbSet<TableEmployee> TableEmployee { get; set; }

        public DbConnect()
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=employees;Username=postgres;Password=root");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("employees");
            modelBuilder.Entity<Branch>().ToTable("branches");
            modelBuilder.Entity<Department>().ToTable("departments");
            modelBuilder.Entity<PositionInfo>().ToTable("positioninfos");
            modelBuilder.Entity<Position>().ToTable("positions");
            modelBuilder.Entity<Education>().ToTable("educations");

            modelBuilder.Entity<Employee>()
               .HasOne(e => e.Branch)
               .WithMany(b => b.Employees)
               .HasForeignKey(e => e.BranchId)
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired(false);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            modelBuilder.Entity<PositionInfo>()
                .HasOne(pi => pi.Employee)
                .WithMany(e => e.PositionInfos)
                .HasForeignKey(pi => pi.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PositionInfo>()
                .HasOne(pi => pi.Position)
                .WithMany(p => p.PositionInfos)
                .HasForeignKey(pi => pi.PositionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Education>()
                .HasOne(ed => ed.Employee)
                .WithOne(e => e.Education)
                .HasForeignKey<Education>(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
           
        
        }
     
    }
    
}
