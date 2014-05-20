using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using ClosedXML;
using ClosedXML.Excel;

namespace TimesheetManager.Workers
{
    public static class Export
    {
        public static void ToExcel(DataTable dt, string path)
        {
            try
            {
                var WorkBook = new XLWorkbook();
                WorkBook.Worksheets.Add(dt);
                WorkBook.SaveAs(path);
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
    }
}
