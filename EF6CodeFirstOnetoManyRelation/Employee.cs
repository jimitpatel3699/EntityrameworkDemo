using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstOnetoManyRelation
{
    internal class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public decimal Salary { get; set; }
        public int Department_Id { get; set; }
        [ForeignKey("Department_Id")]
        public virtual Department Department { get; set; }
    }
}
