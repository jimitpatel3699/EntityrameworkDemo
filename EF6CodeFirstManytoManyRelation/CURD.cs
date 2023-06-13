using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EF6CodeFirstManytoManyRelation
{
    internal static class CURD
    {
        public static void CourseRegister()
        {
            using (DBContext context = new DBContext())
            {
                Course course = new Course()
                {
                    Id = UserInput.GetInput("Enter course Id:"),
                };
                if (context.Courses.Find(course.Id) != null)
                {
                    Console.WriteLine("course already available.");
                }
                else
                {
                    course.CourseName = UserInput.GetInput("Enter course name:");
                    context.Courses.Add(course);
                    context.SaveChanges();
                    Console.WriteLine("Course register in database");
                }
                ShowCourses();
            }
        }
        public static void StudentRegister()
        {
            using (DBContext context = new DBContext())
            {
                Student student = new Student()
                {
                    Id = Convert.ToInt32(UserInput.GetInput("Enter student Id:")),
                   
                };
                if(context.Students.Find(student.Id) == null)
                {
                    student.Name = UserInput.GetInput("Enter Student Name:");
                    context.Students.Add(student);
                    context.SaveChanges();
                    Console.WriteLine("Student succesfully register in database");
                }
                else
                {
                    Console.WriteLine("Student Id already registered.");
                }
                ShowStudents();
            }
        }
        public static void StudentCourse()
        {
            using (DBContext context = new DBContext())
            {
                StudentCourse studentCourse = new StudentCourse()
                {
                    Student_Id = Convert.ToInt32(UserInput.GetInput("Enter student Id:")),
                    Course_Id = UserInput.GetInput("Enter course Id:")
                };
                if (context.Students.Find(studentCourse.Student_Id) == null)
                {
                    Console.WriteLine("Student not register in main table.Please register student first.");
                }
                else if (context.Courses.Find(studentCourse.Course_Id) == null)
                {
                    Console.WriteLine("Course id not register in main table.Please register course first.");
                }
                else if (context.StudentCourses.SingleOrDefault(i => i.Student_Id == studentCourse.Student_Id && i.Course_Id == studentCourse.Course_Id) != null)
                {
                    Console.WriteLine("Student already register in course.");
                }
                else
                {
                    context.StudentCourses.Add(studentCourse);
                    context.SaveChanges();
                    Console.WriteLine("Student succesfully enroll in course");
                    ShowallData();
                }
            }
        }
        public static void ShowCourses()
        {
            using(DBContext context = new DBContext())
            {
                List<Course> allCourse = context.Courses.ToList();
                var table = new ConsoleTable("Id", "CourseName");
                foreach (Course course in allCourse)
                {
                    table.AddRow(course.Id,course.CourseName);
                }
                table.Write();
            }
        }
        public static void ShowStudents()
        {
            using(DBContext context = new DBContext()) 
            { 
                List<Student> allStudent = context.Students.ToList();
                var table = new ConsoleTable("Id", "StudentName");
                foreach(Student student in allStudent)
                {
                    table.AddRow(student.Id,student.Name);
                }
                table.Write();
            }
        }
        public static void ShowallData()
        {
            using(DBContext context = new DBContext())
            {
                var result = context.StudentCourses
                                    .Join(context.Students,
                                    sc => sc.Student_Id,
                                    s => s.Id,
                                    (sc, s) => new { sc, s })
                                     .Join(context.Courses,
                                    temp => temp.sc.Course_Id,
                                    c => c.Id,
                                    (temp, c) => new { temp.s, c })
                                    .Select(data => new {
                                    StudentID = data.s.Id,
                                    StudentName = data.s.Name,
                                    CourseID = data.c.Id,
                                    CourseName = data.c.CourseName
                                     })
                                    .ToList();
                var table = new ConsoleTable("StudentId", "StudentName","CourseId","CourseName");
                foreach(var item in result)
                {
                    table.AddRow(item.StudentID, item.StudentName,item.CourseID,item.CourseName);
                }
                table.Write();
            }
        }
    }
}
