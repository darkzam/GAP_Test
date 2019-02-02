using AutoMapper;
using GAP.Insurance.Context;
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
    [Route("/Policies")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        public IPolicyService _policyService { get; set; }

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<PolicyDto>> GetPolicies()
        {
            var policies = _policyService.GetPolicies();

            var policiesDto = Mapper.Map<List<PolicyDto>>(policies);

            return Ok(policiesDto);
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Policy> GetPolicyById(string id)
        {
            var policy = _policyService.GetPolicyById(id);

            if (policy == null)
                return NotFound("The resource could not be found.");

            return Ok(policy);
        }

        [Route("")]
        [HttpPost]
        public ActionResult<PolicyDto> AddPolicy(PolicyCreateDto policyCreateDto)
        {
            if (policyCreateDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest();

            var policy = Mapper.Map<Policy>(policyCreateDto);

            var newPolicy = _policyService.AddPolicy(policy);

            var newPolicyDto = Mapper.Map<PolicyDto>(newPolicy);

            return Ok(newPolicyDto);
        }

        [Route("")]
        [HttpDelete]
        public ActionResult DeletePolicy(Policy policy)
        {
            _policyService.DeletePolicy(policy);

            return Ok();
        }

        public ActionResult<Policy> UpdatePolicy(Policy policy)
        {
            var newPolicy = _policyService.UpdatePolicy(policy);

            return Ok(newPolicy);
        }
    }
}
