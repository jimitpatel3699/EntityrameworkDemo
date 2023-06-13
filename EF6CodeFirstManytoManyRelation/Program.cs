using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstManytoManyRelation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int choice;
                    Console.WriteLine("1.Register New Course");
                    Console.WriteLine("2.Register New Student");
                    Console.WriteLine("3.Register Student into Course");
                    Console.WriteLine("4.ShowallRegisterdStudentinCourses");
                    Console.WriteLine("Enter Choice:");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                CURD.CourseRegister();
                                break;
                            }
                        case 2:
                            {
                                CURD.StudentRegister();
                                break;
                            }
                        case 3:
                            {
                                CURD.StudentCourse();
                                break;
                            }
                        case 4:
                            {
                                CURD.ShowallData();
                                break;
                            }
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
