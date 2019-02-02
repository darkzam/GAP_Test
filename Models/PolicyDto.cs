using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Models
{   //Dto used on response
    public class PolicyDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string DateStart { get; set; }

        public string Period { get; set; }

        public string CoverageTypeName { get; set; }

        public string RiskTypeName { get; set; }

    }
}
