using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.Services.Reporting
{
    public interface IReport
    {
        bool Export(string fileName, string fileType);
        bool Save();
    }
}
