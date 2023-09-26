using System.Web;
using System.Web.Mvc;

namespace JFS.Megazy.MilkyWaySolution.Web.Front
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
