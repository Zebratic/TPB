using System;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TPB.Api;

namespace TPB.Views.Forms
{
    public partial class ExtendedInfoForm : Form
    {
        private bool _openElsewhere;

        public ExtendedInfoForm(ExtendedTorrentInfo info)
        {
            InitializeComponent();
            txtInfoHash.Text = info.InfoHash;

            if (info.ImageLink != null)
            {
                lblNoPrev.Hide();
                picPreview.ImageLocation = info.ImageLink;
            }

            foreach (string comment in info.Comments)
            {
                string c = Regex.Replace(comment, @"(\n)+", " ");

                txtComments.AppendText
                    ("• " + c +  Environment.NewLine + Environment.NewLine);
            }

            ShowDiscriptionPage(info.Description);
            lblFiles.Text = "Files: " + info.FileCount;
        }

        private void browserDescription_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (_openElsewhere)
            {
                e.Cancel = true;
                Program.Start(e.Url.AbsoluteUri);
            }

            _openElsewhere = true;
        }

        /// <summary>
        /// Creates a simple HTML page to show the description of the torrent
        /// </summary>
        private void ShowDiscriptionPage(string descrip)
        {
            var SB = new StringBuilder(descrip);
            SB.Insert(0, @"<html><body><pre><p style=""font-family:Verdana;font-size:14px;"">");
            SB.AppendLine("</p></pre></body></html>");
            browserDescription.DocumentText = SB.ToString();
        }

        private void txtComments_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Program.Start(e.LinkText);
        }
    }
}
