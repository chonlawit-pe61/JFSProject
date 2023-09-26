using System;
using System.Web.Mvc;

namespace Megazy.StarterKit.Engine.Mvc
{
    public class ErrorController : Controller
    {
        public ActionResult Index(int statusCode, Exception exception, bool isAjaxRequet)
        {
            Response.TrySkipIisCustomErrors = true;
            Response.StatusCode = statusCode;

            // If it's not an AJAX request that triggered this action then just retun the view
            if (!isAjaxRequet)
            {
                string title = "";
                if (statusCode == 404)
                {
                    title = "ขออภัย ไม่พบหน้าเว็บไซต์ที่ต้องการ";
                }
                else if (statusCode == 500)
                {
                    title = "ขออภัย พบข้อผิดพลาด";
                }

                ErrorUtility.RedirectPage(title, statusCode);
                return null;
            }
            else
            {
                // Otherwise, if it was an AJAX request, return an anon type with the message from the exception
                var errorObjet = new { message = exception.Message };
                return Json(errorObjet, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Show(string title = "Web Starter Kit", int statusCode = 200)
        {
            ViewBag.Title = title;
            ViewBag.StatusCode = statusCode;

            return View();
        }

    }
}