using AutoMapper;
using GAP.Insurance.Entities;
using GAP.Insurance.Models;
using GAP.Insurance.Services.Interface;
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
        private readonly IRiskTypeService _RiskTypeService;

        public RiskTypeController(IRiskTypeService RiskTypeService)
        {
            _RiskTypeService = RiskTypeService;

        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<RiskType>> GetRiskTypes()
        {
            var RiskTypes = _RiskTypeService.GetRiskTypes();

            return Ok(RiskTypes);
        }

        [Route("{id}", Name = "GetRiskTypeById")]
        [HttpGet]
        public ActionResult<RiskType> GetRiskTypeById(int id)
        {
            if (!_RiskTypeService.RiskTypeExists(id))
                return NotFound();

            var RiskType = _RiskTypeService.GetRiskTypeById(id);

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

            var newRisk = _RiskTypeService.AddRiskType(Risk);

            if (!_RiskTypeService.Save())
                throw new Exception($"Creating has failed.");

            return CreatedAtRoute("GetRiskTypeById",
                                   new { id = newRisk.Id },
                                   newRisk
                                   );
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteRiskType(int id)
        {
            if (!_RiskTypeService.RiskTypeExists(id))
                return NotFound();

            var RiskType = _RiskTypeService.GetRiskTypeById(id);

            if (RiskType == null)
                return NotFound();

            _RiskTypeService.DeleteRiskType(RiskType);

            if (!_RiskTypeService.Save())
                throw new Exception($"Deleting has failed.");

            return NoContent();
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult UpdateRiskType(int id, RiskTypeDto RiskTypeDto)
        {
            if (RiskTypeDto == null)
                return BadRequest();

            if (!_RiskTypeService.RiskTypeExists(id))
                return NotFound();

            var RiskType = _RiskTypeService.GetRiskTypeById(id);

            Mapper.Map(RiskTypeDto, RiskType);

            _RiskTypeService.UpdateRiskType(RiskType);

            if (!_RiskTypeService.Save())
                throw new Exception("Update has failed.");

            return NoContent();
        }
    }
}
