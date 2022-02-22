using TpbForWindows.Views.Controls;

namespace TpbForWindows.Views.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cmsQuickLinks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmi1080 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiYear = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDvdrip = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMvk = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTorrentInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiCopyMovieName = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSearchThis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRottenTomatoes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExtra = new System.Windows.Forms.ToolStripMenuItem();
            this.lblPage = new System.Windows.Forms.Label();
            this.pnlTorrents = new TpbForWindows.Views.Controls.TorrentPanel();
            this.comboSort = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTerm = new TpbForWindows.Views.Controls.ExTextBoxBox();
            this.btnSearch = new TpbForWindows.Views.Controls.IlluminateButton();
            this.btnAbout = new TpbForWindows.Views.Controls.IlluminateButton();
            this.btnSettings = new TpbForWindows.Views.Controls.IlluminateButton();
            this.btnPrevious = new TpbForWindows.Views.Controls.IlluminateButton();
            this.btnNext = new TpbForWindows.Views.Controls.IlluminateButton();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.cmsQuickLinks.SuspendLayout();
            this.cmsTorrentInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsQuickLinks
            // 
            this.cmsQuickLinks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi1080,
            this.tsmiYear,
            this.tsmiDvdrip,
            this.tsmiMvk});
            this.cmsQuickLinks.Name = "cmsQuickLinks";
            this.cmsQuickLinks.Size = new System.Drawing.Size(115, 92);
            // 
            // tsmi1080
            // 
            this.tsmi1080.Name = "tsmi1080";
            this.tsmi1080.Size = new System.Drawing.Size(114, 22);
            this.tsmi1080.Text = "1080p";
            // 
            // tsmiYear
            // 
            this.tsmiYear.Name = "tsmiYear";
            this.tsmiYear.Size = new System.Drawing.Size(114, 22);
            this.tsmiYear.Text = "2014";
            // 
            // tsmiDvdrip
            // 
            this.tsmiDvdrip.Name = "tsmiDvdrip";
            this.tsmiDvdrip.Size = new System.Drawing.Size(114, 22);
            this.tsmiDvdrip.Text = "DVDRip";
            // 
            // tsmiMvk
            // 
            this.tsmiMvk.Name = "tsmiMvk";
            this.tsmiMvk.Size = new System.Drawing.Size(114, 22);
            this.tsmiMvk.Text = "mkv";
            // 
            // cmsTorrentInfo
            // 
            this.cmsTorrentInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCopyMovieName,
            this.tsmiSearchThis,
            this.tsmiRottenTomatoes,
            this.tsmiExtra});
            this.cmsTorrentInfo.Name = "contextMenuStrip1";
            this.cmsTorrentInfo.Size = new System.Drawing.Size(207, 92);
            this.cmsTorrentInfo.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTorrentInfo_Opening);
            // 
            // tsmiCopyMovieName
            // 
            this.tsmiCopyMovieName.Name = "tsmiCopyMovieName";
            this.tsmiCopyMovieName.Size = new System.Drawing.Size(206, 22);
            this.tsmiCopyMovieName.Text = "&Copy Movie Name";
            this.tsmiCopyMovieName.Click += new System.EventHandler(this.tsmiCopyMovieName_Click);
            // 
            // tsmiSearchThis
            // 
            this.tsmiSearchThis.Name = "tsmiSearchThis";
            this.tsmiSearchThis.Size = new System.Drawing.Size(206, 22);
            this.tsmiSearchThis.Text = "&Search this";
            this.tsmiSearchThis.Click += new System.EventHandler(this.tsmiSearchThis_Click);
            // 
            // tsmiRottenTomatoes
            // 
            this.tsmiRottenTomatoes.Name = "tsmiRottenTomatoes";
            this.tsmiRottenTomatoes.Size = new System.Drawing.Size(206, 22);
            this.tsmiRottenTomatoes.Text = "Go to &Rotten Tomatoes...";
            this.tsmiRottenTomatoes.Click += new System.EventHandler(this.tsmiRottenTomatoes_Click);
            // 
            // tsmiExtra
            // 
            this.tsmiExtra.Name = "tsmiExtra";
            this.tsmiExtra.Size = new System.Drawing.Size(206, 22);
            this.tsmiExtra.Text = "Go to &Torrent Page...";
            this.tsmiExtra.Click += new System.EventHandler(this.tsmiTorrentPage_Click);
            // 
            // lblPage
            // 
            this.lblPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(19)))), ((int)(((byte)(0)))));
            this.lblPage.Location = new System.Drawing.Point(100, 508);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(716, 44);
            this.lblPage.TabIndex = 8;
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTorrents
            // 
            this.pnlTorrents.AlternateColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(231)))), ((int)(((byte)(228)))));
            this.pnlTorrents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTorrents.AutoScroll = true;
            this.pnlTorrents.BackColor = System.Drawing.Color.Silver;
            this.pnlTorrents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTorrents.ContextMenuStrip = this.cmsTorrentInfo;
            this.pnlTorrents.DefaultStripDoubleClickMode = TpbForWindows.TorrentDoubleClickMode.OpenExtendedInfo;
            this.pnlTorrents.Location = new System.Drawing.Point(12, 48);
            this.pnlTorrents.Name = "pnlTorrents";
            this.pnlTorrents.Size = new System.Drawing.Size(906, 457);
            this.pnlTorrents.TabIndex = 13;
            // 
            // comboSort
            // 
            this.comboSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboSort.BackColor = System.Drawing.Color.Gainsboro;
            this.comboSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboSort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboSort.ForeColor = System.Drawing.Color.Black;
            this.comboSort.FormattingEnabled = true;
            this.comboSort.Items.AddRange(new object[] {
            "Most Relevant",
            "Most Seeded",
            "Most Recent"});
            this.comboSort.Location = new System.Drawing.Point(467, 12);
            this.comboSort.Name = "comboSort";
            this.comboSort.Size = new System.Drawing.Size(121, 25);
            this.comboSort.TabIndex = 17;
            this.comboSort.SelectedIndexChanged += new System.EventHandler(this.comboSort_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(399, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 14);
            this.label1.TabIndex = 18;
            this.label1.Text = "Sort Mode";
            // 
            // txtTerm
            // 
            this.txtTerm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTerm.BackColor = System.Drawing.Color.White;
            this.txtTerm.ContextMenuStrip = this.cmsQuickLinks;
            this.txtTerm.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTerm.ForeColor = System.Drawing.Color.Black;
            this.txtTerm.HasText = false;
            this.txtTerm.Location = new System.Drawing.Point(594, 12);
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.Size = new System.Drawing.Size(280, 25);
            this.txtTerm.TabIndex = 19;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.AutoSize = true;
            this.btnSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.DepressBrightness = 1F;
            this.btnSearch.DepressConstrast = 1F;
            this.btnSearch.DepressGamma = 1F;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.HoverBrightness = 1F;
            this.btnSearch.HoverContrast = 1.5F;
            this.btnSearch.HoverGamma = 0.9F;
            this.btnSearch.Image = global::TpbForWindows.Properties.Resources.Search;
            this.btnSearch.Location = new System.Drawing.Point(880, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(34, 34);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAbout.AutoSize = true;
            this.btnAbout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.DepressBrightness = 1F;
            this.btnAbout.DepressConstrast = 1F;
            this.btnAbout.DepressGamma = 1F;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.HoverBrightness = 1F;
            this.btnAbout.HoverContrast = 1.5F;
            this.btnAbout.HoverGamma = 0.9F;
            this.btnAbout.Image = global::TpbForWindows.Properties.Resources.About;
            this.btnAbout.Location = new System.Drawing.Point(56, 511);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(38, 38);
            this.btnAbout.TabIndex = 20;
            this.btnAbout.TabStop = false;
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.AutoSize = true;
            this.btnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.DepressBrightness = 1F;
            this.btnSettings.DepressConstrast = 1F;
            this.btnSettings.DepressGamma = 1F;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.HoverBrightness = 1F;
            this.btnSettings.HoverContrast = 1.5F;
            this.btnSettings.HoverGamma = 0.9F;
            this.btnSettings.Image = global::TpbForWindows.Properties.Resources.Cog;
            this.btnSettings.Location = new System.Drawing.Point(12, 511);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(38, 38);
            this.btnSettings.TabIndex = 16;
            this.btnSettings.TabStop = false;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevious.AutoSize = true;
            this.btnPrevious.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.DepressBrightness = 1F;
            this.btnPrevious.DepressConstrast = 1F;
            this.btnPrevious.DepressGamma = 1F;
            this.btnPrevious.Enabled = false;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.HoverBrightness = 1F;
            this.btnPrevious.HoverContrast = 1.5F;
            this.btnPrevious.HoverGamma = 0.9F;
            this.btnPrevious.Image = global::TpbForWindows.Properties.Resources.LeftArrow;
            this.btnPrevious.Location = new System.Drawing.Point(829, 511);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(38, 38);
            this.btnPrevious.TabIndex = 10;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.AutoSize = true;
            this.btnNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.DepressBrightness = 1F;
            this.btnNext.DepressConstrast = 1F;
            this.btnNext.DepressGamma = 1F;
            this.btnNext.Enabled = false;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.HoverBrightness = 1F;
            this.btnNext.HoverContrast = 1.5F;
            this.btnNext.HoverGamma = 0.9F;
            this.btnNext.Image = global::TpbForWindows.Properties.Resources.RightArrow;
            this.btnNext.Location = new System.Drawing.Point(880, 511);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(38, 38);
            this.btnNext.TabIndex = 9;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // picLogo
            // 
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.Image = global::TpbForWindows.Properties.Resources.Logo;
            this.picLogo.Location = new System.Drawing.Point(12, 12);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(180, 30);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.Click += new System.EventHandler(this.picLogo_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(930, 561);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.txtTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboSort);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pnlTorrents);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.picLogo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(754, 253);
            this.Name = "MainForm";
            this.Text = "TPB For Windows";
            this.cmsQuickLinks.ResumeLayout(false);
            this.cmsTorrentInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picLogo;
        private IlluminateButton btnSearch;
        private System.Windows.Forms.ContextMenuStrip cmsTorrentInfo;
        private System.Windows.Forms.ToolStripMenuItem tsmiCopyMovieName;
        private System.Windows.Forms.ToolStripMenuItem tsmiRottenTomatoes;
        private System.Windows.Forms.ToolStripMenuItem tsmiSearchThis;
        private System.Windows.Forms.Label lblPage;
        private IlluminateButton btnNext;
        private IlluminateButton btnPrevious;
        private TorrentPanel pnlTorrents;
        private IlluminateButton btnSettings;
        private System.Windows.Forms.ToolStripMenuItem tsmiExtra;
        private System.Windows.Forms.ComboBox comboSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsQuickLinks;
        private System.Windows.Forms.ToolStripMenuItem tsmi1080;
        private System.Windows.Forms.ToolStripMenuItem tsmiYear;
        private System.Windows.Forms.ToolStripMenuItem tsmiDvdrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiMvk;
        private ExTextBoxBox txtTerm;
        private IlluminateButton btnAbout;
    }
}

