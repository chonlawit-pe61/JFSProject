﻿using System;
using System.Web;
using System.Globalization;
using System.Threading;

namespace Megazy.StarterKit.Mvc
{
    public class CultureLanguage
    {
        const string cookieName = "lng";
        public string SetCurrentLanguage(string language)
        {
            //Set value to existing cookie
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                HttpContext.Current.Request.Cookies[cookieName]["Culture"] = language;
                HttpContext.Current.Request.Cookies[cookieName].Expires = DateTime.Now.AddDays(7);
                HttpContext.Current.Response.Cookies.Set(HttpContext.Current.Request.Cookies[cookieName]);
            }
            else
            {
                HttpCookie cookie = new HttpCookie(cookieName);
                cookie["Culture"] = "th";
                cookie.Expires = DateTime.Now.AddDays(7);
                HttpContext.Current.Response.Cookies.Add(cookie);
                language = "th";
            }
            CultureInfo culture = CultureInfo.GetCultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            return language;
        }
        public static string GetCurrentLanguage()
        {
            string language = "th";
            if (HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                language = HttpContext.Current.Request.Cookies[cookieName]["Culture"];

                if (language == null)
                {
                    //some cases could not read cookie
                    language = "th";
                }
            }
            return language;
        }
        /*
        public static string GetLanguagePath()
        {

            string language = string.Empty;

            if (System.Web.HttpContext.Current.Request.Cookies["LANGUAGE"] != null)
            {
                language = System.Web.HttpContext.Current.Request.Cookies["LANGUAGE"]["Culture"];

                if (language == null)
                {
                    //some cases could not read cookie
                    language = "th";
                }
            }
            else
            {
                HttpCookie cookie = new HttpCookie("LANGUAGE");
                cookie["Culture"] = "th";
                cookie.Expires = DateTime.Now.AddDays(7);
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);

                language = "th";
            }

            return @"/" + language;

        }
        */
        public static string GetCurrentLanguageByPath(string originalPath)
        {


            CultureLanguage cultureLanguage = new CultureLanguage();
            string lang;
            if (originalPath.Trim().Length == 3)
            {
                if (originalPath.StartsWith("/en") == true)
                {
                    cultureLanguage.SetCurrentLanguage("en");
                    lang = "en";
                }
                else if (originalPath.StartsWith("/zh") == true)
                {
                    cultureLanguage.SetCurrentLanguage("zh");
                    lang = "zh";
                }
                else
                {
                    cultureLanguage.SetCurrentLanguage("th");
                    lang = "th";
                }
            }
            else if (originalPath.Trim().Length > 3)
            {
                if (originalPath.StartsWith("/en/") == true)
                {
                    cultureLanguage.SetCurrentLanguage("en");
                    lang = "en";
                }
                else if (originalPath.StartsWith("/zh") == true)
                {
                    cultureLanguage.SetCurrentLanguage("zh");
                    lang = "zh";
                }
                else
                {
                    cultureLanguage.SetCurrentLanguage("th");
                    lang = "th";
                }
            }
            else
            {
                cultureLanguage.SetCurrentLanguage("th");
                lang = "th";
            }

            //CultureInfo culture = CultureInfo.GetCultureInfo(lang);
            //Thread.CurrentThread.CurrentUICulture = culture;
            //Thread.CurrentThread.CurrentCulture = culture;


            //CurrentUICulture refers to the default user interface language, a setting introduced in Windows 2000. This is primarily regarding the UI localization/translation part of your app.
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(lang);
            //CurrentCulture is the.NET representation of the default user locale of the system.This controls default number and date formatting and the like.
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en");
            return lang;

        }


    }
}
