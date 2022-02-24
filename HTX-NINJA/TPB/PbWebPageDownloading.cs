using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace HTX_NINJA.TPB
{
    public static class PbWebPageDownloading
    {
        public static int GlobalTimout { get; set; }
        public static WebProxy GlobalProxy { get; set; }

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