using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace TpbForWindows.PbApi
{
    /// <summary>
    /// Provides functionality for working with web paths
    /// </summary>
    internal static class WebPathing
    {
        /// <summary>
        /// Combines two or more web paths (paths using forward slashes as a seperator).
        /// Each seperate string will be seperated by one slash. If the first
        /// string ends with more than 1 slash, then the first and second strings will be seperated
        /// by two slashes instead of one.
        /// </summary>
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

        /// <summary>
        /// Gets whether the specified string ends with two slashes
        /// </summary>
        private static bool EndsWithFixDuelSlashes(string path)
        {
            if (path == null) return false;
            string temp = path.Trim(' ');
            if (temp.Length < 2) return false;
            return temp.Substring(temp.Length - 2) == "//";
        }

        /// <summary>
        /// Gets the homepage or root of the specified web path.
        /// This only supports http. (includes the protocol if present)
        /// </summary>
        internal static string GetHomePage(string path)
        {
            return Regex.Match(path, @"(https?://)?[^/]+", RegexOptions.IgnoreCase).Value;
        }

        /// <summary>
        /// Gets whether the specified string is a link to a webpage (not a resource or partial)
        /// </summary>
        internal static bool IsWePage(string path)
        {
            const string PATTERN = @"(\.ca|\.com|\.net|.org)/?$";
            return Regex.IsMatch(path, PATTERN, RegexOptions.IgnoreCase);
        }
    }
}
