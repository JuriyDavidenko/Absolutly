using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Absolutly
{
    public static class StringEx
    {
        public const RegexOptions DEFAULT_REGEX_OPTIONS = RegexOptions.Multiline;

        public static bool EqualsForced(this string s, string str) => 
            (s.Trim().ToLower() == str.Trim().ToLower());

        public static bool EqualsWithoutCase(this string s, string str) => 
            (s.ToLower() == str.ToLower());

        public static string FindRegex(this string s, string re, RegexOptions opt = DEFAULT_REGEX_OPTIONS)
        {
            Match match = new Regex(re, opt).Match(s);
            return (!match.Success ? string.Empty : match.Value);
        }

        public static string FindRegex(this string s, string re, string gpName, RegexOptions opt = DEFAULT_REGEX_OPTIONS)
        {
            Match match = new Regex(re, opt).Match(s);
            return (!match.Groups[gpName].Success ? string.Empty : match.Groups[gpName].Value);
        }

        public static string[] FindRegexAll(this string s, string re, string gpName, RegexOptions opt = DEFAULT_REGEX_OPTIONS)
        {
            List<string> list = new List<string>();
            for (Match match = new Regex(re, opt).Match(s); match.Groups[gpName].Success; match = match.NextMatch())
            {
                list.Add(match.Groups[gpName].Value);
            }
            return list.ToArray();
        }

        public static string[] FindRegexAll(this string s, string re, RegexOptions opt = DEFAULT_REGEX_OPTIONS, params string[] gpName)
        {
            var list = new List<string>();
            var regex = new Regex(re, opt);
            var mc = regex.Matches(s);
            foreach (Match m in mc)
            {
                if (!m.Success) continue;
                bool first = true;
                foreach (Group gp in m.Groups)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }
                    if (gp.Success) list.Add(gp.Value);
                }
            }
            return list.ToArray();
        }

        public static char Index(this string s, int pos) => 
            ((pos >= 0) ? s[pos] : s[s.Length + pos]);

        public static bool IsNullOrEmpty(this string s) => 
            string.IsNullOrEmpty(s);

        public static bool IsNullOrWhiteSpace(this string s) => 
            string.IsNullOrWhiteSpace(s);

        public static bool IsRegexSuccess(this string s, string re) => 
            new Regex(re).Match(s).Success;

        public static bool IsUrl(this string s) => 
            new Regex(@"^https?//\S+$", RegexOptions.IgnoreCase).Match(s).Success;

        public static string JoinBy(this string[] s, string separator) => 
            string.Join(separator, s);

        public static float ToFloat(this string s)
        {
            int num;
            float num2;
            return (!s.Replace('.', ',').Contains<char>(',') ? (int.TryParse(s, out num) ? (num * 1f) : 0f) : (float.TryParse(s, out num2) ? num2 : 0f));
        }

        public static int ToInt(this string s)
        {
            int num;
            return (int.TryParse(s, out num) ? num : 0);
        }
    }
}

