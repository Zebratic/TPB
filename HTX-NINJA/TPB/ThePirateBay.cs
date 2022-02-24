using System;
using System.Threading.Tasks;

namespace HTX_NINJA.TPB
{
    static class ThePirateBay
    {
        public const string SiteDomain = "https://thepiratebay10.org";
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
