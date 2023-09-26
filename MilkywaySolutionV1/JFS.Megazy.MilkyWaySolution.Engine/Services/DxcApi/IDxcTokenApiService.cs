using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    public interface IDxcTokenApiService
    {
        Task<DxcDataResult> TokenAsync(string code, string code_verifier); 
        Task<DxcDataResult> RefreshTokenAsync(string refresh_token);
    }
}
