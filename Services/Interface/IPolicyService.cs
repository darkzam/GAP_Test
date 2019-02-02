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

        Policy GetPolicyById(string Id);

        Policy AddPolicy(Policy policy);

        void DeletePolicy(Policy policy);

        Policy UpdatePolicy(Policy policy);
    }
}
