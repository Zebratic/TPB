using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TPB.Api
{
    internal class PbResultPage : ICloneable
    {
        private const string _NAV_FORMAT = @"""(?<Link>[^""]+)""\s*>\s*<\s?img src\s?=\s?""/static/img/{0}\.gif";
        private string _content;

        #region Properties
        /// <summary>
        /// Gets whether there are any torrent results found
        /// </summary>
        public bool HasResults
        {
            get { return Torrents != null && Torrents.Length > 0; }
        }

        /// <summary>
        /// Gets whether any content has been loaded
        /// </summary>
        public bool Loaded { get; private set; }

        /// <summary>
        /// Gets the current page of search results
        /// </summary>
        public int PageNumber { get; private set; }

        /// <summary>
        /// Gets the total amount of search result pages
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Gets an array of torrents displayed by this page
        /// </summary>
        public TorrentInfo[] Torrents { get; private set; }

        /// <summary>
        /// Gets the link to the next page of the search results
        /// </summary>
        public string NextPageLink { get; private set; }

        /// <summary>
        /// Gets the link to the previous page of the search results
        /// </summary>
        public string PreviousPageLink { get; private set; }

        /// <summary>
        /// Gets whether the next page link is available
        /// </summary>
        public bool HasNextPage
        {
            get { return NextPageLink != null; }
        }

        /// <summary>
        /// Gets whether the previous page link is available
        /// </summary>
        public bool HasPreviousPage
        {
            get { return PreviousPageLink != null; }
        }
        #endregion

        /// <summary>
        /// Load a page from content
        /// </summary>
        /// <param name="content">The contents of a search results page</param>
        public void Load(string content)
        {
            _content = content;
            Torrents = GetTorrents();
            PreviousPageLink = PageNumber == 1 ? null : GetNavLink(false);
            SetCurrentPageNumber();
            NextPageLink = GetNavLink(true);
            TotalPages = GetTotalPages();
            Loaded = true;
        }

        /// <summary>
        /// Reverts the page to its empty state
        /// </summary>
        public void Reset()
        {
            _content = null;
            Torrents = null;
            PreviousPageLink = null;
            NextPageLink = null;
            TotalPages = 0;
            Loaded = false;
        }

        /// <summary>
        /// Gets an array of torrents that are within the results page
        /// </summary>
        /// <returns>Returns an empty array if no torrent found</returns>
        public TorrentInfo[] GetTorrents()
        {
            const RegexOptions OPTIONS = RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace;
            // Get the content of the search result table
            const string TABLE_PATTERN = @"<table\s+id=""searchResult"">(?<Content>.+?)</table>";
            Match match = Regex.Match(_content, TABLE_PATTERN, OPTIONS);
            string table = match.Groups["Content"].Value;
            if (table == string.Empty)  return new TorrentInfo[] { };
            // Get the content of table rows
            const string ROW_PAT = @"\<tr[^\>]*?\>(?<Content>.+?)\</tr\>";
            MatchCollection MC = Regex.Matches(_content, ROW_PAT, OPTIONS);
            var tableRows = (from Match temp in MC select temp.Groups["Content"].Value);
            // Construct torrents from table rows
            var torrents = new List<TorrentInfo>();
            string[] rows = tableRows.ToArray();
            // Skip first element which is not a result

            for (int i = 1; i < rows.Length - 1; i++)
            {
                TorrentInfo torrent = GetTorrentFromRow(rows[i]);
                torrents.Add(torrent);
            }

            return torrents.ToArray();
        }

        private static TorrentInfo GetTorrentFromRow(string html)
        {
            // Set page link
            string pageLink = null;
            Match match = Regex.Match(html, @"href=""(?<Link>/torrent[^""]+)""");
            if (match.Success) pageLink = WebPathing.Combine(ThePirateBay.SiteDomain, match.Groups["Link"].Value);
            // Set title
            string title = null;
            match = Regex.Match(html, @"class=""detLink""\s+title=""(?<Title>[^""]+)""");

            if (match.Success) 
            {
                //                                  Removes "details for"
                title = match.Groups["Title"].Value.Remove(0, 11);
                title = HttpUtility.HtmlDecode(title); // Translate accented characters
            }

            // Set magnet link
            string magnetLink = null;
            match = Regex.Match(html, @"a href=""(?<Link>magnet[^""]+)""");
            if (match.Success) magnetLink = match.Groups["Link"].Value;

            // Set size
            DataSizeUnit unit;
            float size;
            SetSizeValues(html, out size, out unit);

            // Set seeds and leeches
            int seeds = -1, leeches = -1;
            MatchCollection MC = Regex.Matches(html, @"\<td align=""right""\>(?<Value>\d+)\</td\>");

            if (MC.Count == 2)
            {
                if (MC[0].Success) seeds = int.Parse(MC[0].Groups["Value"].Value);
                if (MC[1].Success) leeches = int.Parse(MC[1].Groups["Value"].Value);
            }

            // Set Category
            string subCategory = null;
            string category = null;
            //const string PATTERN = @"title=""More from this category""\>(?<Caption>.+?)\</a\>";
            const string PATTERN = @"\<a href=""/browse/\d+"" title=""More from this category""\>(?<Caption>.+?)\</a\>";
            MC = Regex.Matches(html, PATTERN);

            if (MC.Count == 2)
            {
                if (MC[0].Success) category = MC[0].Groups["Caption"].Value;
                if (MC[1].Success) subCategory = MC[1].Groups["Caption"].Value;
            }

            // Set uploaderName
            string uploaderName = null;
            match = Regex.Match(html, @"href=""/user/(?<Name>[^/]+?)/""", RegexOptions.IgnoreCase);
            if (match.Success) uploaderName = HttpUtility.HtmlDecode(match.Groups["Name"].Value);

            var torrent = new TorrentInfo(pageLink, magnetLink, title, category, subCategory, uploaderName, seeds, leeches, size, unit);
            return torrent;
        }

        private static void SetSizeValues(string html, out float size, out DataSizeUnit unit)
        {
            unit = DataSizeUnit.Unknown;
            size = -1;
            Match match = Regex.Match(html, @"Size\s+(?<Size>[\d\.]+?)&nbsp;(?<Unit>(M|G|K)iB)");

            if (match.Success)
            {
                string strSize = match.Groups["Size"].Value;
                size = float.Parse(strSize, CultureInfo.InvariantCulture);
                string strUnit = match.Groups["Unit"].Value.ToLower();

                switch (strUnit)
                {
                    case "kib": unit = DataSizeUnit.KB; break;
                    case "mib":  unit = DataSizeUnit.MB; break;
                    case "gib": unit = DataSizeUnit.GB; break;
                    default: unit = DataSizeUnit.Unknown; break;
                }
            }
        }

        /// <summary>
        /// Gets a navigation link, either next or previous page
        /// </summary>
        /// <param name="isNext">Determines whether to yeild the next or previous page link</param>
        private string GetNavLink(bool isNext)
        {
            string id = isNext ? "next" : "prev";
            string pattern = string.Format(_NAV_FORMAT, id);
            Match match = Regex.Match(_content, pattern, RegexOptions.IgnoreCase);
            string linkPart = match.Groups["Link"].Value;
            if (linkPart == string.Empty) return null;
            return WebPathing.Combine(ThePirateBay.SiteDomain, match.Groups["Link"].Value);
        }

        /// <summary>
        /// Gets the total amount of pages of results there are
        /// </summary>
        private int GetTotalPages()
        {
            const string PATTERN = @"search/.+?/(?<Page>\d{1,3})";
            MatchCollection MC = Regex.Matches(_content, PATTERN, RegexOptions.IgnoreCase);
            int highestNum = 0;

            foreach (Match match in MC)
            {
                int num = int.Parse(match.Groups["Page"].Value);
                if (num > highestNum) highestNum = num;
            }

            return highestNum + 1;
        }

        /// <summary>
        /// Sets the current page by analyzing the previous page link
        /// </summary>
        private void SetCurrentPageNumber()
        {
            if (PreviousPageLink == null)
            {
                PageNumber = 1;
            }
            else
            {
                const string PATTERN = @"search/[^/]+?/(?<Page>\d+)";
                Match match = Regex.Match(PreviousPageLink, PATTERN);

                if (match.Success)
                {
                    // Add 2 to compesate for offset around 0 and previous page num
                    PageNumber = int.Parse(match.Groups["Page"].Value) + 2;
                }
                else
                {
                    PageNumber = -1;
                }
            }
        }

        public object Clone()
        {
            var page = new PbResultPage();
            page.Load(_content);
            return page;
        }

        public override bool Equals(object obj)
        {
            var page = obj as PbResultPage;
            if (page == null) return false;

            return NextPageLink == page.NextPageLink && 
                PreviousPageLink == page.PreviousPageLink;
        }
    }
}
