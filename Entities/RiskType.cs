using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Entities
{
    public class RiskType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Name { get; set; }
    }
}
