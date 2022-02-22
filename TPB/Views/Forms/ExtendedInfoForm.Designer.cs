namespace TpbForWindows.Views.Forms
{
    partial class ExtendedInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtendedInfoForm));
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browserDescription = new System.Windows.Forms.WebBrowser();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFiles = new System.Windows.Forms.Label();
            this.lblNoPrev = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInfoHash = new TpbForWindows.Views.Controls.ExTextBoxBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // picPreview
            // 
            this.picPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picPreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(547, 12);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(242, 260);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Comments:";
            // 
            // browserDescription
            // 
            this.browserDescription.AllowNavigation = false;
            this.browserDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserDescription.IsWebBrowserContextMenuEnabled = false;
            this.browserDescription.Location = new System.Drawing.Point(0, 0);
            this.browserDescription.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserDescription.Name = "browserDescription";
            this.browserDescription.ScriptErrorsSuppressed = true;
            this.browserDescription.Size = new System.Drawing.Size(527, 268);
            this.browserDescription.TabIndex = 3;
            this.browserDescription.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.browserDescription_Navigating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.Location = new System.Drawing.Point(12, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // lblFiles
            // 
            this.lblFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiles.AutoSize = true;
            this.lblFiles.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblFiles.Location = new System.Drawing.Point(547, 280);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(53, 20);
            this.lblFiles.TabIndex = 5;
            this.lblFiles.Text = "Files: 0";
            // 
            // lblNoPrev
            // 
            this.lblNoPrev.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoPrev.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblNoPrev.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoPrev.Location = new System.Drawing.Point(561, 89);
            this.lblNoPrev.Name = "lblNoPrev";
            this.lblNoPrev.Size = new System.Drawing.Size(217, 80);
            this.lblNoPrev.TabIndex = 6;
            this.lblNoPrev.Text = "No Preview";
            this.lblNoPrev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.browserDescription);
            this.panel1.Location = new System.Drawing.Point(12, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 270);
            this.panel1.TabIndex = 9;
            // 
            // txtComments
            // 
            this.txtComments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtComments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComments.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(0, 0);
            this.txtComments.Name = "txtComments";
            this.txtComments.ReadOnly = true;
            this.txtComments.Size = new System.Drawing.Size(527, 138);
            this.txtComments.TabIndex = 10;
            this.txtComments.Text = "";
            this.txtComments.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtComments_LinkClicked);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel.Controls.Add(this.txtComments);
            this.panel.Location = new System.Drawing.Point(12, 32);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(529, 140);
            this.panel.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.Location = new System.Drawing.Point(547, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Info Hash:";
            // 
            // txtInfoHash
            // 
            this.txtInfoHash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoHash.HasText = false;
            this.txtInfoHash.HideSelection = false;
            this.txtInfoHash.Location = new System.Drawing.Point(546, 446);
            this.txtInfoHash.Name = "txtInfoHash";
            this.txtInfoHash.ReadOnly = true;
            this.txtInfoHash.Size = new System.Drawing.Size(243, 22);
            this.txtInfoHash.TabIndex = 13;
            // 
            // ExtendedInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 480);
            this.Controls.Add(this.txtInfoHash);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblNoPrev);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picPreview);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExtendedInfoForm";
            this.Text = "Extended Info";
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser browserDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.Label lblNoPrev;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtComments;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Label label3;
        private Controls.ExTextBoxBox txtInfoHash;
    }
}