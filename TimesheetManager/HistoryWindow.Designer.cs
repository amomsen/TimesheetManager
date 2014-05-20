namespace TimesheetManager
{
    partial class HistoryWindow
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Day", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.chDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIssue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chShort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNotes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.btnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboExport = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a date range:";
            // 
            // lvHistory
            // 
            this.lvHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chDate,
            this.chStart,
            this.chEnd,
            this.chIssue,
            this.chShort,
            this.chNotes});
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            listViewGroup1.Header = "Day";
            listViewGroup1.Name = "Day";
            this.lvHistory.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvHistory.Location = new System.Drawing.Point(10, 41);
            this.lvHistory.MaximumSize = new System.Drawing.Size(759, 227);
            this.lvHistory.MinimumSize = new System.Drawing.Size(759, 227);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Scrollable = false;
            this.lvHistory.ShowGroups = false;
            this.lvHistory.Size = new System.Drawing.Size(759, 227);
            this.lvHistory.TabIndex = 2;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            // 
            // chDate
            // 
            this.chDate.Text = "Issue Date";
            this.chDate.Width = 79;
            // 
            // chStart
            // 
            this.chStart.Text = "Start Time";
            this.chStart.Width = 80;
            // 
            // chEnd
            // 
            this.chEnd.Text = "End Time";
            this.chEnd.Width = 71;
            // 
            // chIssue
            // 
            this.chIssue.Text = "SYM Number";
            this.chIssue.Width = 111;
            // 
            // chShort
            // 
            this.chShort.Text = "Short Description";
            this.chShort.Width = 205;
            // 
            // chNotes
            // 
            this.chNotes.Text = "Personal Notes";
            this.chNotes.Width = 207;
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(118, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(95, 20);
            this.dtpStart.TabIndex = 3;
            this.dtpStart.Value = new System.DateTime(2013, 1, 1, 0, 0, 0, 0);
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(219, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "-";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(235, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(95, 20);
            this.dtpEnd.TabIndex = 5;
            this.dtpEnd.Value = new System.DateTime(2014, 4, 22, 0, 0, 0, 0);
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(693, 10);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 6;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Export to:";
            // 
            // cboExport
            // 
            this.cboExport.FormattingEnabled = true;
            this.cboExport.Items.AddRange(new object[] {
            "Excel Spread Sheet"});
            this.cboExport.Location = new System.Drawing.Point(566, 11);
            this.cboExport.Name = "cboExport";
            this.cboExport.Size = new System.Drawing.Size(121, 21);
            this.cboExport.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(336, 10);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // HistoryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 277);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboExport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lvHistory);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(795, 315);
            this.MinimumSize = new System.Drawing.Size(795, 315);
            this.Name = "HistoryWindow";
            this.Text = "Timesheet History ";
            this.Load += new System.EventHandler(this.HistoryWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader chStart;
        private System.Windows.Forms.ColumnHeader chEnd;
        private System.Windows.Forms.ColumnHeader chIssue;
        private System.Windows.Forms.ColumnHeader chShort;
        private System.Windows.Forms.ColumnHeader chNotes;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboExport;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ColumnHeader chDate;

    }
}