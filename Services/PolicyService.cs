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
        public InsuranceContext _insuranceContext { get; set; }

        public PolicyService(InsuranceContext insuranceContext)
        {

            _insuranceContext = insuranceContext;
        }

        public List<Policy> GetPolicies()
        {
            var policies = _insuranceContext.Policies.ToList<Policy>();

            return policies;
        }

        public Policy GetPolicyById(string Id)
        {
            var policy = _insuranceContext.Policies.FirstOrDefault(r => r.Id == int.Parse(Id));

            return policy;
        }

        public Policy AddPolicy(Policy policy)
        {
            var newPolicy = _insuranceContext.Policies.Add(policy);

            return newPolicy.Entity;
        }

        public void DeletePolicy(Policy policy)
        {
            throw new NotImplementedException();
        }

        public Policy UpdatePolicy(Policy policy)
        {
            throw new NotImplementedException();
        }
    }
}
