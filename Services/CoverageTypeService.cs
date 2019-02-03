using GAP.Insurance.Context;
using GAP.Insurance.Entities;
using GAP.Insurance.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services
{
    public class CoverageTypeService : ICoverageTypeService
    {
        private readonly InsuranceContext _insuranceContext;

        public CoverageTypeService(InsuranceContext insuranceContext)
        {
            _insuranceContext = insuranceContext;
        }

        public CoverageType AddCoverageType(CoverageType coverageType)
        {
            var coverage = _insuranceContext.CoverageTypes.Add(coverageType);

            return coverage.Entity;
        }

        public CoverageType GetCoverageTypeById(int id)
        {
            return _insuranceContext.CoverageTypes.FirstOrDefault(r => r.Id == id);
        }

        public List<CoverageType> GetCoverageTypes()
        {
            return _insuranceContext.CoverageTypes.ToList<CoverageType>();
        }

        public void DeleteCoverageType(CoverageType coverageType)
        {
            _insuranceContext.CoverageTypes.Remove(coverageType);
        }

        public void UpdateCoverageType(CoverageType coverageType)
        {
            _insuranceContext.CoverageTypes.Update(coverageType);
        }

        public bool CoverageTypeExists(int id)
        {
            return _insuranceContext.CoverageTypes.Any(r => r.Id == id);
        }

        public bool Save()
        {
            return (_insuranceContext.SaveChanges() >= 0);
        }
    }
}
