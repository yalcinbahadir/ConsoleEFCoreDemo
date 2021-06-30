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
            // ShowDepartmentsAndEmployees();
            //AddEmployee(new Employee() { Name="Test", LastName="Tester", DepartmentId=2 });
            //var emp = GetEmployee(4);
            //if (emp !=null)
            //{
            //    Console.WriteLine(emp.Name);
            //}

            //DeletEmployee(emp);
            //////Update
            //var newEmp=AddEmployee(new Employee() { Name = "Test", LastName = "Tester", DepartmentId = 2 });
            //newEmp.Name = "Editor";
            //var updated=UpdateEmployee(newEmp);
            //Console.WriteLine(updated.Name);
            Console.ReadLine();
        }

        private static Employee GetEmployee(int id)
        {
            using (var context = new AppDbContext())
            {
                var employee = context.Employees.Include(e => e.Department).FirstOrDefault(e=>e.Id==id);
                if (employee ==null)
                {
                    Console.WriteLine("Not found.");
                    return null;
                }

                return employee;
            }
        }

        private static void DeletEmployee(Employee employee)
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

        private static Employee AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                Console.WriteLine("Bad request. Employee can not be null.");
                return employee;
            }
            using (AppDbContext context=new AppDbContext())
            {

                var result=context.Employees.Add(employee);
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

        private static Employee UpdateEmployee(Employee employee)
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
