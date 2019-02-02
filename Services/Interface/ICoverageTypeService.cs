using GAP.Insurance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services.Interface
{
    public interface ICoverageTypeService
    {
        List<CoverageType> CoverageTypes();

        CoverageType CoverageTypeById(string Id);

        CoverageType AddCoverageType(CoverageType coverageType);

        CoverageType UpdateCoverageType(CoverageType coverageType);

        void DeleteCoverageType(CoverageType coverageType);

    }
}
