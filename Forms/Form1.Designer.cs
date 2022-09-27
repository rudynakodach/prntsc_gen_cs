namespace prntsc_gen
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.CheckBoxLog = new System.Windows.Forms.CheckBox();
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.AppStatusLabel = new System.Windows.Forms.Label();
            this.CurrentLinkLabel = new System.Windows.Forms.Label();
            this.OpenLogButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveMessageTextBox = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.ViewLinkButton = new System.Windows.Forms.Button();
            this.ClearLogsButton = new System.Windows.Forms.Button();
            this.AutoPreviewCheckbox = new System.Windows.Forms.CheckBox();
            this.LinksGeneratedLabel = new System.Windows.Forms.Label();
            this.CopyLinkToClipboardButton = new System.Windows.Forms.Button();
            this.GetDirectImageLink = new System.Windows.Forms.Button();
            this.DownloadImageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.BackColor = System.Drawing.SystemColors.Info;
            this.ButtonGenerate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ButtonGenerate.Location = new System.Drawing.Point(393, 322);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
            this.ButtonGenerate.TabIndex = 0;
            this.ButtonGenerate.Text = "Generate";
            this.ButtonGenerate.UseVisualStyleBackColor = false;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // CheckBoxLog
            // 
            this.CheckBoxLog.Location = new System.Drawing.Point(93, 262);
            this.CheckBoxLog.Name = "CheckBoxLog";
            this.CheckBoxLog.Size = new System.Drawing.Size(131, 19);
            this.CheckBoxLog.TabIndex = 2;
            this.CheckBoxLog.Text = "Auto-Log";
            this.CheckBoxLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CheckBoxLog.UseVisualStyleBackColor = true;
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.BackColor = System.Drawing.SystemColors.Info;
            this.ButtonOpen.Cursor = System.Windows.Forms.Cursors.Default;
            this.ButtonOpen.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ButtonOpen.Location = new System.Drawing.Point(230, 322);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpen.TabIndex = 3;
            this.ButtonOpen.Text = "Open Link";
            this.ButtonOpen.UseVisualStyleBackColor = false;
            this.ButtonOpen.Click += new System.EventHandler(this.OpenInBrowserButton_Click);
            // 
            // AppStatusLabel
            // 
            this.AppStatusLabel.Location = new System.Drawing.Point(12, 326);
            this.AppStatusLabel.Name = "AppStatusLabel";
            this.AppStatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.AppStatusLabel.Size = new System.Drawing.Size(192, 37);
            this.AppStatusLabel.TabIndex = 4;
            this.AppStatusLabel.Text = "AppStatus";
            this.AppStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentLinkLabel
            // 
            this.CurrentLinkLabel.Location = new System.Drawing.Point(230, 287);
            this.CurrentLinkLabel.Name = "CurrentLinkLabel";
            this.CurrentLinkLabel.Size = new System.Drawing.Size(75, 36);
            this.CurrentLinkLabel.TabIndex = 5;
            this.CurrentLinkLabel.Text = "A link will appear here.";
            this.CurrentLinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpenLogButton
            // 
            this.OpenLogButton.BackColor = System.Drawing.SystemColors.Info;
            this.OpenLogButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OpenLogButton.Location = new System.Drawing.Point(12, 258);
            this.OpenLogButton.Name = "OpenLogButton";
            this.OpenLogButton.Size = new System.Drawing.Size(75, 23);
            this.OpenLogButton.TabIndex = 6;
            this.OpenLogButton.Text = "Open Logs";
            this.OpenLogButton.UseVisualStyleBackColor = false;
            this.OpenLogButton.Click += new System.EventHandler(this.OpenLogButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.SystemColors.Info;
            this.SaveButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveButton.Location = new System.Drawing.Point(393, 262);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveMessageTextBox
            // 
            this.SaveMessageTextBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SaveMessageTextBox.Location = new System.Drawing.Point(233, 264);
            this.SaveMessageTextBox.Name = "SaveMessageTextBox";
            this.SaveMessageTextBox.Size = new System.Drawing.Size(157, 20);
            this.SaveMessageTextBox.TabIndex = 8;
            this.SaveMessageTextBox.Text = "Custom Comment";
            // 
            // webBrowser1
            // 
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(9, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(456, 240);
            this.webBrowser1.TabIndex = 9;
            // 
            // ViewLinkButton
            // 
            this.ViewLinkButton.BackColor = System.Drawing.SystemColors.Info;
            this.ViewLinkButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ViewLinkButton.Location = new System.Drawing.Point(311, 322);
            this.ViewLinkButton.Name = "ViewLinkButton";
            this.ViewLinkButton.Size = new System.Drawing.Size(75, 23);
            this.ViewLinkButton.TabIndex = 10;
            this.ViewLinkButton.Text = "Preview";
            this.ViewLinkButton.UseVisualStyleBackColor = false;
            this.ViewLinkButton.Click += new System.EventHandler(this.PreviewLinkButton_Click);
            // 
            // ClearLogsButton
            // 
            this.ClearLogsButton.BackColor = System.Drawing.SystemColors.Info;
            this.ClearLogsButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ClearLogsButton.Location = new System.Drawing.Point(12, 293);
            this.ClearLogsButton.Name = "ClearLogsButton";
            this.ClearLogsButton.Size = new System.Drawing.Size(75, 23);
            this.ClearLogsButton.TabIndex = 11;
            this.ClearLogsButton.Text = "Clear Logs";
            this.ClearLogsButton.UseVisualStyleBackColor = false;
            this.ClearLogsButton.Click += new System.EventHandler(this.ClearLogsButton_Click);
            // 
            // AutoPreviewCheckbox
            // 
            this.AutoPreviewCheckbox.Location = new System.Drawing.Point(301, 351);
            this.AutoPreviewCheckbox.Name = "AutoPreviewCheckbox";
            this.AutoPreviewCheckbox.Size = new System.Drawing.Size(89, 17);
            this.AutoPreviewCheckbox.TabIndex = 12;
            this.AutoPreviewCheckbox.Text = "Auto-Preview";
            this.AutoPreviewCheckbox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoPreviewCheckbox.UseVisualStyleBackColor = true;
            // 
            // LinksGeneratedLabel
            // 
            this.LinksGeneratedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LinksGeneratedLabel.Location = new System.Drawing.Point(93, 293);
            this.LinksGeneratedLabel.Name = "LinksGeneratedLabel";
            this.LinksGeneratedLabel.Size = new System.Drawing.Size(131, 23);
            this.LinksGeneratedLabel.TabIndex = 13;
            this.LinksGeneratedLabel.Text = "Links Generated: 0";
            this.LinksGeneratedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CopyLinkToClipboardButton
            // 
            this.CopyLinkToClipboardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CopyLinkToClipboardButton.BackColor = System.Drawing.SystemColors.Info;
            this.CopyLinkToClipboardButton.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CopyLinkToClipboardButton.Location = new System.Drawing.Point(393, 293);
            this.CopyLinkToClipboardButton.Name = "CopyLinkToClipboardButton";
            this.CopyLinkToClipboardButton.Size = new System.Drawing.Size(0, 23);
            this.CopyLinkToClipboardButton.TabIndex = 17;
            this.CopyLinkToClipboardButton.Text = "Copy Link";
            this.CopyLinkToClipboardButton.UseVisualStyleBackColor = false;
            this.CopyLinkToClipboardButton.Click += new System.EventHandler(this.CopyLinkToClipboardButton_Click);
            // 
            // GetDirectImageLink
            // 
            this.GetDirectImageLink.BackColor = System.Drawing.SystemColors.Info;
            this.GetDirectImageLink.Font = new System.Drawing.Font("Arial", 5.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GetDirectImageLink.Location = new System.Drawing.Point(311, 293);
            this.GetDirectImageLink.Name = "GetDirectImageLink";
            this.GetDirectImageLink.Size = new System.Drawing.Size(75, 23);
            this.GetDirectImageLink.TabIndex = 18;
            this.GetDirectImageLink.Text = "Copy Direct Link";
            this.GetDirectImageLink.UseVisualStyleBackColor = false;
            this.GetDirectImageLink.Click += new System.EventHandler(this.GetDirectImageLink_Click);
            // 
            // DownloadImageButton
            // 
            this.DownloadImageButton.BackColor = System.Drawing.SystemColors.Info;
            this.DownloadImageButton.Location = new System.Drawing.Point(392, 294);
            this.DownloadImageButton.Name = "DownloadImageButton";
            this.DownloadImageButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadImageButton.TabIndex = 20;
            this.DownloadImageButton.Text = "Download";
            this.DownloadImageButton.UseVisualStyleBackColor = false;
            this.DownloadImageButton.Click += new System.EventHandler(this.DownloadImageButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(474, 376);
            this.Controls.Add(this.DownloadImageButton);
            this.Controls.Add(this.GetDirectImageLink);
            this.Controls.Add(this.CopyLinkToClipboardButton);
            this.Controls.Add(this.LinksGeneratedLabel);
            this.Controls.Add(this.AutoPreviewCheckbox);
            this.Controls.Add(this.ClearLogsButton);
            this.Controls.Add(this.ViewLinkButton);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.SaveMessageTextBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OpenLogButton);
            this.Controls.Add(this.CurrentLinkLabel);
            this.Controls.Add(this.AppStatusLabel);
            this.Controls.Add(this.ButtonOpen);
            this.Controls.Add(this.CheckBoxLog);
            this.Controls.Add(this.ButtonGenerate);
            this.Name = "Form1";
            this.Opacity = 0D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "prnt_sc_gen";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.CheckBox CheckBoxLog;
        private System.Windows.Forms.Button ButtonOpen;
        public System.Windows.Forms.Label CurrentLinkLabel;
        public System.Windows.Forms.Label AppStatusLabel;
        private System.Windows.Forms.Button OpenLogButton;
        private System.Windows.Forms.Button SaveButton;
        public System.Windows.Forms.TextBox SaveMessageTextBox;
        public System.Windows.Forms.WebBrowser webBrowser1;
        public System.Windows.Forms.Button ViewLinkButton;
        private System.Windows.Forms.Button ClearLogsButton;
        public System.Windows.Forms.CheckBox AutoPreviewCheckbox;
        public System.Windows.Forms.Label LinksGeneratedLabel;
        public System.Windows.Forms.Button CopyLinkToClipboardButton;
        private System.Windows.Forms.Button GetDirectImageLink;
        public System.Windows.Forms.Button DownloadImageButton;
    }
}

