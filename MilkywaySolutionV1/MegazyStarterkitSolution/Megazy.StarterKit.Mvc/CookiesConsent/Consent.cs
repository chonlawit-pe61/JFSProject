﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using Megazy.StarterKit.Mvc.App_LocalResources;

namespace Megazy.StarterKit.Mvc.CookiesConsent
{
    public class Consent
    {
        private static object _lock = new object();
        private const string CookieName = "cookie_consented";

        private ICookieService _cookieService = new CookieService();

        /// <summary>
        /// Creates an instance of Consent class
        /// </summary>
        public static Consent Instance
        {
            get
            {
                lock (_lock)
                {
                    return new Consent();
                }
            }
        }

        /// <summary>
        /// Inject HTML that displays warning
        /// </summary>
        /// <param name="linkUrl">URL for 'learn more'</param>
        /// <param name="messageText">Override text for mail message</param>
        /// <param name="learnMoreText">Override text for 'Learn more' link</param>
        /// <param name="okText">Override text for OK button</param>
        /// <returns>HTML string that displays message on the bottom of the web page</returns>
        public string Install(string linkUrl = null, string messageText = null, string learnMoreText = null, string okText = null)
        {
            if (_cookieService.Read(CookieName) != "true")
            {
               //var assembly = Assembly.GetAssembly(typeof(Consent));

                var hasLink = !IsEmpty(linkUrl);

                var fileName = hasLink ? "/script.html" : "/scriptnolink.html";

                var html = new StreamReader(HttpContext.Current.Server.MapPath(fileName)).ReadToEnd();
                //var html = new StreamReader(assembly.GetManifestResourceStream("Tulip.Megazy.TerminatorSolution.WebMvc." + fileName)).ReadToEnd();

                if (hasLink)
                    html = html.Replace("{learnmore}", IsEmpty(learnMoreText)
                                    ? Captions.LearnMore
                                    : learnMoreText)
                                .Replace("{link}", linkUrl);
                //หากต้องการทำให้เปิดขึ้นมาแล้ว กดปิดหรือกดยอมรับ ต้อง set cookies ตรงนี้
                new CookieService().Store(CookieName, "true");

                return html
                    .Replace("{text}", IsEmpty(messageText) ? Captions.Text : messageText)
                    .Replace("{ok}", IsEmpty(okText) ? Captions.Ok : okText);
            }

            return string.Empty;
        }

        private bool IsEmpty(string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        /// <summary>
        /// Replace service for reading/writing cookies. Used for testing, where HttpContext is not available
        /// </summary>
        /// <param name="service">Implementation of ICookieService interface</param>
        /// <returns>return this, just so it can be used fluently:)</returns>
        public Consent SetCookieService(ICookieService service)
        {
            _cookieService = service;
            return this;
        }
    }
}