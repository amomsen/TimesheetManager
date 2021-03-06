﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TimesheetManager.Library;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TimesheetManager.Workers
{
    public static class DBLayer
    {
        public static void RunCheck(string Query)
        {
            if (!File.Exists(Globals.DBLayer.dbPath) == true)
            {
                try
                {
                    using(SQLiteConnection Conn = new SQLiteConnection(Globals.DBLayer.SLConnStr))
                    {
                        using(SQLiteCommand Comm = new SQLiteCommand(Query, Conn))
                        {
                            SQLiteConnection.CreateFile(Globals.DBLayer.dbPath);
                            Conn.Open();
                            Comm.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception exc)
                {
                    System.Windows.Forms.MessageBox.Show(exc.Message);
                }
            }
        }

        public static void Set(string Query)
        {
            try
            {
                using (SQLiteConnection Conn = new SQLiteConnection(Globals.DBLayer.SLConnStr))
                {
                    using (SQLiteCommand Comm = new SQLiteCommand(Query, Conn))
                    {
                        Conn.Open();
                        Comm.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        public static void Get(string Query)
        {
            try
            {
                using (SQLiteConnection Conn = new SQLiteConnection(Globals.DBLayer.SLConnStr))
                {
                    using (SQLiteCommand Comm = new SQLiteCommand(Query, Conn))
                    {
                        Conn.Open();
                        Globals.DBLayer.dataTable.Clear();
                        Globals.DBLayer.dataTable.Load(Comm.ExecuteReader());
                    }
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
    }
}
