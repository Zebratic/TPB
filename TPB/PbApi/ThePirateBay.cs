using System;
using System.Threading.Tasks;

namespace TpbForWindows.PbApi
{
    /// <summary>
    /// Functionality for downloading data from "ThePirateBay"
    /// </summary>
    static class ThePirateBay
    {
        /// <summary>
        /// Gets the domain of the site
        /// </summary>
        public const string SiteDomain = "https://thepiratebay10.org";

        /// <summary>
        /// Downloads the search results for the given search term asyncronously
        /// </summary>
        public static async Task<DownloadResults> DownloadResultsAsync(PbSearchQuery query)
        {
            string URL = query.ToSearchLink();
            var page = new PbResultPage();
            string content = string.Empty;
            Exception error = null;

            try
            {
                content = await PbWebPageDownloading.DownloadWebPageAsync(URL);
                page.Load(content);
            }
            catch (Exception ex)
            {
                error = ex;
            }
            return new DownloadResults(page, error);
        }
    }
}
