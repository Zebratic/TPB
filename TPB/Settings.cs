using AboPersistance;
using System;
using System.Drawing;
using System.Net;
using TpbForWindows.PbApi;

namespace TpbForWindows
{
    /// <summary>
    /// Specifies the behavior of a torrent when it is double-clicked
    /// </summary>
    public enum TorrentDoubleClickMode
    {
        /// <summary>
        /// Opens extended info about the torrent
        /// </summary>
        OpenExtendedInfo,
        /// <summary>
        /// Downloads the magnet for the torrent item
        /// </summary>
        DownloadMagnet,
        /// <summary>
        /// Shows a YoutTube preview for the torrent
        /// </summary>
        ShowPreview
    }

    [Serializable]
    class Settings : SettingsBase<Settings>
    {
        /// <summary>
        /// Gets or sets the last size of the YouTube preview
        /// </summary>
        public Size LastPreviewSize { get; set; }

        /// <summary>
        /// Gets or sets the last size of the mainform
        /// </summary>
        public Size LastFormSize { get; set; }

        /// <summary>
        /// Gets or sets the double-click behavior of the torrent strips
        /// </summary>
        public TorrentDoubleClickMode TorrentStripDoubleClickMode { get; set; }

        /// <summary>
        /// Gets or sets the torrent filter/categories
        /// </summary>
        public TorrentCategory TorrentCatergories { get; set; }

        /// <summary>
        /// Gets or sets how to sort the torrents
        /// </summary>
        public PbSortMode SortMode { get; set; }

        /// <summary>
        /// Gets or sets an optional proxy
        /// </summary>
        public WebProxy Proxy { get; set; }

        /// <summary>
        /// Gets or sets the search term
        /// </summary>
        public string SearchTerm { get; set; }

        /// <summary>
        /// Gets or sets whether to exclude pornography torrents
        /// </summary>
        public bool ExcludePorn { get; set; }

        /// <summary>
        /// Gets or sets whether to show sub-catergories
        /// </summary>
        public bool ShowSubCategories { get; set; }

        /// <summary>
        /// Gets or sets whether to embed previews
        /// </summary>
        public bool EmbedPreviews { get; set; }

        /// <summary>
        /// Gets or sets whether to automatically start previews
        /// </summary>
        public bool AutoStartPreviews { get; set; }

        /// <summary>
        /// Gets or sets the connection timout
        /// </summary>
        public int Timeout { get; set; }

        public override void Reset()
        {
            LastFormSize = new Size(940, 600);
            LastPreviewSize = new Size(660, 450);
            TorrentStripDoubleClickMode = TorrentDoubleClickMode.OpenExtendedInfo;
            SearchTerm = string.Empty;
            ExcludePorn = true;
            ShowSubCategories = true;
            EmbedPreviews = true;
            AutoStartPreviews = true;
            Timeout = 5000;
            SortMode = PbSortMode.MostSeeded;
        }
    }
}
