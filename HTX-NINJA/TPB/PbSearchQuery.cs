using System;
using System.Text;
using System.Text.RegularExpressions;

namespace HTX_NINJA.TPB
{
    class PbSearchQuery
    {
        public string Term { get; private set; }
        public int PageIndex { get; private set; }
        public PbSortMode SortMode { get; private set; }
        public TorrentCategory Categories { get; private set; }
        public PbSearchQuery(string term, PbSortMode sortMode, TorrentCategory filter, int pageIndex = 0)
        {
            Term = term;
            PageIndex = pageIndex;
            SortMode = sortMode;
            Categories = filter;
        }

        public static PbSearchQuery FromSearchLink(string searchUrl)
        {
            const string PATTERN = @"search/(?<Term>[^/]+)(/(?<PageIndex>\d+)/(?<Sort>\d+)/(?<Filter>[\d,]+))?";
            Match match = Regex.Match(searchUrl, PATTERN);

            if (match.Success)
            {
                string term = match.Groups["Term"].Value;
                int pageIndex = 0;
                int sort = 99;
                var category = TorrentCategory.None;

                if (match.Groups["PageIndex"].Success) // If the first number is a success then they all are
                {
                    pageIndex = int.Parse(match.Groups["PageIndex"].Value);
                    sort = int.Parse(match.Groups["Sort"].Value);
                    category = CategoriesFromString(match.Groups["Filter"].Value);
                }

                return new PbSearchQuery(term, (PbSortMode)sort, category, pageIndex);
            }

            return null;
        }

        public string ToSearchLink()
        {
            return ThePirateBay.SiteDomain + "/" + "search/" + Term + "/" + PageIndex + 
                "/" + ((int) SortMode) + "/" + CategoriesToString(Categories);
        }

        private static string CategoriesToString(TorrentCategory categories)
        {
            if (categories == TorrentCategory.None) return "0";

            var SB = new StringBuilder();
            if (categories.HasFlag(TorrentCategory.Audio)) SB.Append(100 + ",");
            if (categories.HasFlag(TorrentCategory.Video)) SB.Append(200 + ",");
            if (categories.HasFlag(TorrentCategory.Applications)) SB.Append(300 + ",");
            if (categories.HasFlag(TorrentCategory.Games)) SB.Append(400 + ",");
            return SB.ToString().TrimEnd(',');
        }

        private static TorrentCategory CategoriesFromString(string str)
        {
            string[] strNumbers = str.Split(new [] {','}, StringSplitOptions.RemoveEmptyEntries);
            var filter = TorrentCategory.None;

            foreach (string strNum in strNumbers)
            {
                switch (strNum)
                {
                    case "0": return TorrentCategory.None;
                    case "100": filter |= TorrentCategory.Audio; break;
                    case "200": filter |= TorrentCategory.Video; break;
                    case "300": filter |= TorrentCategory.Applications; break;
                    case "400": filter |= TorrentCategory.Games; break;
                    default: throw new ArgumentException("Invalid number in array");
                }
            }

            return filter;
        }
    }
}
