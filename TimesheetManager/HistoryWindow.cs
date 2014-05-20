﻿using System;
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
            dtpStart.Value = DateTime.Today.AddDays(-7);
            dtpEnd.Value = DateTime.Today;
            cboExport.SelectedIndex = 0;
            GetHistory();
        }

        private void GetHistory()
        {
            DBLayer.Get(String.Format(StringBank.DBQuery.SelectRange, Convert.ToDateTime(dtpStart.Value), Convert.ToDateTime(dtpEnd.Value)));
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

            Globals.Export.Path = Application.StartupPath + "\\Exports\\" + dtpStart.Value.ToString("yyyy-MM-dd") + " To " + dtpEnd.Value.ToString("yyyy-MM-dd");
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lvHistory.Items.Clear();
            GetHistory();
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            //if (dtpEnd.Value != dtpStart.Value.AddDays(7))
            //{
            //    dtpEnd.Value = dtpStart.Value.AddDays(7);
            //}
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            //if (dtpStart.Value != dtpEnd.Value.AddDays(-7))
            //{
            //    dtpStart.Value = dtpEnd.Value.AddDays(-7);
            //}
        }
    }
}
