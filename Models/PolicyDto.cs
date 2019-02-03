using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Models
{   //Dto used on response
    public class PolicyDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string DateStart { get; set; }

        public string DateEnd { get; set; }

        public int Period { get; set; }

        public double Price { get; set; }

        public int CoverageTypeId { get; set; }

        public int RiskTypeId { get; set; }

    }
}
