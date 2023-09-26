using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Megazy.StarterKit.Engine.Mvc.Controllers
{
    public class BaseController : Controller
    {
        public void SetMetaHtml(ComponentHead component)
        {
            StringBuilder sb = new StringBuilder();
            if (component != null)
            {
                if (!string.IsNullOrWhiteSpace(component.Title))
                {
                    ViewBag.Title = component.Title.Trim();

                }
                if (!string.IsNullOrWhiteSpace(component.MetaDescription))
                {
                    ViewBag.MetaDescription = component.MetaDescription.Trim();
                }
                if (!string.IsNullOrEmpty(component.MetaKeywords))
                {
                    ViewBag.MetaKeywords = component.MetaKeywords.Trim();
                }
                if (!string.IsNullOrEmpty(component.Canonical))
                {
                    ViewBag.CanonicalURL = component.Canonical;
                }
                //The Open Graph protocol
                if (component.OgFacebook != null)
                {
                    if (!string.IsNullOrEmpty(component.OgFacebook.ShareURL))
                    {
                        sb.AppendFormat("<meta property=\"og:url\" content=\"{0}\" />", component.OgFacebook.ShareURL).AppendLine();
                    }
                    if (!string.IsNullOrEmpty(component.OgFacebook.Type))
                    {
                        sb.AppendFormat("<meta property=\"og:type\" content=\"{0}\" />", component.OgFacebook.Type).AppendLine();
                    }
                    if (string.IsNullOrEmpty(component.OgFacebook.Title))
                    {
                        component.OgFacebook.Title = component.Title;
                    }
                    sb.AppendFormat("<meta property=\"og:title\" content=\"{0}\" />", component.OgFacebook.Title).AppendLine();

                    if (string.IsNullOrEmpty(component.OgFacebook.Description))
                    {
                        component.OgFacebook.Description = component.MetaDescription;
                    }
                    sb.AppendFormat("<meta property=\"og:description\" content=\"{0}\" />", component.OgFacebook.Description).AppendLine();


                    if (!string.IsNullOrEmpty(component.OgFacebook.SiteName))
                    {
                        sb.AppendFormat("<meta property=\"og:site_name\" content=\"{0}\" />", component.OgFacebook.SiteName).AppendLine();

                    }
                    if (!string.IsNullOrEmpty(component.OgFacebook.AppID))
                    {
                        sb.AppendFormat("<meta property=\"fb:app_id\" content=\"{0}\" />", component.OgFacebook.AppID).AppendLine();
                    }
                    if (!string.IsNullOrEmpty(component.OgFacebook.ImagUrl))
                    {
                        sb.AppendFormat("<meta property=\"og:image\" content=\"{0}\" />", component.OgFacebook.ImagUrl).AppendLine();
                        sb.AppendFormat("<meta property=\"og:image:alt\" content=\"{0}\" />", component.OgFacebook.ImageAlt).AppendLine();
                        sb.AppendFormat("<meta property=\"og:image:type\" content=\"{0}\" />", component.OgFacebook.ImageType).AppendLine();
                        sb.AppendFormat("<meta property=\"og:image:width\" content=\"{0}\" />", component.OgFacebook.ImageCoverWidth).AppendLine();
                        sb.AppendFormat("<meta property=\"og:image:height\" content=\"{0}\" />", component.OgFacebook.ImageCoverHeight).AppendLine();

                    }
                    ViewBag.Og = sb.ToString();

                }
            }

        }
        //public void SetBreadcrumb(List<Breadcrumb> breadcrumb)
        //{
        //    var str = new StringBuilder();
        //    foreach (var item in breadcrumb)
        //    {
        //        if (!item.IsActive)
        //        {
        //            str.AppendFormat("<li class=\"breadcrumb-item\"><a href=\"{0}\">{1}</a></li>", item.Link, item.Title);
        //        }
        //        else
        //        {
        //            str.AppendFormat("<li class=\"active breadcrumb-item\" aria-current=\"page\">{0}</li>", item.Title);
        //        }

        //    }
        //    ViewBag.Breadcrumb = str.ToString();
        //}

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAjaxRequest())
            {
                string lang = CultureLanguage.GetCurrentLanguageByPath(filterContext.HttpContext.Request.Path);
                // string lang  = "th";
                if (lang == "en")
                {
                    ViewBag.pathLang = "/en";
                }
                else if (lang == "zh")
                {
                    ViewBag.pathLang = "/zh";
                }
                else
                {
                    ViewBag.pathLang = "";
                }
                ViewBag.lang = lang;
            }
            base.OnActionExecuting(filterContext);
        }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //string lang = CultureLanguage.GetCurrentLanguageByPath(filterContext.HttpContext.Request.Path);

            //if (lang == "en")
            //{
            //    ViewBag.pathLang = "/en";
            //}
            //else
            //{
            //    ViewBag.pathLang = "";
            //}

            //ViewBag.lang = lang;

            base.OnActionExecuted(filterContext);
        }
    }
}