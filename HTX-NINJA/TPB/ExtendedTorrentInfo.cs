using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TPB.Api
{
    /// <summary>
    /// Represents additional info which is retrieved from the torrent page
    /// </summary>
    public class ExtendedTorrentInfo
    {
        /// <summary>
        /// Gets the description (includes HTML formatting)
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Gets an array of user comments
        /// </summary>
        public string[] Comments { get; private set; }
        /// <summary>
        /// Gets the link to the preview image
        /// </summary>
        public string ImageLink { get; private set; }

        /// <summary>
        /// Gets the info hash for this torrent
        /// </summary>
        public string InfoHash { get; private set; }

        /// <summary>
        /// Gets how many files there are for the torrent
        /// </summary>
        public int FileCount { get; private set; }

        protected ExtendedTorrentInfo() { }

        /// <summary>
        /// Loads extended torrent info asyncronously into a new ExtendedTorrentInfo instance
        /// </summary>
        /// <param name="pageLink">The page link to the entended information</param>
        /// <returns>A Task which yeilds ExtendedTorrentInfo</returns>
        public static async Task<ExtendedTorrentInfo> LoadAsync(string pageLink)
        {
            var info = new ExtendedTorrentInfo();
            var content = await PbWebPageDownloading.DownloadWebPageAsync(pageLink);
            // Set description
            Match match = Regex.Match(content, @"\<pre\>\s*(?<Descrip>.+?)\s*\</pre\>", RegexOptions.Singleline);
            if (match.Success) info.Description = match.Groups["Descrip"].Value;
            // Set Comments
            const string PATTERN = @"\<div class=""comment""\>\n*(?<Comment>.+?)\n*\</div\>";
            MatchCollection MC = Regex.Matches(content, PATTERN, RegexOptions.Singleline);
            var comments = new List<string>();
            foreach (Match m in MC)
            {
                string comment = m.Groups["Comment"].Value;
                comment = comment.Replace("<br />", "\n"); // Replace br tags with actual whitespace
                comment = Regex.Replace(comment, @"\</?a[^\>]*?\>", string.Empty); // Remove links
                comments.Add(comment);
            }
            info.Comments = comments.ToArray();
            // Set image link
            match = Regex.Match(content, @"src=""(?<Link>[^""]+)""\s+title=""picture");
            if (match.Success)
                info.ImageLink = WebPathing.Combine("http://" + match.Groups["Link"].Value.TrimStart('/'));
            // Set info hash
            match = Regex.Match(content, @"[A-Z0-9]{25,}");
            if (match.Success) info.InfoHash = match.Value;
            // Set file count
            match = Regex.Match(content, @"<a.+?>(?<Count>\d+)</a>", RegexOptions.Singleline);
            if (match.Success) info.FileCount = int.Parse(match.Groups["Count"].Value);
            return info;
        }
    }
}
