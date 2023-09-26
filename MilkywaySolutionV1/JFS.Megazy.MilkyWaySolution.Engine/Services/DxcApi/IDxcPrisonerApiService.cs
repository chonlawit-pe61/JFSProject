using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{    
    public interface IDxcPrisonerApiService
    {
        Task<DxcPrisonerResult> PrisonerAsync(string accessToken, string cardID, ProbationerFilters filters);
    }
}
