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
        private InsuranceContext _insuranceContext;

        public CoverageTypeService(InsuranceContext insuranceContext)
        {
            _insuranceContext = insuranceContext;
        }

        public CoverageType AddCoverageType(CoverageType coverageType)
        {
            var coverage = _insuranceContext.CoverageTypes.Add(coverageType);

            return coverage.Entity;

        }

        public CoverageType CoverageTypeById(string Id)
        {
            throw new NotImplementedException();
        }

        public List<CoverageType> CoverageTypes()
        {
            throw new NotImplementedException();
        }

        public void DeleteCoverageType(CoverageType coverageType)
        {
            throw new NotImplementedException();
        }

        public CoverageType UpdateCoverageType(CoverageType coverageType)
        {
            throw new NotImplementedException();
        }
    }
}
