using GAP.Insurance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services.Interface
{
    public interface IAssignmentService
    {
        List<Policy> GetPolicies(int clientId);

        Assignment GetAssignment(int clientId, int policyId);

        Assignment CreateAssignment(Assignment assignment);

        void RemoveAssigment(Assignment assignment);

        bool AssignmentExists(int clientId, int policyId);

        bool Save();
    }
}
