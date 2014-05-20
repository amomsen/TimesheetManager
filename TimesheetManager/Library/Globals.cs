using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace TimesheetManager.Library
{
    public static class Globals
    {
        public struct Static
        {
            public static string tessnetLangauge = String.Format("{0}\\Tesseract", Application.StartupPath);
            public static string regeditLocation = "C:\\Registry.reg";
        }

        public struct Mech
        {
            public static bool IsStarting { get; set; }
            public static bool IsActiveDraw { get; set; }
            public static bool IsLoading { get; set; }
            public static string CurrentNote { get; set; }
            public static Bitmap Bitmap { get; set; }
            public static ListViewItem newRow { get; set; }
        }

        public struct Save
        {
            public static DateTime StartDate { get; set; }
            public static DateTime EndDate { get; set; }
            public static string IssueNumber { get; set; }
            public static string Description { get; set; }
            public static string Notes { get; set; }
        }

        public struct Dialog
        {
            public static string IssueNumber { get; set; }
        }

        public struct Rules
        {
            public static bool ShowBalloon { get; set; }
            public static bool ShowNotesDialog { get; set; }
            public static string TrackingMethod { get; set; }
        }

        public struct Credentials
        {
            public static string Url = "http://app.symplexity.co.za:82/TimeSheet/RemoteApi/RemoteApi.ashx/8.25";
            public static string Password { get; set; }
            public static string Username { get; set; }

//            static string Query_UserAll = @"[
//  {
//    ""Action"": ""Query"",
//    ""QueryType"": ""UserAll"",
//    ""DomainType"": ""Replicon.Domain.User"",
//    ""Args"": []
//  }
//]";
        }

        public struct DBLayer
        {
            private static DataTable _dataTable = new DataTable();
            public static DataTable dataTable
            {
                get
                {
                    return _dataTable;
                }
                set
                {
                    _dataTable = dataTable.Clone();
                }
            }
            public static string SLConnStr = "Data Source=" + Application.StartupPath + "\\Timesheet.s3db" + ";Version=3;";
            public static string dbPath = Application.StartupPath + "\\Timesheet.s3db";
            public static SQLiteConnection SLConn = new SQLiteConnection(SLConnStr);
            public static SQLiteCommand SLComm = SLConn.CreateCommand();

            public static void Dispose()
            {
                SLConn.Close();
                SLComm.Dispose();
            }
        }

        public struct SQLHandshakeVars
        {
            public static string SQLConnStr { get; set; }

            public static DataTable dataTable { get; set; }

            private static SqlConnection _sqlConn = new SqlConnection();

            private static SqlCommand _sqlComm = new SqlCommand();

            public static SqlConnection SQLConn
            {
                get { return _sqlConn; }
                set { _sqlConn = SQLConn; }
            }

            public static SqlCommand SQLComm
            {
                get { return (_sqlComm); }
                set { _sqlComm = SQLComm; }
            } 
        }

        public struct Settings
        {
            public static string iniPath = Application.StartupPath + "\\Settings.ini";
            private static List<string> iniRules = new List<string>();

            public static void Add(string ListName, string Value)
            {
                if (ListName == Names.Lists.iniRules)
                {
                    iniRules.Add(Value);
                }
            }

            public static List<string> Get(string ListName)
            {
                if (ListName == Names.Lists.iniRules)
                {
                    return iniRules.ToList();
                }
                return null; 
            }
        }

        public struct OnTime
        {
            private static DataTable _dataTable = new DataTable();
            public static DataTable dataTable
            {
                get
                {
                    return _dataTable;
                }
                set
                {
                    _dataTable = dataTable.Clone();
                }
            }

            public static string IssueID { get; set; }
            public static string ConnStr = "Data Source=SYMFILE\\SYMAPP;Initial Catalog=OnTime2010;Persist Security Info=True;User id=ontimeread;Password=ontimeread123";
            public static string Select = "SELECT  IncidentId , IncidentNumber , Name FROM dbo.Incidents AS I WHERE IncidentId = {0}";
        }

        public struct Export
        {
            public static string Path { get; set; }
            public static DataTable dataTable { get; set; }
        }
    }
}
