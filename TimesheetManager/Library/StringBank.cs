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
            public static string Blej =
            "[ { \"Action\": \"Edit\", \"Type\": \"Replicon.Suite.Domain.EntryTimesheet\", \"Identity\": \"1\", \"Operations\": [ { \"__operation\": \"CollectionAdd\", \"Collection\": \"TimeEntries\", \"Operations\": [ { \"__operation\": \"SetCellUdfValues\", \"CellLevelUDF1\": \"10\" }, { \"__operation\": \"SetProperties\", \"CalculationModeObject\": { \"__type\": \"Replicon.TimeSheet.Domain.CalculationModeObject\", \"Identity\": \"CalculateDuration\" }, \"EntryDate\": { \"__type\": \"Date\", \"Year\": 2011, \"Month\": 5, \"Day\": 12 }, \"TimeIn\": { \"__type\": \"Time\", \"Hour\": 8, \"Minute\": 0 }, \"TimeOut\": { \"__type\": \"Time\", \"Hour\": 11, \"Minute\": 0 }, \"Comments\": \"hello 123\", \"Task\": { \"Identity\": \"1\" }, \"Activity\": { \"Identity\": \"1\" } }, { \"__operation\": \"SetTimeEntryBilling\", \"BillingType\": { \"__type\": \"Replicon.Project.Domain.Timesheets.TimesheetBillingType\", \"Identity\": \"ProjectRate\" }, \"Project\": { \"__type\": \"Replicon.Project.Domain.Project\", \"Identity\": \"1\" } } ] } ] } ]";

            public static string NewEntry =
@"
[ {
    {0}Action{0}: {0}Edit{0},
    {0}Type{0}: {0}Replicon.Suite.Domain.EntryTimesheet{0},
    {0}Identity{0}: {0}1{0},
    {0}Operations{0}:
    [ {
        {0}__operation{0}: {0}CollectionAdd{0},
        {0}Collection{0}: {0}TimeEntries{0},
        {0}Operations{0}:
        [ {
            {0}__operation{0}: {0}SetCellUdfValues{0},
            {0}CellLevelUDF{0}: {0}10{0}
         },
         {
            {0}__operation{0}: {0}SetProperties{0},
            {0}CalculationModeObject{0}:
            {
                {0}__type{0}: {0}Replicon.TimeSheet.Domain.CalculationModeObject{0},
                {0}Identity{0}: {0}CalculateDuration{0}
            },
            {0}EntryDate{0}:
            {   
                {0}__type{0}: {0}Date{0},
                {0}Year{0}: {0}{2}{0},
                {0}Month{0}: {0}{3}{0},
                {0}Day{0}: {0}{4}{0},
            },
            {0}TimeIn{0}:
            {
                {0}__type{0}: {0}Time{0},
                {0}Hour{0}: {0}{5}{0},
                {0}Minute{0}: {0}{6}{0}
            },  
            {0}TimeOut{0}:
            {
                {0}__type{0}: {0}Time{0},
                {0}Hour{0}: {0}{7}{0},
                {0}Minute{0}: {0}{8}{0}
            },
            {0}Comments{0}: {0}{9}{0},
            {0}Task{0}: 
            {
                {0}Identity{0}: {0}1{0}
            },
            {0}Activity{0}: 
            {
                {0}Identity{0}: {0}1{0}
            }
        },
        {
            {0}__operation{0}: {0}SetTimeEntryBilling{0},
            {0}BillingType{0}:
            {
                {0}__type{0}: {0}Replicon.Project.Domain.Timesheets.TimesheetBillingType,
                {0}Identity{0}: {0}ProjectRate{0}
            },
            {0}Project{0}: 
            {
                {0}__type{0}, {0}Replicon.Project.Domain.Project{0},
                {0}Identity{0}: {0}1{0}
            } 
        } ]
    } ] 
} ]";        
        }
    }
}
