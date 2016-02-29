using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace WebSite.Comman
{
   public class HtmlFilter
    {
        public static string RemoveHTML(string html)
        {
            html = FilterScript(html);
            html = FilterAHrefScript(html);
            html = FilterSrc(html);
            html = FilterInclude(html);
            html = FilterObject(html);
            html = FilterIframe(html);
            html = FilterFrameset(html);
            html = FilterHtml(html);
            return html;
        }

        public static string RemoveHTMLForEditor(string html)
        {
            html = FilterScript(html);
            html = FilterAHrefScript(html);
            html = FilterSrc(html);
            html = FilterInclude(html);
            html = FilterObject(html);
            html = FilterIframe(html);
            html = FilterFrameset(html);
            return html;
        }

        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }


        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
        }

        public static string ClearBR(string str)
        {
            Regex regex = null;
            Match match = null;
            regex = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
            for (match = regex.Match(str); match.Success; match = match.NextMatch())
            {
                str = str.Replace(match.Groups[0].ToString(), "");
            }
            return str;
        }


        private static string FilterAHrefScript(string content)
        {
            string input = FilterScript(content);
            string pattern = @" href[ ^=]*= *[\s\S]*script *:";
            return Regex.Replace(input, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterFrameset(string content)
        {
            string pattern = @"(?i)<Frameset([^>])*>(\w|\W)*</Frameset([^>])*>";
            return Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterHtml(string content)
        {
            string input = FilterScript(content);
            string pattern = "<[^>]*>";
            return Regex.Replace(input, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterIframe(string content)
        {
            string pattern = @"(?i)<Iframe([^>])*>(\w|\W)*</Iframe([^>])*>";
            return Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterInclude(string content)
        {
            string input = FilterScript(content);
            string pattern = @"<[\s\S]*include *(file|virtual) *= *[\s\S]*\.(js|vbs|asp|aspx|php|jsp)[^>]*>";
            return Regex.Replace(input, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        private static string FilterObject(string content)
        {
            string pattern = @"(?i)<Object([^>])*>(\w|\W)*</Object([^>])*>";
            return Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase);
        }

        public static string FilterScript(string content)
        {
            string str = @"(?'comment'<!--.*?--[ \n\r]*>)";
            string str2 = @"(\/\*.*?\*\/|\/\/.*?[\n\r])";
            string str3 = string.Format(@"(?'script'<[ \n\r]*script[^>]*>(.*?{0}?)*<[ \n\r]*/script[^>]*>)", str2);
            string pattern = string.Format("(?s)({0}|{1})", str, str3);
            return StripScriptAttributesFromTags(Regex.Replace(content, pattern, string.Empty, RegexOptions.IgnoreCase));
        }

        private static string StripScriptAttributesFromTags(string content)
        {
            string str = "on(blur|c(hange|lick)|dblclick|focus|keypress|(key|mouse)(down|up)|(un)?load\r\n                            |mouse(move|o(ut|ver))|reset|s(elect|ubmit))";
            Regex regex = new Regex(string.Format("(?inx)\r\n                \\<(\\w+)\\s+\r\n                    (\r\n                        (?'attribute'\r\n                        (?'attributeName'{0})\\s*=\\s*\r\n                        (?'delim'['\"]?)\r\n                        (?'attributeValue'[^'\">]+)\r\n                        (\\3)\r\n                    )\r\n                    |\r\n                    (?'attribute'\r\n                        (?'attributeName'href)\\s*=\\s*\r\n                        (?'delim'['\"]?)\r\n                        (?'attributeValue'javascript[^'\">]+)\r\n                        (\\3)\r\n                    )\r\n                    |\r\n                    [^>]\r\n                )*\r\n            \\>", str));
            return regex.Replace(content, new MatchEvaluator(StripAttributesHandler));
        }

        private static string StripAttributesHandler(Match m)
        {
            if (m.Groups["attribute"].Success)
            {
                return m.Value.Replace(m.Groups["attribute"].Value, "");
            }
            return m.Value;
        }

        private static string FilterSrc(string content)
        {
            string input = FilterScript(content);
            string pattern = " src *= *['\"]?[^\\.]+\\.(js|vbs|asp|aspx|php|jsp)['\"]";
            return Regex.Replace(input, pattern, "", RegexOptions.IgnoreCase);
        }


    }
}
