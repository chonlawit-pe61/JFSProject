using JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Dxc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.DxcApi
{
    //บริการ ค้นหาข้อมูลอายัดผู้ต้องขัง รท.
    //Base URL: api.dxc.go.th/services/dxc-qm-doc-reg-seize-service/api/v2/doc/reg-seize
    public interface IDxcSeizeApiService
    {
        Task<DxcSeizeResult> SeizeAsync(string accessToken, string cardID, SeizeFilters filters);
    }
}
