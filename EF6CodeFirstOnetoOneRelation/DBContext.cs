using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstOnetoOneRelation
{
    internal class DBContext:DbContext
    {
        public DBContext() : base("name=MyConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DBContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure One to Zero or One to One Relationships between Student and StudentAddress
            modelBuilder.Entity<Student>()
                        // Mark Address property optional in Student entity
                        .HasOptional(std => std.Address)
                        //Mark Student property as required in StudentAddress entity. 
                        //Cannot save StudentAddress without Student
                        .WithRequired(add => add.Student);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
    }
}
