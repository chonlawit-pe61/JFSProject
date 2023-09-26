using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository.Navigation
{
    public class ScreenList
    {
        //[{"ScreenID":1,"Title":"ศาสนา","Name":"religion","SeqNo":1,"IsActive":1,"ParentScreenID":{}}
        public int ScreenID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int SeqNo { get; set; }
        public bool IsActive { get; set; }
        public int ParentScreenID { get; set; }
        public List<ScreenList> SubScreen { get; set; }
    }
}
    
