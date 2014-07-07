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
            public static string InitSession =
            @"[
              {{
                ""Action"": ""Query"",
                ""QueryType"": ""UserByLoginName"",
                ""DomainType"": ""Replicon.Domain.User"",
                ""Args"": [
                  ""{0}""
                ]
              }}
            ]";

            public static string GetSheetID =
            @"
            [
              {{
                ""Action"": ""Query"",
                ""QueryType"": ""EntryTimesheetByUserDate"",
                ""DomainType"": ""Replicon.Suite.Domain.EntryTimesheet"",
                ""Args"": [
                  {{
                    ""__type"": ""Replicon.Domain.User"",
                    ""Identity"": ""{0}""
                  }},
                  {{
                    ""__type"": ""Date"",
                    ""Year"": {1},
                    ""Month"": {2},
                    ""Day"": {3}
                  }}
                ],
                ""Load"": [
                  {{
                    ""Relationship"": ""TimeEntries""
                  }},
                  {{
                    ""Relationship"": ""TimeOffEntries""
                  }}
                ]
              }}
            ]";

            public static string InsertEntry =
            @"
            [
              {{
                ""Action"": ""Edit"",
                ""Type"": ""Replicon.Suite.Domain.EntryTimesheet"",
                ""Identity"": ""{0}"",
                ""Operations"": [
                  {{
                    ""__operation"": ""CollectionAdd"",
                    ""Collection"": ""TimeEntries"",
                    ""Operations"": [
                      {{
                        ""__operation"": ""SetRowUdfValues""
                      }},
                      {{
                        ""__operation"": ""SetProperties"",
                        ""CalculationModeObject"": {{
                          ""__type"": ""Replicon.TimeSheet.Domain.CalculationModeObject"",
                          ""Identity"": ""CalculateDuration""
                        }},
                        ""EntryDate"": {{
                          ""__type"": ""Date"",
                          ""Year"": {1},
                          ""Month"": {2},
                          ""Day"": {3}
                        }},
                        ""TimeIn"": {{
                          ""__type"": ""Time"",
                          ""Hour"": {4},
                          ""Minute"": {5}
                        }},
                        ""TimeOut"": {{
                          ""__type"": ""Time"",
                          ""Hour"": {6},
                          ""Minute"": {7}
                        }},
                        ""Comments"": ""{8}"",
                        ""Task"": {{
                          ""Identity"": ""8111""
                        }},
                        ""Activity"": {{
                          ""Identity"": ""1""
                        }}
                      }}
                    ]
                  }}
                ]
              }}
            ]";
        }
    }
}
