using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace Megazy.StarterKit.Mvc
{
    public static class HtmlExtensions
    {
        //public static MvcHtmlString Script(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        //{
        //    htmlHelper.ViewContext.HttpContext.Items["_script_" + Guid.NewGuid()] = template;
        //    return MvcHtmlString.Empty;
        //}

        //public static IHtmlString RenderScripts(this HtmlHelper htmlHelper)
        //{
        //    foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
        //    {
        //        if (key.ToString().StartsWith("_script_"))
        //        {
        //            var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
        //            if (template != null)
        //            {
        //                htmlHelper.ViewContext.Writer.Write(template(null));
        //            }
        //        }
        //    }
        //    return MvcHtmlString.Empty;
        //}

        //public static MvcHtmlString ModalHtml(this HtmlHelper htmlHelper, Func<object, HelperResult> template)
        //{
        //    htmlHelper.ViewContext.HttpContext.Items["_modal_" + Guid.NewGuid()] = template;
        //    return MvcHtmlString.Empty;
        //}

        //public static IHtmlString RenderModalHtml(this HtmlHelper htmlHelper)
        //{
        //    foreach (object key in htmlHelper.ViewContext.HttpContext.Items.Keys)
        //    {
        //        if (key.ToString().StartsWith("_modal_"))
        //        {
        //            var template = htmlHelper.ViewContext.HttpContext.Items[key] as Func<object, HelperResult>;
        //            if (template != null)
        //            {
        //                htmlHelper.ViewContext.Writer.Write(template(null));
        //            }
        //        }
        //    }
        //    return MvcHtmlString.Empty;
        //}

        public static IHtmlString Resource(this HtmlHelper HtmlHelper, Func<object, HelperResult> Template, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null) ((List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type]).Add(Template);
            else HtmlHelper.ViewContext.HttpContext.Items[Type] = new List<Func<object, HelperResult>>() { Template };

            return new HtmlString(String.Empty);
        }

        public static IHtmlString RenderResources(this HtmlHelper HtmlHelper, string Type)
        {
            if (HtmlHelper.ViewContext.HttpContext.Items[Type] != null)
            {
                List<Func<object, HelperResult>> Resources = (List<Func<object, HelperResult>>)HtmlHelper.ViewContext.HttpContext.Items[Type];

                foreach (var Resource in Resources)
                {
                    if (Resource != null) HtmlHelper.ViewContext.Writer.Write(Resource(null));
                }
            }

            return new HtmlString(String.Empty);
        }
    }
}