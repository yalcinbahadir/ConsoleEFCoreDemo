using ConsoleEFCoreDemo.Data;
using ConsoleEFCoreDemo.Entities;
using ConsoleEFCoreDemo.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ConsoleEFCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var employees=EmployeeMockRepository.GetEmployees();

            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($" Employee :{employee.Name} {employee.LastName} Department : {employee.Department.Name}");
            //}

            //EmployeeMockRepository.AddEmployee(new Employee() { Name = "Test", LastName = "Tester", DepartmentId = 2 });
            //var emp = EmployeeMockRepository.GetEmployee(6);
            //if (emp != null)
            //{
            //    Console.WriteLine(emp.Name);
            //}

            //EmployeeMockRepository.DeletEmployee(emp);

            ////Update
            //var newEmp = EmployeeMockRepository.AddEmployee(new Employee() { Name = "Demo", LastName = "Edit-demo", DepartmentId = 2 });
            //newEmp.Name = "Editor";
            //var updated = EmployeeMockRepository.UpdateEmployee(newEmp);
            //Console.WriteLine(updated.Name);
            Console.ReadLine();
        }
    }
}
