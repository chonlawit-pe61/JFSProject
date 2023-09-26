using System.Collections.Generic;

namespace Megazy.StarterKit.Engine.DataRepository.Navigation
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
    public class Module
    {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleTitle { get; set; }
        public string IconName { get; set; }
        public int SortOrder { get; set; }
        public List<ScreenList> Screen { get; set; } = new List<ScreenList>();

    }
    public class TempModule
    {
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public string ModuleTitle { get; set; }
        public string IconName { get; set; }
        public int SortOrder { get; set; }
        public string Screen { get; set; }
        //public List<ScreenList> Screen { get; set; } = new List<ScreenList>();

    }


}
