using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HTX_NINJA.TPB;
using HTX_NINJA.Views.Forms;

namespace HTX_NINJA.Views.Controls
{
    class TorrentPanel : Panel
    {
        [Description("The first alternating color")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "226, 221, 218")]
        public Color AlternateColor1 { get; set; }

        [Description("The second alternating color")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "250, 245, 244")]
        public Color AlternateColor2 { get; set; }

        [Description("The double-click mode for the torrent strips")]
        [Category("Behavior")]
        public TorrentDoubleClickMode DefaultStripDoubleClickMode { get; set; }

        /// <summary>
        /// Gets whether a torrent control is currently hovered
        /// </summary>
        public bool TorrentHovered
        {
            get
            {
                foreach (Control control in Controls)
                {
                    var torrent = control as TorrentStrip;
                    if (torrent != null && torrent.Hovered) return true;
                }

                return false;
            }
        }

        public TorrentPanel()
        {
            AlternateColor1 = Color.FromArgb(226, 221, 218);
            AlternateColor2 = Color.FromArgb(250, 245, 244);
        }

        /// <summary>
        /// Creates a number of TorrentDisplays from the specified TorrentInfo's
        /// </summary>
        private IEnumerable<TorrentStrip> CreateTorrentDisplays(IEnumerable<TorrentInfo> infos)
        {
            bool alternater = false;
            var displays = new List<TorrentStrip>();

            foreach (TorrentInfo torrent in infos)
            {
                // If we are excluding pornos, and is porno
                if (Settings.Instance.ExcludePorn && torrent.Category == TorrentCategory.Porn)
                    continue;

                var display = new TorrentStrip(torrent);
                display.StripDoubleClickMode = DefaultStripDoubleClickMode;
                display.Dock = DockStyle.Top;
                alternater = !alternater; // We cannot use IsOdd because of the filter so do this
                display.BackColor = alternater ? AlternateColor1 : AlternateColor2;
                displays.Add(display);
            }

            return displays;
        }

        /// <summary>
        /// Clears the current torrents and adds an array of new ones
        /// </summary>
        public void DisplayTorrents(params TorrentInfo[] torrents)
        {
            var displays = CreateTorrentDisplays(torrents);
            SuspendLayout();
            Controls.Clear();
            Controls.AddRange(displays.ToArray());
            ResumeLayout();
        }
    }
}
