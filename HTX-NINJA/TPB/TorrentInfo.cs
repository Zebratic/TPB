using System;
using System.Text.RegularExpressions;

namespace TPB.Api
{
    /// <summary>
    /// Represents a torrent on a website
    /// </summary>
    public class TorrentInfo
    {
        /// <summary>
        /// Gets the main category for this torrent
        /// </summary>
        public TorrentCategory Category { get; set; }

        /// <summary>
        /// Gets the name of one of the many sub categories for this torrent
        /// </summary>
        public string SubCategory { get; private set; }

        /// <summary>
        /// Gets the page link of the torrent
        /// </summary>
        public string PageLink { get; private set; }

        /// <summary>
        /// Gets the link to the magnet download
        /// </summary>
        public string MagnetLink { get; private set; }

        /// <summary>
        /// Gets the title of this torrent (to be displayed to the user)
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the seed count for this torrent
        /// </summary>
        public int Seeds { get; private set; }

        /// <summary>
        /// Gets the leech count for this torrent
        /// </summary>
        public int Leeches { get; private set; }

        /// <summary>
        /// Gets the size of the target content as gigs or megs
        /// </summary>
        public float ContentSize { get; private set; }

        /// <summary>
        /// Gets the name of the uploader that has uploaded this torrent
        /// </summary>
        public string UploaderName { get; private set; }

        /// <summary>
        /// Gets the unit of measurement of the size of the torrent download
        /// </summary>
        public DataSizeUnit MeasureUnit { get; private set; }

        public TorrentInfo(string pageLink, string magnetLink, string title, string category, string subCategory, string uploaderName, int seeds, int leeches, float contentSize, DataSizeUnit unit)
        {
            UploaderName = uploaderName;
            PageLink = pageLink;
            MagnetLink = magnetLink;
            Title = title;
            try { Category = (TorrentCategory)Enum.Parse(typeof(TorrentCategory), category); } catch { }
            SubCategory = subCategory;
            Seeds = seeds;
            Leeches = leeches;
            MeasureUnit = unit;
            ContentSize = contentSize;
        }

        /// <summary>
        /// Gets the name of the movie
        /// </summary>
        public string GetMovieName()
        {
            const string PATTERN =
            @"^\s*(?<Name>.+?)[\+.\s-](([\(]?\d{4}[\)]?)
            |xvid|divx|acc|aac|dvdrip|dvdscr|dvdr|br*rip|dvdscreener)";
            const RegexOptions OPTIONS = RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;
            Match match = Regex.Match(Title, PATTERN, OPTIONS);
            return match.Success ? match.Groups["Name"].Value.Replace('.', ' ') : Title;
        }
    }
}
