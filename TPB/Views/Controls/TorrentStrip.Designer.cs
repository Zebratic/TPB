namespace TPB.Views.Controls
{
    partial class TorrentStrip
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTorrentName = new System.Windows.Forms.Label();
            this.lblSeeds = new System.Windows.Forms.Label();
            this.lblLeeches = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnMagnet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTorrentName
            // 
            this.lblTorrentName.AutoEllipsis = true;
            this.lblTorrentName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTorrentName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTorrentName.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTorrentName.ForeColor = System.Drawing.Color.Black;
            this.lblTorrentName.Location = new System.Drawing.Point(93, 0);
            this.lblTorrentName.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblTorrentName.Name = "lblTorrentName";
            this.lblTorrentName.Size = new System.Drawing.Size(310, 34);
            this.lblTorrentName.TabIndex = 5;
            this.lblTorrentName.Text = "Torrent Name";
            this.lblTorrentName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTorrentName.Click += new System.EventHandler(this.lblTorrentName_Click);
            this.lblTorrentName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Labels_MouseDoubleClick);
            this.lblTorrentName.MouseEnter += new System.EventHandler(this.Universal_MouseEnter);
            this.lblTorrentName.MouseLeave += new System.EventHandler(this.Universal_MouseLeave);
            // 
            // lblSeeds
            // 
            this.lblSeeds.AutoEllipsis = true;
            this.lblSeeds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSeeds.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSeeds.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSeeds.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblSeeds.Location = new System.Drawing.Point(496, 0);
            this.lblSeeds.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSeeds.Name = "lblSeeds";
            this.lblSeeds.Size = new System.Drawing.Size(80, 34);
            this.lblSeeds.TabIndex = 6;
            this.lblSeeds.Text = "Seeds";
            this.lblSeeds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSeeds.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Labels_MouseDoubleClick);
            this.lblSeeds.MouseEnter += new System.EventHandler(this.Universal_MouseEnter);
            this.lblSeeds.MouseLeave += new System.EventHandler(this.Universal_MouseLeave);
            // 
            // lblLeeches
            // 
            this.lblLeeches.AutoEllipsis = true;
            this.lblLeeches.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLeeches.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLeeches.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblLeeches.ForeColor = System.Drawing.Color.Maroon;
            this.lblLeeches.Location = new System.Drawing.Point(576, 0);
            this.lblLeeches.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblLeeches.Name = "lblLeeches";
            this.lblLeeches.Size = new System.Drawing.Size(80, 34);
            this.lblLeeches.TabIndex = 7;
            this.lblLeeches.Text = "Leeches";
            this.lblLeeches.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLeeches.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Labels_MouseDoubleClick);
            this.lblLeeches.MouseEnter += new System.EventHandler(this.Universal_MouseEnter);
            this.lblLeeches.MouseLeave += new System.EventHandler(this.Universal_MouseLeave);
            // 
            // lblSize
            // 
            this.lblSize.AutoEllipsis = true;
            this.lblSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblSize.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSize.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblSize.ForeColor = System.Drawing.Color.DimGray;
            this.lblSize.Location = new System.Drawing.Point(403, 0);
            this.lblSize.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(93, 34);
            this.lblSize.TabIndex = 8;
            this.lblSize.Text = "Size";
            this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSize.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Labels_MouseDoubleClick);
            this.lblSize.MouseEnter += new System.EventHandler(this.Universal_MouseEnter);
            this.lblSize.MouseLeave += new System.EventHandler(this.Universal_MouseLeave);
            // 
            // lblCategory
            // 
            this.lblCategory.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblCategory.ForeColor = System.Drawing.Color.DimGray;
            this.lblCategory.Location = new System.Drawing.Point(0, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(93, 34);
            this.lblCategory.TabIndex = 11;
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCategory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Labels_MouseDoubleClick);
            // 
            // btnPreview
            // 
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnPreview.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPreview.FlatAppearance.BorderSize = 0;
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(656, 0);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(41, 34);
            this.btnPreview.TabIndex = 10;
            this.btnPreview.Image = global::TPB.Properties.Resources.Youtube;
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnMagnet
            // 
            this.btnMagnet.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMagnet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnMagnet.FlatAppearance.BorderSize = 0;
            this.btnMagnet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMagnet.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMagnet.Location = new System.Drawing.Point(697, 0);
            this.btnMagnet.Margin = new System.Windows.Forms.Padding(0);
            this.btnMagnet.Name = "btnMagnet";
            this.btnMagnet.Size = new System.Drawing.Size(41, 34);
            this.btnMagnet.TabIndex = 9;
            this.btnMagnet.Image = global::TPB.Properties.Resources.Magnet;
            this.btnMagnet.UseVisualStyleBackColor = true;
            this.btnMagnet.Click += new System.EventHandler(this.btnMagnet_Click);
            // 
            // TorrentStrip
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblTorrentName);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.lblSeeds);
            this.Controls.Add(this.lblLeeches);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.btnMagnet);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TorrentStrip";
            this.Size = new System.Drawing.Size(738, 34);
            this.MouseEnter += new System.EventHandler(this.Universal_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Universal_MouseLeave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTorrentName;
        private System.Windows.Forms.Label lblSeeds;
        private System.Windows.Forms.Label lblLeeches;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Button btnMagnet;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblCategory;
    }
}
