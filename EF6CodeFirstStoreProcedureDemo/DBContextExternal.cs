using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstStoreProcedureDemo
{
    internal class DBContextExternal:DbContext
    {
        public DBContextExternal() : base("name=MyConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DBContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
            .MapToStoredProcedures(p => p.Insert(sp => sp.HasName("sp_InsertStudent").Parameter(pm => pm.FirstName, "FirstName").Parameter(pm => pm.LastName, "LastName").Result(rs => rs.StudentId, "StudentId"))
                    .Update(sp => sp.HasName("sp_UpdateStudent").Parameter(pm => pm.FirstName, "FirstName").Parameter(pm => pm.LastName, "LastName"))
                    .Delete(sp => sp.HasName("sp_DeleteStudent").Parameter(pm => pm.StudentId, "StudentId"))
            );
        }
        public DbSet<Student> Students { get; set; }
    }
}
