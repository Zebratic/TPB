namespace TpbForWindows.Views.Forms
{
    partial class SettingsForm
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
            System.Windows.Forms.GroupBox groupBox2;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.GroupBox groupBox5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.radioUseNoProxy = new System.Windows.Forms.RadioButton();
            this.radioCustomProxy = new System.Windows.Forms.RadioButton();
            this.radioUseIEProxy = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.nudTimeout = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.clFilters = new System.Windows.Forms.CheckedListBox();
            this.chkExcludePorn = new System.Windows.Forms.CheckBox();
            this.chkShowSubCat = new System.Windows.Forms.CheckBox();
            this.chkViewEmbedded = new System.Windows.Forms.CheckBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.radioShowPreview = new System.Windows.Forms.RadioButton();
            this.radioOpenExtended = new System.Windows.Forms.RadioButton();
            this.radioDownMagnet = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            groupBox2 = new System.Windows.Forms.GroupBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Controls.Add(this.label3);
            groupBox2.Controls.Add(this.nudTimeout);
            groupBox2.Location = new System.Drawing.Point(12, 197);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(267, 150);
            groupBox2.TabIndex = 16;
            groupBox2.TabStop = false;
            groupBox2.Text = "Connection";
            // 
            // groupBox3
            // 
            groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox3.Controls.Add(this.lblAddress);
            groupBox3.Controls.Add(this.txtAddress);
            groupBox3.Controls.Add(this.radioUseNoProxy);
            groupBox3.Controls.Add(this.radioCustomProxy);
            groupBox3.Controls.Add(this.radioUseIEProxy);
            groupBox3.Location = new System.Drawing.Point(6, 48);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(255, 96);
            groupBox3.TabIndex = 18;
            groupBox3.TabStop = false;
            groupBox3.Text = "Proxy";
            // 
            // lblAddress
            // 
            this.lblAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAddress.AutoSize = true;
            this.lblAddress.Enabled = false;
            this.lblAddress.Location = new System.Drawing.Point(7, 71);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 19;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(61, 68);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(188, 22);
            this.txtAddress.TabIndex = 18;
            // 
            // radioUseNoProxy
            // 
            this.radioUseNoProxy.AutoSize = true;
            this.radioUseNoProxy.Location = new System.Drawing.Point(6, 19);
            this.radioUseNoProxy.Name = "radioUseNoProxy";
            this.radioUseNoProxy.Size = new System.Drawing.Size(42, 17);
            this.radioUseNoProxy.TabIndex = 15;
            this.radioUseNoProxy.TabStop = true;
            this.radioUseNoProxy.Text = "Off";
            this.toolTip.SetToolTip(this.radioUseNoProxy, "No proxy will be used");
            this.radioUseNoProxy.UseVisualStyleBackColor = true;
            // 
            // radioCustomProxy
            // 
            this.radioCustomProxy.AutoSize = true;
            this.radioCustomProxy.Location = new System.Drawing.Point(6, 41);
            this.radioCustomProxy.Name = "radioCustomProxy";
            this.radioCustomProxy.Size = new System.Drawing.Size(116, 17);
            this.radioCustomProxy.TabIndex = 17;
            this.radioCustomProxy.TabStop = true;
            this.radioCustomProxy.Text = "Use Custom Proxy";
            this.toolTip.SetToolTip(this.radioCustomProxy, "Use a user defined proxy.\r\nEx. 198.50.241.160:8089");
            this.radioCustomProxy.UseVisualStyleBackColor = true;
            this.radioCustomProxy.CheckedChanged += new System.EventHandler(this.radioCustomProxy_CheckedChanged);
            // 
            // radioUseIEProxy
            // 
            this.radioUseIEProxy.AutoSize = true;
            this.radioUseIEProxy.Location = new System.Drawing.Point(54, 19);
            this.radioUseIEProxy.Name = "radioUseIEProxy";
            this.radioUseIEProxy.Size = new System.Drawing.Size(86, 17);
            this.radioUseIEProxy.TabIndex = 16;
            this.radioUseIEProxy.TabStop = true;
            this.radioUseIEProxy.Text = "Use IE Proxy";
            this.toolTip.SetToolTip(this.radioUseIEProxy, "Use the proxy set for internet explorer");
            this.radioUseIEProxy.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Timeout (MS)";
            // 
            // nudTimeout
            // 
            this.nudTimeout.Location = new System.Drawing.Point(85, 21);
            this.nudTimeout.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudTimeout.Name = "nudTimeout";
            this.nudTimeout.Size = new System.Drawing.Size(78, 22);
            this.nudTimeout.TabIndex = 12;
            this.toolTip.SetToolTip(this.nudTimeout, "The time to try to connect before timing out.\r\nSet to 0 for the default timeout v" +
        "alue");
            this.nudTimeout.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            groupBox1.Controls.Add(this.label2);
            groupBox1.Controls.Add(this.clFilters);
            groupBox1.Controls.Add(this.chkExcludePorn);
            groupBox1.Controls.Add(this.chkShowSubCat);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(267, 179);
            groupBox1.TabIndex = 15;
            groupBox1.TabStop = false;
            groupBox1.Text = "Search Results";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filters:";
            // 
            // clFilters
            // 
            this.clFilters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clFilters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clFilters.CheckOnClick = true;
            this.clFilters.FormattingEnabled = true;
            this.clFilters.IntegralHeight = false;
            this.clFilters.Location = new System.Drawing.Point(6, 35);
            this.clFilters.Name = "clFilters";
            this.clFilters.Size = new System.Drawing.Size(255, 115);
            this.clFilters.TabIndex = 2;
            this.toolTip.SetToolTip(this.clFilters, "Specifies category filters (only general ones)");
            this.clFilters.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clFilters_ItemCheck);
            // 
            // chkExcludePorn
            // 
            this.chkExcludePorn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkExcludePorn.AutoSize = true;
            this.chkExcludePorn.Location = new System.Drawing.Point(157, 156);
            this.chkExcludePorn.Name = "chkExcludePorn";
            this.chkExcludePorn.Size = new System.Drawing.Size(92, 17);
            this.chkExcludePorn.TabIndex = 6;
            this.chkExcludePorn.Text = "Exclude Porn";
            this.toolTip.SetToolTip(this.chkExcludePorn, "Exclude pornography (xxx/pron)");
            this.chkExcludePorn.UseVisualStyleBackColor = true;
            // 
            // chkShowSubCat
            // 
            this.chkShowSubCat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkShowSubCat.AutoSize = true;
            this.chkShowSubCat.Location = new System.Drawing.Point(6, 156);
            this.chkShowSubCat.Name = "chkShowSubCat";
            this.chkShowSubCat.Size = new System.Drawing.Size(135, 17);
            this.chkShowSubCat.TabIndex = 7;
            this.chkShowSubCat.Text = "Show Sub-categories";
            this.toolTip.SetToolTip(this.chkShowSubCat, "Shows sub-categories for each torrent");
            this.chkShowSubCat.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(this.chkViewEmbedded);
            groupBox4.Controls.Add(this.chkAutoStart);
            groupBox4.Location = new System.Drawing.Point(12, 353);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(267, 48);
            groupBox4.TabIndex = 17;
            groupBox4.TabStop = false;
            groupBox4.Text = "Youtube Preview";
            // 
            // chkViewEmbedded
            // 
            this.chkViewEmbedded.AutoSize = true;
            this.chkViewEmbedded.Location = new System.Drawing.Point(9, 21);
            this.chkViewEmbedded.Name = "chkViewEmbedded";
            this.chkViewEmbedded.Size = new System.Drawing.Size(109, 17);
            this.chkViewEmbedded.TabIndex = 8;
            this.chkViewEmbedded.Text = "View Embedded";
            this.toolTip.SetToolTip(this.chkViewEmbedded, "View youtube previews as embedded \r\n(may not work on you system)");
            this.chkViewEmbedded.UseVisualStyleBackColor = true;
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(124, 21);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(137, 17);
            this.chkAutoStart.TabIndex = 18;
            this.chkAutoStart.Text = "Auto-Start Embedded";
            this.toolTip.SetToolTip(this.chkAutoStart, "View youtube previews as embedded \r\n(may not work on you system)");
            this.chkAutoStart.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(this.radioShowPreview);
            groupBox5.Controls.Add(this.radioOpenExtended);
            groupBox5.Controls.Add(this.radioDownMagnet);
            groupBox5.Location = new System.Drawing.Point(12, 407);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(267, 107);
            groupBox5.TabIndex = 19;
            groupBox5.TabStop = false;
            groupBox5.Text = "Torrent Strip Double-Click Action";
            this.toolTip.SetToolTip(groupBox5, "The action to perform when a torrent strip is double-clicked");
            // 
            // radioShowPreview
            // 
            this.radioShowPreview.AutoSize = true;
            this.radioShowPreview.Location = new System.Drawing.Point(6, 67);
            this.radioShowPreview.Name = "radioShowPreview";
            this.radioShowPreview.Size = new System.Drawing.Size(143, 17);
            this.radioShowPreview.TabIndex = 2;
            this.radioShowPreview.TabStop = true;
            this.radioShowPreview.Text = "Show YouTube Preview";
            this.toolTip.SetToolTip(this.radioShowPreview, "A video preview will be shown in a new window");
            this.radioShowPreview.UseVisualStyleBackColor = true;
            // 
            // radioOpenExtended
            // 
            this.radioOpenExtended.AutoSize = true;
            this.radioOpenExtended.Location = new System.Drawing.Point(6, 44);
            this.radioOpenExtended.Name = "radioOpenExtended";
            this.radioOpenExtended.Size = new System.Drawing.Size(129, 17);
            this.radioOpenExtended.TabIndex = 1;
            this.radioOpenExtended.TabStop = true;
            this.radioOpenExtended.Text = "Open Extended Info";
            this.toolTip.SetToolTip(this.radioOpenExtended, "Extended torrent info will be displayed in a new window");
            this.radioOpenExtended.UseVisualStyleBackColor = true;
            // 
            // radioDownMagnet
            // 
            this.radioDownMagnet.AutoSize = true;
            this.radioDownMagnet.Location = new System.Drawing.Point(6, 21);
            this.radioDownMagnet.Name = "radioDownMagnet";
            this.radioDownMagnet.Size = new System.Drawing.Size(122, 17);
            this.radioDownMagnet.TabIndex = 0;
            this.radioDownMagnet.TabStop = true;
            this.radioDownMagnet.Text = "Download Magnet";
            this.toolTip.SetToolTip(this.radioDownMagnet, "The magnet for the torrent will be downloaded and opened in a default program");
            this.radioDownMagnet.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(123, 520);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(204, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(291, 555);
            this.Controls.Add(groupBox5);
            this.Controls.Add(groupBox4);
            this.Controls.Add(groupBox2);
            this.Controls.Add(groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clFilters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox chkExcludePorn;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox chkShowSubCat;
        private System.Windows.Forms.CheckBox chkViewEmbedded;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudTimeout;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.RadioButton radioUseNoProxy;
        private System.Windows.Forms.RadioButton radioCustomProxy;
        private System.Windows.Forms.RadioButton radioUseIEProxy;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.RadioButton radioShowPreview;
        private System.Windows.Forms.RadioButton radioOpenExtended;
        private System.Windows.Forms.RadioButton radioDownMagnet;
    }
}