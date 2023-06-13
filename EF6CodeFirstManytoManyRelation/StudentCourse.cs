using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstManytoManyRelation
{
    internal class StudentCourse
    {
        [Key]
        [Column(Order = 1)]
        public int Student_Id { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Course_Id { get; set; }
        [ForeignKey("Student_Id")]
        public Student Student { get; set; }
        [ForeignKey("Course_Id")]
        public Course Course { get; set; }

    }
}
