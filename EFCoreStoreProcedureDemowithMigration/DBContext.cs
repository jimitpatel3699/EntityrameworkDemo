using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreStoreProcedureDemowithMigration
{
    internal class DBContext : DbContext
    {
        private static string? _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
       

    }
}
