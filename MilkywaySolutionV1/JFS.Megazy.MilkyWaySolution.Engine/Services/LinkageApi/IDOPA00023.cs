using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.LinkageApi
{
    public interface IDOPA00023Service
    {
        Task<bool> PrisonerAsync(string accessToken, string cardID, LinkageFilters filters);
    }
}
