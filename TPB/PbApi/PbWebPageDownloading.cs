using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTX_NINJA.TPB
{
    // Default downloader

    /// <summary>
    /// Provides web page downloading, using a global proxy
    /// </summary>
    public static class PbWebPageDownloading
    {
        /// <summary>
        /// Gets or sets the global timeout in milliseconds
        /// </summary>
        public static int GlobalTimout { get; set; }

        /// <summary>
        /// Gets or sets a proxy to use for this downloader
        /// </summary>
        public static WebProxy GlobalProxy { get; set; }

        /// <summary>
        /// Downloads a webpage asyncronously
        /// </summary>
        /// <param name="url">A link to the page</param>
        public static async Task<string> DownloadWebPageAsync(string url)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip;
                handler.Proxy = GlobalProxy;
                handler.UseProxy = GlobalProxy != null;
                handler.AllowAutoRedirect = true;
                try
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        return await wc.DownloadStringTaskAsync(new Uri(url));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return string.Empty;
                }
            }
        }
    }
}