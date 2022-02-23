using AboPersistance.Views;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Web;
using System.Windows.Forms;
using TPB.Api;
using TPB.Views.Controls;

namespace TPB.Views.Forms
{
    public partial class MainForm : Form
    {
        private PbResultPage _currentPage = new PbResultPage();

        #region Properties
        /// <summary>
        /// Gets or sets whether to allow page navigation or not
        /// </summary>
        private bool AllowSearch
        {
            get { return btnSearch.Enabled; }
            set { btnNext.Enabled = btnPrevious.Enabled = cmsQuickLinks.Enabled = btnSearch.Enabled = value; }
        }

        /// <summary>
        /// Gets search query based on user input/configurations
        /// </summary>
        private PbSearchQuery SearchQuery
        {
            get
            {
                return new PbSearchQuery(txtTerm.Text, SelectedSortMode, Settings.Instance.TorrentCatergories);
            }
        }

        // Do a setter here

        /// <summary>
        /// Gets the sort mode selected in the sort mdoe comboBox
        /// </summary>
        private PbSortMode SelectedSortMode
        {
            get
            {
                switch (comboSort.SelectedIndex)
                {
                    case 0: return PbSortMode.Default;
                    case 1: return PbSortMode.MostSeeded;
                    case 2: return PbSortMode.MostRecent;
                    default: return PbSortMode.MostSeeded;
                }
            }
            set
            {
                switch (value)
                {
                    case PbSortMode.Default: comboSort.SelectedIndex = 0; break;
                    case PbSortMode.MostSeeded: comboSort.SelectedIndex = 1; break;
                    case PbSortMode.MostRecent: comboSort.SelectedIndex = 2; break;
                }
            }
        }
        #endregion

        #region MainForm
        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
            tsmiYear.Text = DateTime.Now.Year.ToString();
            UpdateWebProxy();

            foreach (ToolStripMenuItem item in cmsQuickLinks.Items)
            {
                item.Click += (s, e) =>
                {
                    txtTerm.Text = item.Text;
                    btnSearch.PerformClick();
                };
            }
            btnSearch.DataBindings.Add("Enabled", txtTerm, "HasText");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Settings.Instance.LastFormSize = Size;
            Settings.Instance.SortMode = SelectedSortMode;
            Settings.Instance.SearchTerm = txtTerm.Text;
            Settings.Instance.Save();
        }
        #endregion

        #region User Functions
        private void LoadSettings()
        {
            Size = Settings.Instance.LastFormSize;
            txtTerm.Text = Settings.Instance.SearchTerm;
            SelectedSortMode = Settings.Instance.SortMode;
        }

        private string GetClickedMovieName()
        {
            var pos = pnlTorrents.PointToClient(cmsTorrentInfo.Location);
            var display = (TorrentStrip)pnlTorrents.GetChildAtPoint(pos);
            return display.Torrent.GetMovieName();
        }

        /// <summary>
        /// Applies the users proxy settings to the API
        /// </summary>
        private static void UpdateWebProxy()
        {
            PbWebPageDownloading.GlobalProxy = Settings.Instance.Proxy;
            PbWebPageDownloading.GlobalTimout = Settings.Instance.Timeout;
        }

        /// <summary>
        /// Show a label indication no results have been found
        /// </summary>
        private void ShowLargeLabel(string caption)
        {
            var label = new Label
            {
                ForeColor = Color.FromArgb(30, 30, 30),
                AutoSize = false,
                Font = new Font("Old English Text MT", 40f),
                Text = caption,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            pnlTorrents.Controls.Add(label);
        }

        private async void Search(PbSearchQuery query)
        {
            AllowSearch = false;
            pnlTorrents.Controls.Clear();
            var results = await ThePirateBay.DownloadResultsAsync(query);
            _currentPage = results.SearchPage;

            if (results.Error == null)
            {
                var torrents = _currentPage.GetTorrents();

                if (_currentPage.Torrents.Length == 0)
                {
                    ShowLargeLabel("No Results Yeilded");
                }
                else
                {
                    pnlTorrents.DisplayTorrents(torrents);

                    if (pnlTorrents.Controls.Count - 1 > 0)  // Scroll to top if more than one item
                    {
                        var control = pnlTorrents.Controls[pnlTorrents.Controls.Count - 1];
                        pnlTorrents.ScrollControlIntoView(control);
                    }
                }
            }
            else
            {
                ShowLargeLabel("Timed out");
            }

            const string FORMAT = @"Pages {0} of {1}";
            lblPage.Text = String.Format(FORMAT, _currentPage.PageNumber, _currentPage.TotalPages);
            AllowSearch = true;
            btnNext.Enabled = _currentPage.HasNextPage;
            btnPrevious.Enabled = _currentPage.HasPreviousPage;
        }
        #endregion

        #region Button Click Events
        private void picLogo_Click(object sender, EventArgs e)
        {
            // If search text, then go the search results
            if (txtTerm.TextLength > 0)
            {
                Program.Start(SearchQuery.ToSearchLink());
            }
            else // Otherwise go to the homepage
            {
                Program.Start(ThePirateBay.SiteDomain);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search(SearchQuery);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var query = PbSearchQuery.FromSearchLink(_currentPage.NextPageLink);
            Search(query);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            var query = PbSearchQuery.FromSearchLink(_currentPage.PreviousPageLink);
            Search(query);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            using (var frmSettings = new SettingsForm())
            {
                if (frmSettings.ShowDialog() == DialogResult.OK)
                {
                    UpdateWebProxy();
                    pnlTorrents.DefaultStripDoubleClickMode = Settings.Instance.TorrentStripDoubleClickMode;
                    if (_currentPage.Loaded) Search(SearchQuery);
                }
            }
        }
        #endregion

        #region ToolStripItem Click Events
        private void tsmiRottenTomatoes_Click(object sender, EventArgs e)
        {
            const string URL_BASE = "http://www.rott    entomatoes.com/search/?search=";
            // Make string URL safe
            string searchUrl = URL_BASE + HttpUtility.UrlEncode(GetClickedMovieName());
            Program.Start(searchUrl);
        }

        private void tsmiSearchThis_Click(object sender, EventArgs e)
        {
            txtTerm.Text = GetClickedMovieName();
            Search(SearchQuery);
        }

        private void tsmiTorrentPage_Click(object sender, EventArgs e)
        {
            var pos = pnlTorrents.PointToClient(cmsTorrentInfo.Location);
            var display = (TorrentStrip)pnlTorrents.GetChildAtPoint(pos);
            if (display == null) return;
            Program.Start(display.Torrent.PageLink);
        }

        private void tsmiCopyMovieName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(GetClickedMovieName());
        }
        #endregion

        private void cmsTorrentInfo_Opening(object sender, CancelEventArgs e)
        {
            if (!pnlTorrents.TorrentHovered) e.Cancel = true;
        }

        private void comboSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboSort.SelectedIndex != -1 && AllowSearch && txtTerm.HasText)
                //Search(SearchQuery);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            using (var frmAbout = new AboutForm())
            {
                frmAbout.ShowDialog();
            }
        }
    }
}
