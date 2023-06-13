using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6CodeFirstOnetoOneRelation
{
    internal class StudentAddress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid StudentAddressId { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [ForeignKey("StudentAddressId")]
        public virtual Student Student { get; set; }
    }
}
