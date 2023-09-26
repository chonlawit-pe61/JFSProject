using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class SysMailConfigInfo
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Smtp { get; set; }
        public int SmtpPort { get; set; }
        public bool IsSsl { get; set; }
    }
}