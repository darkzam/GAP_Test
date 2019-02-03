using GAP.Insurance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GAP.Insurance.Services.Interface
{
    public interface IRiskTypeService
    {
        List<RiskType> GetRiskTypes();

        RiskType GetRiskTypeById(int id);

        RiskType AddRiskType(RiskType RiskType);

        void UpdateRiskType(RiskType RiskType);

        void DeleteRiskType(RiskType RiskType);

        bool RiskTypeExists(int id);

        bool Save();

    }
}
