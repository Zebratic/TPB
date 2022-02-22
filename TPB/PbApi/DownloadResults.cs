using System;

namespace TpbForWindows.PbApi
{
    class DownloadResults
    {
        /// <summary>
        /// Gets an Exception from the WebClient used to download the results.
        /// This will be null if everything went well
        /// </summary>
        public Exception Error { get; private set; }
        /// <summary>
        /// Gets the resulting page
        /// </summary>
        public PbResultPage SearchPage { get; private set; }

        public DownloadResults(PbResultPage page, Exception ex)
        {
            SearchPage = page;
            Error = ex;
        }
    }
}
