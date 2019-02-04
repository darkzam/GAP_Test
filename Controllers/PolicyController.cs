using AutoMapper;
using GAP.Insurance.Context;
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
    [Route("/Policies")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        public readonly IPolicyService _policyService;
        public readonly ICoverageTypeService _coverageTypeService;
        public readonly IRiskTypeService _riskTypeService;

        public PolicyController(IPolicyService policyService,
                                ICoverageTypeService coverageTypeService,
                                IRiskTypeService riskTypeService)
        {
            _policyService = policyService;
            _coverageTypeService = coverageTypeService;
            _riskTypeService = riskTypeService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<PolicyDto>> GetPolicies()
        {
            var policies = _policyService.GetPolicies();

            var policiesDto = Mapper.Map<List<PolicyDto>>(policies);

            return Ok(policiesDto);
        }

        [Route("{id}", Name = "GetPolicyById")]
        [HttpGet]
        public ActionResult<PolicyDto> GetPolicyById(int id)
        {
            if (!_policyService.PolicyExists(id))
                return NotFound();

            var policy = _policyService.GetPolicyById(id);

            if (policy == null)
                return NotFound();

            var policyDto = Mapper.Map<PolicyDto>(policy);

            return Ok(policyDto);
        }

        [Route("")]
        [HttpPost]
        public ActionResult<Policy> AddPolicy(PolicyCreateDto policyCreateDto)
        {
            if (policyCreateDto == null)
                return BadRequest();

            if (!(policyCreateDto.Period > 0))
                ModelState.AddModelError(nameof(policyCreateDto), "Period should be greater than zero.");

            if (!(policyCreateDto.Price > 0))
                ModelState.AddModelError(nameof(policyCreateDto), "Price should be greater than zero.");

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            //check if coverage exists
            if (!_coverageTypeService.CoverageTypeExists(policyCreateDto.CoverageTypeId))
                return NotFound("Coverage Type not found.");

            //check if risk exists
            if (!_riskTypeService.RiskTypeExists(policyCreateDto.RiskTypeId))
                return NotFound("Risk Type not found.");

            var coverageType = _coverageTypeService.GetCoverageTypeById(policyCreateDto.CoverageTypeId);
            var riskType = _riskTypeService.GetRiskTypeById(policyCreateDto.RiskTypeId);

            //check for a valid coverage porcentage if there's high risk
            if (!_policyService.IsValidCoverage(riskType, coverageType))
                return BadRequest($"Risk Type: {riskType.Name} requires coverage to be greater than 50%.");

            var policy = Mapper.Map<Policy>(policyCreateDto);

            var newPolicy = _policyService.AddPolicy(policy);

            if (!_policyService.Save())
                throw new Exception($"Create has failed.");

            return CreatedAtRoute("GetPolicyById",
                                   new { id = newPolicy.Id },
                                   newPolicy
                                   );
        }

        [Route("{id}")]
        [HttpDelete]
        public ActionResult DeletePolicy(int id)
        {
            if (!_policyService.PolicyExists(id))
                return NotFound();

            var policy = _policyService.GetPolicyById(id);

            if (policy == null)
                return NotFound();

            _policyService.DeletePolicy(policy);

            if (!_policyService.Save())
                throw new Exception($"Delete has failed.");

            return NoContent();
        }

        [Route("{id}")]
        [HttpPut]
        public ActionResult UpdatePolicy(int id, PolicyCreateDto policyCreateDto)
        {
            if (policyCreateDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            if (!_policyService.PolicyExists(id))
                return NotFound();

            //check if coverage exists
            if (!_coverageTypeService.CoverageTypeExists(policyCreateDto.CoverageTypeId))
                return NotFound("Coverage Type not found.");

            //check if risk exists
            if (!_riskTypeService.RiskTypeExists(policyCreateDto.RiskTypeId))
                return NotFound("Risk Type not found.");

            var coverageType = _coverageTypeService.GetCoverageTypeById(policyCreateDto.CoverageTypeId);
            var riskType = _riskTypeService.GetRiskTypeById(policyCreateDto.RiskTypeId);

            //check for a valid coverage porcentage if there's high risk
            if (!_policyService.IsValidCoverage(riskType, coverageType))
                return BadRequest($"Risk Type: {riskType.Name} requires coverage to be greater than 50%.");

            var policy = _policyService.GetPolicyById(id);

            Mapper.Map(policyCreateDto, policy);

            _policyService.UpdatePolicy(policy);

            if (!_policyService.Save())
                throw new Exception("Update has failed.");

            return NoContent();
        }
    }
}
