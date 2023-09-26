using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megazy.StarterKit.Mvc.DataRepository.Navigation
{
    public class ScreenList
    {
        public int ScreenID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int SeqNo { get; set; }
        public bool IsActive { get; set; }
        public int ParentScreenID { get; set; }
        public List<ScreenList> SubScreen { get; set; }
    }
}
    
