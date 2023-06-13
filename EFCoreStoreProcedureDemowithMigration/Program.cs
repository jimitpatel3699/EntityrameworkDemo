using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace EFCoreStoreProcedureDemowithMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DBContext context = new DBContext())
            {
                //context.Database.Log = Console.Write;//this line used for write database log at code side.
                Console.WriteLine("Student Added");
                var student = new List<Student>()
                              {
                                    new Student(){FirstName ="jimit", LastName ="patel"},
                                    new Student(){FirstName="akash",LastName="rana"},
                                    new Student(){FirstName="jainam",LastName="bhavsar"}
                              };
                context.Students.AddRange(student);
                context.SaveChanges();
                //calling storedprocedure
                var list1 = context.Students.FromSqlRaw("GetStudents @p0", "jimit").ToList();
                foreach(var item in list1)
                {
                    Console.WriteLine($"StudentID:{ item.StudentId}");
                    Console.WriteLine($"FirstName:{item.FirstName}");
                    Console.WriteLine($"LastName:{item.LastName}");   
                }
                
            }
        }
    }
}