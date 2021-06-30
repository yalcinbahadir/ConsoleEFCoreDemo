using ConsoleEFCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFCoreDemo.Data
{
    public class AppDbContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CoreConsoleDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(new Department() {  DepartmentId=1, Name="IT"});
            modelBuilder.Entity<Department>().HasData(new Department() { DepartmentId = 2, Name = "HR" });

            modelBuilder.Entity<Employee>().HasData(new Employee() {  Id=1, Name = "Ali", LastName="Alper", DepartmentId = 1});
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 2, Name = "Tarik", LastName = "Emre", DepartmentId = 2 });
            modelBuilder.Entity<Employee>().HasData(new Employee() { Id = 3, Name = "Bahadir", LastName = "Yalcin", DepartmentId = 1 });
        }

    }
}
