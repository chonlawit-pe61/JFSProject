using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Web.DataRepository
{
    public class Breadcrumb
    {
        public string Title { get; set; }
        private string _link = "#";

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public bool IsActive { get; set; }
    }
}