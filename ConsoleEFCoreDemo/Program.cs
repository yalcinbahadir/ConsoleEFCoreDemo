using ConsoleEFCoreDemo.Data;
using ConsoleEFCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleEFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
             ShowDepartmentsAndEmployees();
            //AddEmployee(new Employee() { Name="Test", LastName="Tester", DepartmentId=2 });
            Console.ReadLine();
        }

        private static void AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("Bad request. Employee can not be null.");
                return;
            }
            using (AppDbContext context=new AppDbContext())
            {

                context.Employees.Add(employee);
                var isAdded = context.SaveChanges() > 0;
                if (isAdded)
                {
                    Console.WriteLine($"Employee {employee.Name} {employee.LastName} was successfully recorded.");
                }
                else
                {
                    Console.WriteLine($"Employee is not recorded.");
                }
               
            }
        }

        private static void ShowDepartmentsAndEmployees()
        {
            using (var context = new AppDbContext())
            {
                var departments = context.Departments.Include(d => d.Employees).ToList();

                foreach (var department in departments)
                {
                    Console.WriteLine($"Departments");
                    Console.WriteLine($"ID- {department.DepartmentId} Name - {department.Name}");
                    Console.WriteLine($"Employees");
                    if (department.Employees.Any())
                    {
                        foreach (var employee in department.Employees)
                        {
                            Console.WriteLine($"ID- {employee.Id} Name - {employee.Name} {employee.LastName}");
                        }

                    }
                }
            }
        }
    }
}
