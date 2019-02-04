using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Models
{   //Dto for the output of get actions
    public class ClientDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }
    }
}
