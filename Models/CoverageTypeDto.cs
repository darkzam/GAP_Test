using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Models
{
    public class CoverageTypeDto
    {
        [Required()]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public double Coverage { get; set;}
    }
}
