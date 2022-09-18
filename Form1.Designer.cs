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
            this.LinkTextLabel = new System.Windows.Forms.Label();
            this.CheckBoxLog = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Location = new System.Drawing.Point(15, 149);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(75, 23);
            this.ButtonGenerate.TabIndex = 0;
            this.ButtonGenerate.Text = "Generate";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // LinkTextLabel
            // 
            this.LinkTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkTextLabel.AutoSize = true;
            this.LinkTextLabel.Location = new System.Drawing.Point(90, 175);
            this.LinkTextLabel.Name = "LinkTextLabel";
            this.LinkTextLabel.Size = new System.Drawing.Size(0, 13);
            this.LinkTextLabel.TabIndex = 1;
            this.LinkTextLabel.Visible = false;
            this.LinkTextLabel.Click += new System.EventHandler(this.LinkTextLabel_Click);
            // 
            // CheckBoxLog
            // 
            this.CheckBoxLog.AutoSize = true;
            this.CheckBoxLog.Location = new System.Drawing.Point(93, 192);
            this.CheckBoxLog.Name = "CheckBoxLog";
            this.CheckBoxLog.Size = new System.Drawing.Size(44, 17);
            this.CheckBoxLog.TabIndex = 2;
            this.CheckBoxLog.Text = "Log";
            this.CheckBoxLog.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 221);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CheckBoxLog);
            this.Controls.Add(this.LinkTextLabel);
            this.Controls.Add(this.ButtonGenerate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Label LinkTextLabel;
        private System.Windows.Forms.CheckBox CheckBoxLog;
        private System.Windows.Forms.Button button1;
    }
}

