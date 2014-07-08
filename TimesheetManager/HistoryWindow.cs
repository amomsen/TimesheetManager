using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimesheetManager.Library;
using TimesheetManager.Workers;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace TimesheetManager
{
    public partial class HistoryWindow : Form
    {
        public HistoryWindow()
        {
            InitializeComponent();
        }

        private void HistoryWindow_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            int dayOfWeek; 
            dayOfWeek = (int)date.DayOfWeek;
            date = date.AddDays(-dayOfWeek);
            dtpStart.Value = date;

            cboExport.SelectedIndex = 0;
            GetHistory();
        }

        private void GetHistory()
        {
            int dayOfWeek;
            DateTime StartDate, EndDate;
            dayOfWeek = (int)dtpStart.Value.DayOfWeek;
            dtpStart.Value = dtpStart.Value.AddDays(-dayOfWeek);
            StartDate = dtpStart.Value;
            EndDate = dtpStart.Value.AddDays(7);

            DBLayer.Get(String.Format(StringBank.DBQuery.SelectRange, StartDate, EndDate));
            foreach (DataRow Row in Globals.DBLayer.dataTable.Rows)
            {
                //ListViewGroup LvGroup = new ListViewGroup(Row[0].ToString());
                ListViewItem LvRow = new ListViewItem(Row[0].ToString());
                LvRow.SubItems.Add(Row[1].ToString());
                LvRow.SubItems.Add(Row[2].ToString());
                LvRow.SubItems.Add(Row[3].ToString());
                LvRow.SubItems.Add(Row[4].ToString());
                LvRow.SubItems.Add(Row[5].ToString());
                //lvHistory.Groups.Add(LvGroup);
                lvHistory.Items.Add(LvRow);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cboExport.Text == "Excel Spread Sheet")
            {
                SpreadSheetExport();
                
            }
            if (cboExport.Text == "Replicon Time Sheet")
            {
                RepliconExport();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lvHistory.Items.Clear();
            GetHistory();
        }

        private void RepliconExport()
        {
            Globals.Credentials.UserID = Repliconnect.RunQuery(string.Format(StringBank.Replicon.InitSession, Globals.Credentials.Username));
            Globals.Credentials.SheetID = Repliconnect.RunQuery(string.Format(StringBank.Replicon.GetSheetID, Globals.Credentials.UserID, dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day));
            try
            {
                foreach (DataRow Row in Globals.DBLayer.dataTable.Rows)
                {
                    Repliconnect.RunInsert(String.Format
                    (StringBank.Replicon.InsertEntry
                        , Globals.Credentials.SheetID //Timesheet ID
                        //EntryDate
                        , DateTime.Parse(Row[0].ToString()).Year //EntryDate - Year
                        , DateTime.Parse(Row[0].ToString()).Month //EntryDate - Month
                        , DateTime.Parse(Row[0].ToString()).Day //EntryDate - Day
                        //TimeIn
                        , DateTime.Parse(Row[1].ToString()).Hour //TimeIn - Hour
                        , DateTime.Parse(Row[1].ToString()).Minute //TimeIn - Minute
                        //TimeOut
                        , DateTime.Parse(Row[2].ToString()).Hour //TimeOut - Hour
                        , DateTime.Parse(Row[2].ToString()).Minute //TimeOut - Minute
                        //Comments
                        , Convert.ToString(Row[3] + " * " + Row[4] + ": " + Row[5]) //Comments
                    ));
                }
                MessageBox.Show("Time Sheet Syncing Completed!");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void SpreadSheetExport()
        {
            DataTable tempTable = new DataTable();
            tempTable.TableName = "TimeSheet";
            tempTable.Columns.Add("Date", typeof(string));
            tempTable.Columns.Add("TimeIn", typeof(string));
            tempTable.Columns.Add("TimeOut", typeof(string));
            tempTable.Columns.Add("Description", typeof(string));
            foreach (DataRow Row in Globals.DBLayer.dataTable.Rows)
            {
                tempTable.Rows.Add(Row[0].ToString(), Row[1].ToString(), Row[2].ToString(), Convert.ToString(Row[3] + " * " + Row[4] + ": " + Row[5]));
            }

            Globals.Export.Path = Application.StartupPath + "\\Exports\\" + dtpStart.Value.ToString("yyyy-MM-dd") + " To " + dtpStart.Value.AddDays(7).ToString("yyyy-MM-dd");
            if (cboExport.Text == "Excel Spread Sheet")
            {
                Globals.Export.Path += ".xlsx";
                Export.ToExcel(tempTable, Globals.Export.Path);
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to open the exported file?", "Open file", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Process.Start(Globals.Export.Path);
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            int dayOfWeek;
            dayOfWeek = (int)dtpStart.Value.DayOfWeek;
            dtpStart.Value = dtpStart.Value.AddDays(-dayOfWeek);
        }
    }
}
