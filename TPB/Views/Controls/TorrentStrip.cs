using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TpbForWindows.PbApi;
using TpbForWindows.Views.Forms;

namespace TpbForWindows.Views.Controls
{
    // The preview location is saved and restored for the current application session,
    // where the size persists through multiple sessions

    public partial class TorrentStrip : UserControl
    {
        private Color _lastColor;
        private static Point _previewLocation;
        private static PreviewForm _frmPreview;

        private TorrentDoubleClickMode _stripDoubleClickMode;

        [Description("The double-click mode for this control")]
        [Category("Behavior")]
        public TorrentDoubleClickMode StripDoubleClickMode
        {
            get { return _stripDoubleClickMode; }
            set
            {
                if (_stripDoubleClickMode == value) return;
                _stripDoubleClickMode = value;
                // Update existing strips
                foreach (var strip in Controls.OfType<TorrentStrip>())
                    strip.StripDoubleClickMode = value;
            }
        }

        /// <summary>
        /// Gets the torrent associated with this display
        /// </summary>
        public TorrentInfo Torrent { get; private set; }

        /// <summary>
        /// Gets whether this control is hovered by the cursor
        /// </summary>
        [Browsable(false)]
        public bool Hovered { get; private set; }

        public TorrentStrip(TorrentInfo torrent)
        {
            InitializeComponent();
            Torrent = torrent;
            SetTitleToDisplay();
            lblSeeds.Text = torrent.Seeds.ToString();
            lblLeeches.Text = torrent.Leeches.ToString();
            ShowSize();
            lblCategory.Text = torrent.Category.ToString();

            if (Settings.Instance.ShowSubCategories)
            {
                lblCategory.Text += Environment.NewLine + torrent.SubCategory;
            }
        }

        private void ShowSize()
        {
            var unit = Torrent.MeasureUnit.ToString();

            float size = Torrent.ContentSize;

            if (Torrent.MeasureUnit == DataSizeUnit.MB || 
                Torrent.MeasureUnit == DataSizeUnit.KB)
                size = (int)(size + 0.5f); // Round for smaller units

            lblSize.Text = size + " " + unit;
        }

        /// <summary>
        /// Sets the torrents display title to a processed version
        /// </summary>
        private void SetTitleToDisplay()
        {
            // Replace periods (that do not seem to be an extension) with space 
            // Replace underscores with space
            const string PATTERN = @"(\.(?!\w{1,4}$))|_";
            string text = Regex.Replace(Torrent.Title, PATTERN, " ");
            // Wrap years in paranthesis
            text = Regex.Replace(text, @"(\{|\(|\[)(\d{4})(\)|\}|\])", "($2)");
            text = Regex.Replace(text, @" (\d{4}) ", " ($1) ");
            lblTorrentName.Text = text;
        }

        private async void Labels_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            switch (Settings.Instance.TorrentStripDoubleClickMode)
            {
                case TorrentDoubleClickMode.OpenExtendedInfo:
                    var info = await ExtendedTorrentInfo.LoadAsync(Torrent.PageLink);
                    new ExtendedInfoForm(info).Show();
                    break;

                case TorrentDoubleClickMode.DownloadMagnet:
                    Program.Start(Torrent.MagnetLink);
                    break;

                case TorrentDoubleClickMode.ShowPreview:
                    ShowYoutubePreview();
                    break;
            }
        }

        private void btnMagnet_Click(object sender, EventArgs e)
        {
            btnMagnet.Enabled = false;
            Program.Start(Torrent.MagnetLink);
            btnMagnet.Enabled = true;
        }

        private void lblTorrentName_Click(object sender, EventArgs e)
        {
            OnClick(e);
            Focus(); // Make panel scrollable by mouse wheel
        }

        private void Universal_MouseEnter(object sender, EventArgs e)
        {
            _lastColor = BackColor;
            BackColor = Color.White;
            Hovered = true;
        }

        private void Universal_MouseLeave(object sender, EventArgs e)
        {
            BackColor = _lastColor;
            Hovered = false;
        }

        private async void ShowYoutubePreview()
        {
            var previewer = new YoutubePreviewer(Torrent.GetMovieName(), true, Settings.Instance.AutoStartPreviews);
            var link = await previewer.GetLinkAsync();

            if (string.IsNullOrEmpty(link))
            {
                MessageBox.Show("No YouTube results yielded", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_frmPreview == null || _frmPreview.IsDisposed)
            {
                _frmPreview = new PreviewForm();
                _frmPreview.Size = Settings.Instance.LastPreviewSize;
                _frmPreview.Closing += (s, args) =>
                {
                    Settings.Instance.LastPreviewSize = _frmPreview.Size;
                    _previewLocation = _frmPreview.Location;
                };
            }
            else if (_frmPreview.WindowState == FormWindowState.Minimized)
            {
                _frmPreview.WindowState = FormWindowState.Normal;
            }

            if (_previewLocation == Point.Empty)
                _frmPreview.StartPosition = FormStartPosition.CenterScreen;
            else if (!_frmPreview.Visible)
                _frmPreview.Location = _previewLocation;

            _frmPreview.NavigateTo(link);
            _frmPreview.Show();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ShowYoutubePreview();
        }
    }
}
