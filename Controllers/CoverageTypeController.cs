using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Controllers
{
    [Route("/CoverageTypes")]
    [ApiController]
    public class CoverageTypeController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public ActionResult<List> GetCoverageTypes()
        {

        }

        [Route("")]
        [HttpGet]
        public ActionResult GetCoverageTypes()
        {

        }

        [Route("")]
        [HttpPost]
        public ActionResult GetCoverageTypes()
        {

        }

        [Route("")]
        [HttpDelete]
        public ActionResult GetCoverageTypes()
        {

        }
    }
}
