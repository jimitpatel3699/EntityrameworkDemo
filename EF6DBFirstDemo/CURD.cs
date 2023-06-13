using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6DBFirstDemo
{
    internal class CURD
    {
        public static void Insert()
        {
            using (ExcerciseEntities context = new ExcerciseEntities())
            {
                var Id = context.Employees.Max(x => x.Id);
                var employee = new Employee
                {
                    Id = Id + 1,
                    EmployeeName = "Suraj",
                    Job = "Analyst",
                    ManagerId = 5023,
                    HireDate = DateTime.Now,
                    Salary = 15000,
                    Commision = 0,
                    Department_Id = 10
                };
                context.Employees.Add(employee);
                context.SaveChanges();
                Select();
            }
        }
        public static void Update()
        {
            using (ExcerciseEntities context = new ExcerciseEntities())
            {
                List<Employee> employees = context.Employees.Where(x => x.ManagerId == 5023).ToList();
                if (employees != null)
                {
                    foreach (Employee employee in employees)
                    {
                        employee.Commision = 1200;
                    }
                }
                context.SaveChanges();
                Select(10);
            }
        }
        public static void Delete()
        {
            using (ExcerciseEntities context = new ExcerciseEntities())
            {
                List<Employee> employees = context.Employees.Where(x => x.ManagerId == 5023).ToList();
                if (employees != null)
                {
                    context.Employees.RemoveRange(employees);
                }
                context.SaveChanges();
                Select();
            }
        }
        public static void Select()
        {
            ExcerciseEntities context = new ExcerciseEntities();
            List<Employee> employees = context.Employees.ToList();
            var table = new ConsoleTable("Id", "EmployeeName", "Job", "ManagerId", "HireDate", "Salary", "Commision", "Department_Id");
            foreach (Employee Emp in employees)
            {
                table.AddRow(Emp.Id, Emp.EmployeeName, Emp.Job, Emp.ManagerId, Emp.HireDate, Emp.Salary, Emp.Commision, Emp.Department_Id);
            }
            //table.Options.EnableCount = false;
            table.Write();
        }
        public static void Select(int DepartmentID)
        {
            using (ExcerciseEntities context = new ExcerciseEntities())
            {
                List<Employee> employees = context.Employees.Where(x => x.Department_Id == DepartmentID).ToList();
                var table = new ConsoleTable("Id", "EmployeeName", "Job", "ManagerId", "HireDate", "Salary", "Commision", "Department_Id");
                foreach (Employee Emp in employees)
                {
                    table.AddRow(Emp.Id, Emp.EmployeeName, Emp.Job, Emp.ManagerId, Emp.HireDate, Emp.Salary, Emp.Commision, Emp.Department_Id);
                }
                //table.Options.EnableCount = false;
                table.Write();

            }
        }
    }
}
