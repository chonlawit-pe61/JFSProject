using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JFS.Megazy.MilkyWaySolution.Engine.Structure;
namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class DocumentCheckListResponse : DocumentCheckListGroupData
    {
        public DocumentChecklistOfProjectRow[] DocumentsList { get; set; }
    }
}
