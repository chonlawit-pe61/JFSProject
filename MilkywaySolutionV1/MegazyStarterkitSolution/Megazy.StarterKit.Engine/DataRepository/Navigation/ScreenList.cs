using System.Collections.Generic;

namespace Megazy.StarterKit.Engine.DataRepository.Navigation
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

