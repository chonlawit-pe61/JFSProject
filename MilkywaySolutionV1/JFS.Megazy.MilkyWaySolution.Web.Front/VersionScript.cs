using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public static class VersionScript
    {
        //--http://www.c-sharpcorner.com/article/asp-net-mvc-performance-bundling-and-minification/
        public static string StyleVersion
        {
            get
            {
                return "<link href=\"{0}?v=" + ConfigurationManager.AppSettings["StyleVersion"] + "\" rel=\"stylesheet\"/>";
            }
        }
        public static string ScriptVersion
        {
            get
            {
                return "<script src=\"{0}?v=" + ConfigurationManager.AppSettings["ScriptVersion"] + "\"></script>";
            }
        }
    }
}