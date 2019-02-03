using GAP.Insurance.Context;
using GAP.Insurance.Entities;
using GAP.Insurance.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services
{
    public class PolicyService : IPolicyService
    {
        public readonly InsuranceContext _insuranceContext;

        public PolicyService(InsuranceContext insuranceContext)
        {

            _insuranceContext = insuranceContext;
        }

        public Policy AddPolicy(Policy Policy)
        {
            var Risk = _insuranceContext.Policies.Add(Policy);

            return Risk.Entity;
        }

        public Policy GetPolicyById(int id)
        {
            return _insuranceContext.Policies.FirstOrDefault(r => r.Id == id);
        }

        public List<Policy> GetPolicies()
        {
            return _insuranceContext.Policies.ToList<Policy>();
        }

        public void DeletePolicy(Policy Policy)
        {
            _insuranceContext.Policies.Remove(Policy);
        }

        public void UpdatePolicy(Policy Policy)
        {
            _insuranceContext.Policies.Update(Policy);
        }

        public bool PolicyExists(int id)
        {
            return _insuranceContext.Policies.Any(r => r.Id == id);
        }

        public bool Save()
        {
            return (_insuranceContext.SaveChanges() >= 0);
        }

        public bool IsValidCoverage(RiskType riskType, CoverageType coverageType)
        {
            return !(string.Equals(riskType.Name.ToLower(), "alto") && coverageType.Coverage > 0.5); 
        }

    }
}
