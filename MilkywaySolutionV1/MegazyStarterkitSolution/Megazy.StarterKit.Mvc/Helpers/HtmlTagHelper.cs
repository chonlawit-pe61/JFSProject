using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Megazy.StarterKit.Mvc.Helpers
{
    public class HtmlTagHelper
    {
        private static readonly Regex _tags_ = new Regex(@"<[^>]+?>", RegexOptions.Multiline | RegexOptions.Compiled);
        //add characters that are should not be removed to this regex
        private static readonly Regex _notOkCharacter_ = new Regex(@"[^\w;&#@.:/\\?=|%!() -]", RegexOptions.Compiled);
        /// <summary>
        /// ลบ HTML Tage
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string UnHtml(string html)
        {
            if (!string.IsNullOrWhiteSpace(html))
            {
                html = HttpUtility.UrlDecode(html);
                html = HttpUtility.HtmlDecode(html);

                html = RemoveTag(html, "<!--", "-->");
                html = RemoveTag(html, "<script", "</script>");
                html = RemoveTag(html, "<style", "</style>");

                //replace matches of these regexes with space
                html = _tags_.Replace(html, " ");
                html = _notOkCharacter_.Replace(html, " ");
                html = SingleSpacedTrim(html);
                html = html.Substring(0, Math.Min(html.Length, 250));
            }
            return html;
        }
        private static string RemoveTag(string html, string startTag, string endTag)
        {
            bool bAgain;
            do
            {
                bAgain = false;
                int startTagPos = html.IndexOf(startTag, 0, StringComparison.CurrentCultureIgnoreCase);
                if (startTagPos < 0)
                    continue;
                int endTagPos = html.IndexOf(endTag, startTagPos + 1, StringComparison.CurrentCultureIgnoreCase);
                if (endTagPos <= startTagPos)
                    continue;
                html = html.Remove(startTagPos, endTagPos - startTagPos + endTag.Length);
                bAgain = true;
            } while (bAgain);
            return html;
        }
        private static string SingleSpacedTrim(string inString)
        {
            StringBuilder sb = new StringBuilder();
            bool inBlanks = false;
            foreach (var c in inString)
            {
                switch (c)
                {
                    case '\r':
                    case '\n':
                    case '\t':
                    case ' ':
                        if (!inBlanks)
                        {
                            inBlanks = true;
                            sb.Append(' ');
                        }
                        continue;
                    default:
                        inBlanks = false;
                        sb.Append(c);
                        break;
                }
            }
            return sb.ToString().Trim();
        }
    }
}
