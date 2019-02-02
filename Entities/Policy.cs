using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Entities
{
    public class Policy
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        public int Period { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("CoverageTypeId")]
        public CoverageType CoverageType { get; set; }

        public int CoverageTypeId { get; set; }

        [ForeignKey("RiskTypeId")]
        public RiskType RiskType { get; set; }

        public int RiskTypeId { get; set; }

    }
}
