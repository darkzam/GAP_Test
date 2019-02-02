using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Models
{   //Dto used on request
    public class PolicyCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public int Period { get; set;}

        public int CoverageTypeId { get; set; }

        public int RiskTypeId { get; set; }

    }
}
