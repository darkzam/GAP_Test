using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Entities
{
    public class CoverageType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public int Name { get; set; }

        [Required]
        public double Coverage { get; set; }
    }
}
