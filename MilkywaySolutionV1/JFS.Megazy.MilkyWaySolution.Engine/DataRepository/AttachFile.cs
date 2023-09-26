using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JFS.Megazy.MilkyWaySolution.Engine.DataRepository
{
    public class AttachFile
    {
        private string fileLocation;
        private string filetype;
        private int fileid;

        public string Location { get => fileLocation; set => fileLocation = value; }
        public string Type { get => filetype; set => filetype = value; }
        public int FileID { get => fileid; set => fileid = value; }
    }
 
}
