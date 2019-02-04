using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Entities
{   //Composite key specified on the InsuranceContext
    public class Assignment
    {
        [Required]
        public int ClientId { get; set; }

        [Required]
        public int PolicyId { get; set; }

    }
}
