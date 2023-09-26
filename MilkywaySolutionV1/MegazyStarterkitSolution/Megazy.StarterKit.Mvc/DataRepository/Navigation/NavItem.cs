using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Megazy.StarterKit.Mvc.DataRepository.Navigation
{
    public class NavItem
    {
        // public string UserType { get; set; } = string.Empty;
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleTitle { get; set; }
        public string IconName { get; set; }
        public int SortOrder { get; set; }
        public List<ScreenList> Screen { get; set; } = new List<ScreenList>();
    }
    public class Module {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleTitle { get; set; }
        public string IconName { get; set; }
        public int SortOrder { get; set; }
        public List<ScreenList> Screen { get; set; } = new List<ScreenList>();

    }
     public class TempModule {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleTitle { get; set; }
        public string IconName { get; set; }
        public int SortOrder { get; set; }
        public string Screen { get; set; }
        //public List<ScreenList> Screen { get; set; } = new List<ScreenList>();

    }


}
