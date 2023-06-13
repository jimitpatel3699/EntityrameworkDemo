using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstManytoManyRelation
{
    internal class DBContext:DbContext
    {
        public DBContext() : base("name=MyConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBContext, EF6CodeFirstManytoManyRelation.Migrations.Configuration>());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
    }
}
