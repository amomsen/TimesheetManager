namespace TimesheetManager
{
    partial class SettingsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsWindow));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbShowBalloonN = new System.Windows.Forms.RadioButton();
            this.rbShowBalloonY = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbShowNoteN = new System.Windows.Forms.RadioButton();
            this.rbShowNoteY = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rbStartupN = new System.Windows.Forms.RadioButton();
            this.rbStartupY = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbOCR = new System.Windows.Forms.RadioButton();
            this.rbService = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbShowBalloonN);
            this.groupBox1.Controls.Add(this.rbShowBalloonY);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(189, 46);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information Balloon";
            // 
            // rbShowBalloonN
            // 
            this.rbShowBalloonN.AutoSize = true;
            this.rbShowBalloonN.Location = new System.Drawing.Point(144, 20);
            this.rbShowBalloonN.Name = "rbShowBalloonN";
            this.rbShowBalloonN.Size = new System.Drawing.Size(39, 17);
            this.rbShowBalloonN.TabIndex = 2;
            this.rbShowBalloonN.TabStop = true;
            this.rbShowBalloonN.Text = "No";
            this.rbShowBalloonN.UseVisualStyleBackColor = true;
            // 
            // rbShowBalloonY
            // 
            this.rbShowBalloonY.AutoSize = true;
            this.rbShowBalloonY.Location = new System.Drawing.Point(95, 20);
            this.rbShowBalloonY.Name = "rbShowBalloonY";
            this.rbShowBalloonY.Size = new System.Drawing.Size(43, 17);
            this.rbShowBalloonY.TabIndex = 1;
            this.rbShowBalloonY.TabStop = true;
            this.rbShowBalloonY.Text = "Yes";
            this.rbShowBalloonY.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Show balloon:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbShowNoteN);
            this.groupBox2.Controls.Add(this.rbShowNoteY);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 45);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Issue Notes Dialog";
            // 
            // rbShowNoteN
            // 
            this.rbShowNoteN.AutoSize = true;
            this.rbShowNoteN.Location = new System.Drawing.Point(144, 20);
            this.rbShowNoteN.Name = "rbShowNoteN";
            this.rbShowNoteN.Size = new System.Drawing.Size(39, 17);
            this.rbShowNoteN.TabIndex = 4;
            this.rbShowNoteN.TabStop = true;
            this.rbShowNoteN.Text = "No";
            this.rbShowNoteN.UseVisualStyleBackColor = true;
            // 
            // rbShowNoteY
            // 
            this.rbShowNoteY.AutoSize = true;
            this.rbShowNoteY.Location = new System.Drawing.Point(95, 20);
            this.rbShowNoteY.Name = "rbShowNoteY";
            this.rbShowNoteY.Size = new System.Drawing.Size(43, 17);
            this.rbShowNoteY.TabIndex = 3;
            this.rbShowNoteY.TabStop = true;
            this.rbShowNoteY.Text = "Yes";
            this.rbShowNoteY.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Show dialog:";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(6, 43);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(177, 23);
            this.btnSaveSettings.TabIndex = 5;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSaveSettings);
            this.groupBox4.Controls.Add(this.rbStartupN);
            this.groupBox4.Controls.Add(this.rbStartupY);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(12, 166);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(189, 74);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Application Settings";
            // 
            // rbStartupN
            // 
            this.rbStartupN.AutoSize = true;
            this.rbStartupN.Location = new System.Drawing.Point(144, 20);
            this.rbStartupN.Name = "rbStartupN";
            this.rbStartupN.Size = new System.Drawing.Size(39, 17);
            this.rbStartupN.TabIndex = 6;
            this.rbStartupN.TabStop = true;
            this.rbStartupN.Text = "No";
            this.rbStartupN.UseVisualStyleBackColor = true;
            // 
            // rbStartupY
            // 
            this.rbStartupY.AutoSize = true;
            this.rbStartupY.Location = new System.Drawing.Point(95, 20);
            this.rbStartupY.Name = "rbStartupY";
            this.rbStartupY.Size = new System.Drawing.Size(43, 17);
            this.rbStartupY.TabIndex = 5;
            this.rbStartupY.TabStop = true;
            this.rbStartupY.Text = "Yes";
            this.rbStartupY.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Run at startup:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbOCR);
            this.groupBox3.Controls.Add(this.rbService);
            this.groupBox3.Location = new System.Drawing.Point(12, 115);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(189, 45);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Issue Watch Method";
            // 
            // rbOCR
            // 
            this.rbOCR.AutoSize = true;
            this.rbOCR.Location = new System.Drawing.Point(95, 23);
            this.rbOCR.Name = "rbOCR";
            this.rbOCR.Size = new System.Drawing.Size(78, 17);
            this.rbOCR.TabIndex = 4;
            this.rbOCR.TabStop = true;
            this.rbOCR.Text = "OCR Block";
            this.rbOCR.UseVisualStyleBackColor = true;
            // 
            // rbService
            // 
            this.rbService.AutoSize = true;
            this.rbService.Location = new System.Drawing.Point(9, 19);
            this.rbService.Name = "rbService";
            this.rbService.Size = new System.Drawing.Size(61, 17);
            this.rbService.TabIndex = 3;
            this.rbService.TabStop = true;
            this.rbService.Text = "Service";
            this.rbService.UseVisualStyleBackColor = true;
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(213, 250);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbShowBalloonN;
        private System.Windows.Forms.RadioButton rbShowBalloonY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbShowNoteN;
        private System.Windows.Forms.RadioButton rbShowNoteY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbStartupN;
        private System.Windows.Forms.RadioButton rbStartupY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbOCR;
        private System.Windows.Forms.RadioButton rbService;

    }
}