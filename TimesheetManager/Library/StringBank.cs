using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimesheetManager.Library
{
    public static class StringBank
    {

        public struct OnTime
        {
            
        }

        public struct DBQuery
        {
            public static string SheetEntry =
            @"CREATE TABLE SheetEntry 
            ( 
                ID               INT IDENTITY( 1, 1 )  PRIMARY KEY,
                IssueDate        DATE,
                StartTime        DATETIME,
                EndTime          DATETIME,
                IssueNumber      VARCHAR,
                ShortDescription VARCHAR,
                PersonalNotes    VARCHAR 
            );";

            public static string SelectRange =
            "SELECT CAST([IssueDate] AS NVARCHAR) AS [IssueDate], CAST([StartTime] AS NVARCHAR) AS [StartTime], CAST([EndTime] AS NVARCHAR) AS [EndTime], [IssueNumber], [ShortDescription], [PersonalNotes] FROM [SheetEntry] WHERE [IssueDate] BETWEEN '{0}' AND '{1}'";

            public static string InsertData =
            "INSERT INTO [SheetEntry] ([IssueDate], [StartTime], [EndTime], [IssueNumber], [ShortDescription], [PersonalNotes])" +
            "VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')"; 
        }

        public struct Regedit
        {
            public static string DoMerge = String.Format
            (
                  "Windows Registry Editor Version 5.00 {0} [HKEY_CURRENT_USER\\Software\\Microsoft\\Office\\14.0\\Word\\Internet\\Fonts] {0} {1}Latin{1}={1}Arial, 12, Arial, 10{1}"
                , Environment.NewLine
                , "\""
            );

            public static string DoDelete =
            "Windows Registry Editor Version 5.00 [-HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings]";
        }

        public struct Replicon
        {
            
        }
    }
}
