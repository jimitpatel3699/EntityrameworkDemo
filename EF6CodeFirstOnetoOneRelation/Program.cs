using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstOnetoOneRelation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (DBContext context = new DBContext())
            {
                while (true)
                {
                    var stud = new Student()
                    {
                        StudentId = Guid.NewGuid(), 
                        FirstName = UserInput.GetInput("Enter FirstName:"),
                        LastName = UserInput.GetInput("Enter LastName:"),
                    };
                    var address = new StudentAddress()
                    {
                        StudentAddressId = stud.StudentId,
                        City = UserInput.GetInput("Enter City:"),
                        Country = UserInput.GetInput("Enter Country:"),
                    };
                    stud.Address = address;
                    context.Students.Add(stud);
                    context.SaveChanges();
                    Console.WriteLine("Student Added");
                }

            }
        }
    }
}
