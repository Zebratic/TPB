using System;

namespace HTX_NINJA.TPB
{
    class DownloadResults
    {
        public Exception Error { get; private set; }
        public PbResultPage SearchPage { get; private set; }

        public DownloadResults(PbResultPage page, Exception ex)
        {
            SearchPage = page;
            Error = ex;
        }
    }
}
