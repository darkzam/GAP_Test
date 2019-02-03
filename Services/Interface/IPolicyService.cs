using GAP.Insurance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services.Interface
{
    public interface IPolicyService
    {
        List<Policy> GetPolicies();

        Policy GetPolicyById(int id);

        Policy AddPolicy(Policy policy);

        void DeletePolicy(Policy policy);

        void UpdatePolicy(Policy policy);

        bool PolicyExists(int id);

        bool Save();

        bool IsValidCoverage(RiskType riskType, CoverageType coverageType);
    }
}
