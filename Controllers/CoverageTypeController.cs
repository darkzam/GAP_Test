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
    [Route("/CoverageTypes")]
    [ApiController]
    public class CoverageTypeController : ControllerBase
    {
        private readonly ICoverageTypeService _coverageTypeService;

        public CoverageTypeController(ICoverageTypeService coverageTypeService)
        {
            _coverageTypeService = coverageTypeService;

        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<CoverageType>> GetCoverageTypes()
        {
            var coverageTypes = _coverageTypeService.GetCoverageTypes();

            return Ok(coverageTypes);
        }

        [Route("{id}", Name = "GetCoverageTypeById")]
        [HttpGet]
        public ActionResult<CoverageType> GetCoverageTypeById(int id)
        {
            if (!_coverageTypeService.CoverageTypeExists(id))
                return NotFound();

            var coverageType = _coverageTypeService.GetCoverageTypeById(id);

            return Ok(coverageType);
        }

        [Route("")]
        [HttpPost]
        public ActionResult AddCoverageType(CoverageTypeDto coverageTypeDto)
        {
            if (coverageTypeDto == null)
                return BadRequest();

            if (!(coverageTypeDto.Coverage > 0 && coverageTypeDto.Coverage <= 1))
                ModelState.AddModelError(nameof(coverageTypeDto), "Coverage should be greater than zero and up to one.");

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var coverage = Mapper.Map<CoverageType>(coverageTypeDto);

            var newCoverage = _coverageTypeService.AddCoverageType(coverage);

            if (!_coverageTypeService.Save())
                throw new Exception($"Creation has failed.");

            return CreatedAtRoute("GetCoverageTypeById",
                                   new { id = newCoverage.Id },
                                   newCoverage
                                   );
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeleteCoverageType(int id)
        {
            if (!_coverageTypeService.CoverageTypeExists(id))
                return NotFound();

            var coverageType = _coverageTypeService.GetCoverageTypeById(id);

            if (coverageType == null)
                return NotFound();

            _coverageTypeService.DeleteCoverageType(coverageType);

            if (!_coverageTypeService.Save())
                throw new Exception($"Deleting has failed.");

            return NoContent();
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult UpdateCoverageType(int id, CoverageTypeDto coverageTypeDto)
        {
            if (coverageTypeDto == null)
                return BadRequest();

            if (!(coverageTypeDto.Coverage > 0 && coverageTypeDto.Coverage <= 1))
                ModelState.AddModelError(nameof(coverageTypeDto), "Coverage should be greater than zero and up to one.");

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            if (!_coverageTypeService.CoverageTypeExists(id))
                return NotFound();

            var coverageType = _coverageTypeService.GetCoverageTypeById(id);

            Mapper.Map(coverageTypeDto ,coverageType);

            _coverageTypeService.UpdateCoverageType(coverageType);

            if (!_coverageTypeService.Save())
                throw new Exception("Update has failed.");

            return NoContent();
        }
    }
}
