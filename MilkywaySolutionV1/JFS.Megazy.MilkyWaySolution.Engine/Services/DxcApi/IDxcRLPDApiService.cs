using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    public interface IDxcRLPDApiService
    {

        Task<DxcDataResult> ComplainantsAsync(string accessToken, string cardID, RLPDFilters filters);
        Task<DxcDataResult> RefreshTokenAsync(string refresh_token);
    }
}
