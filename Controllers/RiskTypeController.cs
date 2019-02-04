using AutoMapper;
using GAP.Insurance.Entities;
using GAP.Insurance.Models;
using GAP.Insurance.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Controllers
{
    [Route("/RiskTypes")]
    [ApiController]
    public class RiskTypeController : ControllerBase
    {
        private readonly IRiskTypeService _riskTypeService;

        public RiskTypeController(IRiskTypeService RiskTypeService)
        {
            _riskTypeService = RiskTypeService;

        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<RiskType>> GetRiskTypes()
        {
            var RiskTypes = _riskTypeService.GetRiskTypes();

            return Ok(RiskTypes);
        }

        [Route("{id}", Name = "GetRiskTypeById")]
        [HttpGet]
        public ActionResult<RiskType> GetRiskTypeById(int id)
        {
            if (!_riskTypeService.RiskTypeExists(id))
                return NotFound();

            var RiskType = _riskTypeService.GetRiskTypeById(id);

            return Ok(RiskType);
        }

        [Route("")]
        [HttpPost]
        public ActionResult AddRiskType(RiskTypeDto RiskTypeDto)
        {
            if (RiskTypeDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var Risk = Mapper.Map<RiskType>(RiskTypeDto);

            var newRisk = _riskTypeService.AddRiskType(Risk);

            if (!_riskTypeService.Save())
                throw new Exception($"Creation has failed.");

            return CreatedAtRoute("GetRiskTypeById",
                                   new { id = newRisk.Id },
                                   newRisk
                                   );
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteRiskType(int id)
        {
            if (!_riskTypeService.RiskTypeExists(id))
                return NotFound();

            var RiskType = _riskTypeService.GetRiskTypeById(id);

            if (RiskType == null)
                return NotFound();

            _riskTypeService.DeleteRiskType(RiskType);

            if (!_riskTypeService.Save())
                throw new Exception($"Deleting has failed.");

            return NoContent();
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult UpdateRiskType(int id, RiskTypeDto RiskTypeDto)
        {
            if (RiskTypeDto == null)
                return BadRequest();

            if (!_riskTypeService.RiskTypeExists(id))
                return NotFound();

            var RiskType = _riskTypeService.GetRiskTypeById(id);

            Mapper.Map(RiskTypeDto, RiskType);

            _riskTypeService.UpdateRiskType(RiskType);

            if (!_riskTypeService.Save())
                throw new Exception("Update has failed.");

            return NoContent();
        }
    }
}
