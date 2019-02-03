using GAP.Insurance.Context;
using GAP.Insurance.Entities;
using GAP.Insurance.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services
{
    public class RiskTypeService : IRiskTypeService
    {
        private readonly InsuranceContext _insuranceContext;

        public RiskTypeService(InsuranceContext insuranceContext)
        {
            _insuranceContext = insuranceContext;
        }

        public RiskType AddRiskType(RiskType RiskType)
        {
            var Risk = _insuranceContext.RiskTypes.Add(RiskType);

            return Risk.Entity;
        }

        public RiskType GetRiskTypeById(int id)
        {
            return _insuranceContext.RiskTypes.FirstOrDefault(r => r.Id == id);
        }

        public List<RiskType> GetRiskTypes()
        {
            return _insuranceContext.RiskTypes.ToList<RiskType>();
        }

        public void DeleteRiskType(RiskType RiskType)
        {
            _insuranceContext.RiskTypes.Remove(RiskType);
        }

        public void UpdateRiskType(RiskType RiskType)
        {
            _insuranceContext.RiskTypes.Update(RiskType);
        }

        public bool RiskTypeExists(int id)
        {
            return _insuranceContext.RiskTypes.Any(r => r.Id == id);
        }

        public bool Save()
        {
            return (_insuranceContext.SaveChanges() >= 0);
        }
    }
}
