using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstOnetoManyRelation
{
    internal class DBContext:DbContext
    {
        public DBContext() : base("name=MyConnectionString")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DBContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBContext, EF6CodeFirstOnetoManyRelation.Migrations.Configuration>());
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
