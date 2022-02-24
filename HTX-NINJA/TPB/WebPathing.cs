using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace HTX_NINJA.TPB
{
    internal static class WebPathing
    {
        internal static string Combine(string start, params string[] concats)
        {
            bool retainDoubleSlash = EndsWithFixDuelSlashes(start);
            var SB = new StringBuilder(start.TrimEnd(' ', '/'));

            foreach (string str in concats)
            {
                if (retainDoubleSlash)
                {
                    SB.Append('/');
                    retainDoubleSlash = false;
                }

                SB.Append('/' + str.Trim(' ', '/'));
            }

            return SB.ToString().TrimEnd('/');
        }

        private static bool EndsWithFixDuelSlashes(string path)
        {
            if (path == null) return false;
            string temp = path.Trim(' ');
            if (temp.Length < 2) return false;
            return temp.Substring(temp.Length - 2) == "//";
        }

        internal static string GetHomePage(string path)
        {
            return Regex.Match(path, @"(https?://)?[^/]+", RegexOptions.IgnoreCase).Value;
        }

        internal static bool IsWePage(string path)
        {
            const string PATTERN = @"(\.ca|\.com|\.net|.org)/?$";
            return Regex.IsMatch(path, PATTERN, RegexOptions.IgnoreCase);
        }
    }
}
