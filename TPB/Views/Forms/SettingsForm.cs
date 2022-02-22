using System;
using System.Net;
using System.Windows.Forms;
using TpbForWindows.PbApi;

namespace TpbForWindows.Views.Forms
{
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Gets or sets the selected TorrentDoubleClickMode
        /// </summary>
        private TorrentDoubleClickMode SelectedTorrentDoubleClickMode
        {
            get
            {
                if (radioOpenExtended.Checked) return TorrentDoubleClickMode.OpenExtendedInfo;
                if (radioShowPreview.Checked) return TorrentDoubleClickMode.ShowPreview;
                else return TorrentDoubleClickMode.DownloadMagnet;
            }
            set
            {
                switch (value)
                {
                    case TorrentDoubleClickMode.DownloadMagnet:
                        radioDownMagnet.Checked = true;
                        break;

                    case TorrentDoubleClickMode.OpenExtendedInfo:
                        radioOpenExtended.Checked = true;
                        break;

                    case TorrentDoubleClickMode.ShowPreview:
                        radioShowPreview.Checked = true;
                        break;
                }
            }
        }

        public SettingsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void LoadSettings()
        {
            // Address is non-null and therefore proxy is custom
            if (Settings.Instance.Proxy != null && Settings.Instance.Proxy.Address != null)
                txtAddress.Text = Settings.Instance.Proxy.Address.AbsoluteUri;
            // List general filter category
            clFilters.Items.Clear();

            foreach (var element in Enum.GetValues(typeof(TorrentCategory)))
            {
                bool check = Settings.Instance.TorrentCatergories.HasFlag((Enum)element);
                clFilters.Items.Add(element, check);
            }

            chkExcludePorn.Checked = Settings.Instance.ExcludePorn;
            chkShowSubCat.Checked = Settings.Instance.ShowSubCategories;
            chkViewEmbedded.Checked = Settings.Instance.EmbedPreviews;
            nudTimeout.Value = Settings.Instance.Timeout;
            chkAutoStart.Checked = Settings.Instance.AutoStartPreviews;

            if (Settings.Instance.Proxy == null)
            {
                radioUseNoProxy.Checked = true;
            }
            else if (Settings.Instance.Proxy.Address == null) // Default webproxy is being used, reference comparison always fails
            {
                radioUseIEProxy.Checked = true;
            }
            else
            {
                radioCustomProxy.Checked = true;
            }

            SelectedTorrentDoubleClickMode = Settings.Instance.TorrentStripDoubleClickMode;
        }

        private void SaveSettings()
        {
            Settings.Instance.AutoStartPreviews = chkAutoStart.Checked;
            Settings.Instance.Timeout = (int)nudTimeout.Value;
            Settings.Instance.EmbedPreviews = chkViewEmbedded.Checked;
            Settings.Instance.ShowSubCategories = chkShowSubCat.Checked;
            Settings.Instance.ExcludePorn = chkExcludePorn.Checked;
            Settings.Instance.TorrentCatergories = TorrentCategory.None;

            foreach (var item in clFilters.CheckedItems)
                Settings.Instance.TorrentCatergories |= (TorrentCategory)item;

            if (radioCustomProxy.Checked)
            {
                Settings.Instance.Proxy = new WebProxy(txtAddress.Text);
            }
            else if (radioUseIEProxy.Checked)
            {
                Settings.Instance.Proxy = WebProxy.GetDefaultProxy();
            }
            else if (radioUseNoProxy.Checked)
            {
                Settings.Instance.Proxy = null;
            }

            Settings.Instance.TorrentStripDoubleClickMode = SelectedTorrentDoubleClickMode;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text == string.Empty && radioCustomProxy.Checked)
            {
                const string MSG = "Custom proxy is enabled, but there is no address specified";
                MessageBox.Show(MSG, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveSettings();
            Close();
        }

        private void clFilters_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                if (e.NewValue == CheckState.Checked)
                {
                    // Uncheck all but the first item
                    for (int i = 1; i < clFilters.Items.Count; i++)
                        clFilters.SetItemChecked(i, false);
                }
            }
            else if (e.NewValue == CheckState.Checked)
            {
                clFilters.SetItemChecked(0, false);
            }
        }

        private void radioCustomProxy_CheckedChanged(object sender, EventArgs e)
        {
            txtAddress.Enabled = lblAddress.Enabled = (radioCustomProxy.Checked);
        }
    }
}
