using System;
using System.Text.RegularExpressions;

namespace HTX_NINJA.TPB
{
    public class TorrentInfo
    {
        public TorrentCategory Category { get; set; }
        public string SubCategory { get; private set; }
        public string PageLink { get; private set; }
        public string MagnetLink { get; private set; }
        public string Title { get; private set; }
        public int Seeds { get; private set; }
        public int Leeches { get; private set; }
        public float ContentSize { get; private set; }
        public string UploaderName { get; private set; }
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
