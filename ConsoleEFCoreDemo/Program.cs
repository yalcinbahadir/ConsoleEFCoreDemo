using ConsoleEFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleEFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                var departments=context.Departments.Include(d => d.Employees).ToList();

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

            Console.ReadLine();
        }
    }
}
