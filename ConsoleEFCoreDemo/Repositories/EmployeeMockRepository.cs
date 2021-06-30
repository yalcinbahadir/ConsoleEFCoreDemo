using ConsoleEFCoreDemo.Data;
using ConsoleEFCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEFCoreDemo.Repositories
{
    public static class EmployeeMockRepository
    {
        public static Employee GetEmployee(int id)
        {
            using (var context = new AppDbContext())
            {
                var employee = context.Employees.Include(e => e.Department).FirstOrDefault(e => e.Id == id);
                if (employee == null)
                {
                    Console.WriteLine("Not found.");
                    return null;
                }

                return employee;
            }
        }

        public static void DeletEmployee(Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("Bad request. Employee can not be null.");
                return;
            }
            using (AppDbContext context = new AppDbContext())
            {
                var existing = GetEmployee(employee.Id);
                if (existing == null)
                {
                    Console.WriteLine("Employee not found.");
                    return;
                }

                context.Employees.Remove(employee);
                var isremoved = context.SaveChanges() > 0;
                if (!isremoved)
                {
                    Console.WriteLine($"Employee is not deleted.");
                    return;
                }

                Console.WriteLine($"Employee {employee.Name} {employee.LastName} was successfully deleted.");

            }
        }

        public static Employee AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("Bad request. Employee can not be null.");
                return employee;
            }
            using (AppDbContext context = new AppDbContext())
            {

                var result = context.Employees.Add(employee);
                var isAdded = context.SaveChanges() > 0;
                if (isAdded)
                {
                    Console.WriteLine($"Employee {employee.Name} {employee.LastName} was successfully recorded.");
                }
                else
                {
                    Console.WriteLine($"Employee is not recorded.");
                }
                return result.Entity;
            }
        }

        public static List<Employee> GetEmployees()
        {
            using (var context = new AppDbContext())
            {
                var departments = context.Employees.Include(d => d.Department).ToList();
                return departments;
            }
        }

        public static Employee UpdateEmployee(Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("Bad request. Employee can not be null.");
                return employee;
            }
            using (AppDbContext context = new AppDbContext())
            {
                var existing = GetEmployee(employee.Id);
                if (existing == null)
                {
                    Console.WriteLine("Employee not found.");
                    return employee;
                }

                existing.Name = employee.Name;
                existing.LastName = employee.LastName;
                existing.DepartmentId = employee.DepartmentId;
                context.Employees.Update(existing);
                var isUpdated = context.SaveChanges() > 0;
                if (!isUpdated)
                {
                    Console.WriteLine($"Employee is not updated.");
                    return employee;
                }

                Console.WriteLine($"Employee {existing.Name} {existing.LastName} was successfully updated.");
                return existing;
            }
        }
    }
}
