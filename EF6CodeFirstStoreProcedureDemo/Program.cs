using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstStoreProcedureDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (DBContext context = new DBContext())
            using (DBContextExternal context = new DBContextExternal())
            {
                //context.Database.Log = Console.Write;//this line used for write database log at code side.
                Console.WriteLine("Student Added");
                var student = new List<Student>()
                              {
                                    new Student(){FirstName ="jimit", LastName = "patel"},
                                    new Student(){FirstName="akash",LastName="rana"},
                                    new Student(){FirstName="jainam",LastName="bhavsar"}
                              };
                context.Students.AddRange(student);
                context.SaveChanges();
                Console.WriteLine("\nStudent Updated");
                var maxId=context.Students.Max(x => x.StudentId);
                var StudentId1 = context.Students.Find(maxId);
                StudentId1.FirstName = "Anurag";
                context.SaveChanges();
                Console.WriteLine("\nStudent Deleted");
                var StudentToBeDeleted = context.Students.Find(maxId);
                context.Students.Remove(StudentToBeDeleted);
                context.SaveChanges();
            }
            Console.ReadKey();
        }
    }
}
