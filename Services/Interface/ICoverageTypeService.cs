using GAP.Insurance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services.Interface
{
    public interface ICoverageTypeService
    {
        List<CoverageType> GetCoverageTypes();

        CoverageType GetCoverageTypeById(int id);

        CoverageType AddCoverageType(CoverageType coverageType);

        void UpdateCoverageType(CoverageType coverageType);

        void DeleteCoverageType(CoverageType coverageType);

        bool CoverageTypeExists(int ind);

        bool Save();

    }
}
