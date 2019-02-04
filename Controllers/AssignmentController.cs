using AutoMapper;
using GAP.Insurance.Entities;
using GAP.Insurance.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Controllers
{
    [Route("/Clients/{clientId}/Policies")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        public readonly IAssignmentService _assignmentService;
        public readonly IClientService _clientService;
        public readonly IPolicyService _policyService;

        public AssignmentController(IAssignmentService assignmentService,
                                    IClientService clientService,
                                    IPolicyService policyService)
        {
            _assignmentService = assignmentService;
            _clientService = clientService;
            _policyService = policyService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult<List<Policy>> GetPolicies(int clientId)
        {
            var policies = _assignmentService.GetPolicies(clientId);

            return Ok(policies);
        }

        [Route("")]
        [HttpPost]
        public ActionResult AddAssignment(Assignment assignment)
        {
            if (assignment == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            //check if client exists
            if (!_clientService.ClientExists(assignment.ClientId))
                return NotFound("Client not found.");

            //check if policy exists
            if (!_policyService.PolicyExists(assignment.PolicyId))
                return NotFound("Policy not found.");

            var newAssignment = _assignmentService.CreateAssignment(assignment);

            if (!_assignmentService.Save())
                throw new Exception($"Creation has failed.");

            return Ok();
        }

        [Route("{policyId}")]
        [HttpDelete]
        public ActionResult RemoveAssignment(int clientId, int policyId)
        {
            if (!_assignmentService.AssignmentExists(clientId, policyId))
                return NotFound();

            var assignment = _assignmentService.GetAssignment(clientId, policyId);

            _assignmentService.RemoveAssigment(assignment);

            if (!_assignmentService.Save())
                throw new Exception($"Delete has failed.");

            return NoContent();
        }
    }
}
