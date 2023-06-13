using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstOnetoManyRelation
{
    internal static class CURD
    {
        public static void Insert()
        {
            using (DBContext context = new DBContext())
            {
                Department department = new Department()
                {
                    DepartmentID = Convert.ToInt32(UserInput.GetInput("Enter DepartmentNumber:"))
                };
                if (context.Departments.Find(department.DepartmentID) == null)
                {
                    department.DepartmentName = UserInput.GetInput("Enter DepartmentName:");
                    context.Departments.Add(department);
                    context.SaveChanges();
                    Console.WriteLine("Department Added");
                }
                Employee employee = new Employee()
                {
                    Id = Convert.ToInt32(UserInput.GetInput("Enter EmployeeId:")),
                    EmployeeName = UserInput.GetInput("Enter EmployeeName:"),
                    EmployeeAge = Convert.ToInt32(UserInput.GetInput("Enter EmployeeAge:")),
                    Salary = Convert.ToDecimal(UserInput.GetInput("Enter EmployeeSalary:")),
                    Department_Id = department.DepartmentID
                };
                context.Employees.Add(employee);
                context.SaveChanges();
                Console.WriteLine("Employee Added");
            }
            Select();
        }
        public static void Update()
        {
            using (DBContext context = new DBContext())
            {
                Employee employee = new Employee()
                {
                    Id = Convert.ToInt32(UserInput.GetInput("Enter EmployeeId:")),
                };
                Employee emp = context.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                if(emp != null)
                {
                    emp.EmployeeAge = Convert.ToInt32(UserInput.GetInput("Enter EmployeeAge:"));
                    emp.Salary = Convert.ToDecimal(UserInput.GetInput("Enter EmployeeSalary:"));
                    context.SaveChanges();
                    Console.WriteLine("Employee Updated");
                }
                else
                {
                    Console.WriteLine("Employee not exist.");
                }
                Select();
            }
        }
        public static void Delete()
        {
            using (DBContext context = new DBContext())
            {
                Employee employee = new Employee()
                {
                    Id = Convert.ToInt32(UserInput.GetInput("Enter EmployeeId:")),
                };
                if (context.Employees.Find(employee.Id) != null)
                {
                    List<Employee> employees = context.Employees.Where(x => x.Id == employee.Id).ToList();
                    context.Employees.RemoveRange(employees);
                    context.SaveChanges();
                    Console.WriteLine("Employee Deleted");
                }
                else
                {
                    Console.WriteLine("Employee not exist.");
                }
                Select();
            }
        }
        public static void Select()
        {
            DBContext context = new DBContext();
            List<Employee> employees = context.Employees.ToList();
            Console.WriteLine("=======================================");
            var table = new ConsoleTable("Id", "EmployeeName", "Age", "Salary", "Department_Id");
            foreach (Employee Emp in employees)
            {
                table.AddRow(Emp.Id, Emp.EmployeeName, Emp.EmployeeAge,Emp.Salary, Emp.Department_Id);
            }
            table.Write();
            Console.WriteLine("=======================================");
        }
        public static void Select(int deptId)
        {
            DBContext context = new DBContext();
            List<Employee> employees = context.Employees.Where(x => x.Department_Id == deptId).ToList();
            Console.WriteLine("=======================================");
            var table = new ConsoleTable("Id", "EmployeeName", "Age", "Salary", "Department_Id");
            foreach (Employee Emp in employees)
            {
                table.AddRow(Emp.Id, Emp.EmployeeName, Emp.EmployeeAge, Emp.Salary, Emp.Department_Id);
            }
            table.Write();
            Console.WriteLine("=======================================");
        }
        public static void RegisterDepartment()
        {
            using (DBContext context = new DBContext())
            {
                Department department = new Department()
                {
                    DepartmentID = Convert.ToInt32(UserInput.GetInput("Enter DepartmentNumber:"))
                };
                if (context.Departments.Find(department.DepartmentID) == null)
                {
                    department.DepartmentName = UserInput.GetInput("Enter DepartmentName:");
                    context.Departments.Add(department);
                    context.SaveChanges();
                    Console.WriteLine("Department Added");
                }
                else
                {
                    Console.WriteLine("Department already exist.");
                }
                ShowDepartment();
            }
        }
        public static void UpdateDepartment()
        {
            using (DBContext context = new DBContext())
            {
                Department department = new Department()
                {
                    DepartmentID = Convert.ToInt32(UserInput.GetInput("Enter DepartmentNumber:"))
                };
                Department dept = context.Departments.Where(x => x.DepartmentID == department.DepartmentID).FirstOrDefault();
                if (dept != null)
                {
                    dept.DepartmentName = UserInput.GetInput("Enter DepartmentName:");
                    context.SaveChanges();
                    Console.WriteLine("Department Updated");
                }
                else
                {
                    Console.WriteLine("Department not exist.");
                }
                ShowDepartment();
            }
        }
        public static void RemoveDepartment()
        {
            using (DBContext context = new DBContext())
            {
                Department department = new Department()
                {
                    DepartmentID = Convert.ToInt32(UserInput.GetInput("Enter DepartmentId:")),
                };
                if (context.Departments.Find(department.DepartmentID) != null)
                {
                    List<Department> departments = context.Departments.Where(x => x.DepartmentID == department.DepartmentID).ToList();
                    context.Departments.RemoveRange(departments);
                    context.SaveChanges();
                    Console.WriteLine("Department Deleted");
                }
                else
                {
                    Console.WriteLine("Department not exist.");
                }
                ShowDepartment();
                Select();
            }
        }
        public static void ShowDepartment()
        {
            DBContext context = new DBContext();
            List<Department> departments = context.Departments.ToList();
            Console.WriteLine("=======================================");
            var table = new ConsoleTable("Id", "DepartmentName");
            foreach (Department Dept in departments)
            {
                table.AddRow(Dept.DepartmentID, Dept.DepartmentName);
            }
            table.Write();
            Console.WriteLine("=======================================");
        }
    }
}
