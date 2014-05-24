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

            private static List<string> WordList = new List<string>();

            public static void AddWord(string Value)
            {
                WordList.Add(Value);
            }

            public static List<string> GetWords()
            {
                if (WordList != null)
                {
                    return WordList.ToList();
                }
                return null;
            }

            //private static string[] _WordList = { "" };
            //public static string[] WordList 
            //{
            //    get 
            //    {
            //        return _WordList;
            //    }
            //    set 
            //    {
            //        _WordList = WordList.ToArray();
            //    } 
            //}
        }

        public struct Save
        {
            public static DateTime StartDate { get; set; }
            public static DateTime EndDate { get; set; }
            private static string _IssueNumber = "";
            public static string IssueNumber { get; set; } //{ get { return _IssueNumber; } set { _IssueNumber = IssueNumber; } }
            private static string _Description = "";
            public static string Description { get; set; } //{ get { return _Description; } set { _Description = Description; } }
            public static string Notes { get; set; }
        }

        public struct Dialog
        {
            private static string _IssueNumber = "";
            public static string IssueNumber { get; set; } //{ get { return _IssueNumber; } set { _IssueNumber = IssueNumber; } }
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

        public struct Export
        {
            public static string Path { get; set; }
            public static DataTable dataTable { get; set; }
        }
    }
}
