using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace TPB
{
    /// <summary>
    /// Retrieves a youtube video link that is to be displayed as a torrent preview
    /// </summary>
    class YoutubePreviewer
    {
        private readonly bool _autoStartEnbedded, _appendTrailer;
        private readonly string _movieName;

        public YoutubePreviewer(string movieName, bool appendTrailer, bool autoStartEmbed)
        {
            _movieName = movieName;
            _appendTrailer = appendTrailer;
            _autoStartEnbedded = autoStartEmbed;
        }

        /// <summary>
        /// Gets the link to the trailer asyncronously
        /// </summary>
        public async Task<string> GetLinkAsync()
        {
            using (var webClient = new WebClient())
            {
                Uri uri = new Uri(GetAddress(_movieName));
                var content = await webClient.DownloadStringTaskAsync(uri);
                return GetFirstResultLink(content, _autoStartEnbedded);
            }
        }

        /// <summary>
        /// Returns the first result for now
        /// </summary>
        private static string GetFirstResultLink(string content, bool autoStart)
        {
            const RegexOptions OPTIONS = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            const string OL_PATTERN = @"\<ol class=""item-section""[^\>]*\>(?<Inner>.+?)\</ol\>";
            Match match = Regex.Match(content, OL_PATTERN, OPTIONS);

            if (match.Success)
            {
                string olContent = match.Groups["Inner"].Value;
                // Get partial link
                const string LINK_PATTERN = @"href=""(?<Link>/watch\?v=.+?)""";
                match = Regex.Match(olContent, LINK_PATTERN);

                if (match.Success)
                {
                    if (Settings.Instance.EmbedPreviews)
                    {
                        string partial = match.Groups["Link"].Value;
                        string embedLink = "http://youtube.com/embed/" + partial.Remove(0, 9);
                        if (autoStart) embedLink += "?autoplay=1";
                        return embedLink;
                    }

                    return "http://youtube.com" + match.Groups["Link"].Value;
                }
            }

            return null;
        }

        /// <summary>
        /// Creates a youtube web adress from the torrent name for lookup
        /// </summary>
        private string GetAddress(string torrentName)
        {
            // Make string URL safe
            string searchTerm = HttpUtility.UrlEncode(torrentName);
            if (_appendTrailer) searchTerm += "+trailer";
            searchTerm = searchTerm.Replace('.', '+'); // There will be periods where spaces should be
            return @"http://www.youtube.com/results?search_query=" + searchTerm;
        }
    }
}
