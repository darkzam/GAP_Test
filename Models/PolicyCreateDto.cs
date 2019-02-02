using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Models
{   //Dto used on request
    public class PolicyCreateDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Period { get; set;}

        public string Date { get; set; }

        public int CoverageTypeId { get; set; }

        public int RiskTypeId { get; set; }

    }
}
