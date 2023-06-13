using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstStoreProcedureDemo
{
    internal class DBContext:DbContext
    {
        public DBContext() : base("name=MyConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DBContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Map Student Entity to Default Stored Procedures
            modelBuilder.Entity<Student>()
                        .MapToStoredProcedures();
        }
        public DbSet<Student> Students { get; set; }
    }
}
