using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Megazy.StarterKit.Mvc.Controllers
{
    [RoutePrefix("")]
   // [Route("{action = index}")]
    public class HomeController : BaseController
    {
        // eg.: /     
        public ActionResult Index()
        {
            SetMetaHtml(new ComponentHead
            {
                Title = "ชื่อหน้า",
                MetaDescription = "คำอธิบายหน้า",
                MetaKeywords = "คีย์เวิร์ด 1,คีย์เวิร์ด 2,คีย์เวิร์ด 3",
                Canonical="www.xxxx.com/about" // Optional:URL หน้า 
            });
            return View();
        }
        // eg.: /about
        // eg.: /en/about
        [Route("about", Order = 1)]
        [Route("{lang:local}/{page:values(about)}", Order = 2)]
        public ActionResult About()
        {
            SetMetaHtml(new ComponentHead
            {
                Title = "เกี่ยวกับเรา",
                MetaDescription = "คำอธิบายเกี่ยวกับเรา",
                MetaKeywords = "คีย์เวิร์ด 1,คีย์เวิร์ด 2,คีย์เวิร์ด 3",
                Canonical = "www.xxxx.com/about" // Optional:URL หน้า 
            });
            return View();
        }
        // eg.: /contact
        // eg.: /en/contact
        [Route("contact")]
        [Route("{lang:local}/contact")]
        public ActionResult Contact()
        {
             return View();
        }
        // eg.: /exampleone
        // eg.: /en/exampleone
        [Route("exampleone", Order = 1)]
        [Route("{lang:local}/exampleone", Order = 2)]
        public ActionResult ExampleOne()
        {

            return View();
        }
    }
}