using GAP.Insurance.Context;
using GAP.Insurance.Entities;
using GAP.Insurance.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services
{
    public class AssignmentService : IAssignmentService
    {
        public InsuranceContext _insuranceContext;

        public AssignmentService(InsuranceContext insuranceContext)
        {
            _insuranceContext = insuranceContext;
        }

        public Assignment GetAssignment(int clientId, int policyId)
        {
            var assignment = _insuranceContext.Assignments.FirstOrDefault(r => r.ClientId == clientId && r.PolicyId == policyId);

            return assignment;
        }

        public List<Policy> GetPolicies(int clientId)
        {
            return _insuranceContext.Policies.Where(p =>
           _insuranceContext.Assignments.Where(a => a.ClientId == clientId && a.PolicyId == p.Id).Count() > 0).ToList();

        }

        public Assignment CreateAssignment(Assignment assignment)
        {
            var newAssignment = _insuranceContext.Assignments.Add(assignment);

            return newAssignment.Entity;
        }

        public void RemoveAssigment(Assignment assignment)
        {
            _insuranceContext.Assignments.Remove(assignment);
        }

        public bool AssignmentExists(int clientId, int policyId)
        {
            return _insuranceContext.Assignments.Any(r => r.ClientId == clientId && r.PolicyId == policyId);
        }

        public bool Save()
        {
            return (_insuranceContext.SaveChanges() >= 0);
        }
    }
}
