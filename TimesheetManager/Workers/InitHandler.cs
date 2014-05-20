using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using TimesheetManager.Library;

namespace TimesheetManager.Workers
{
    public static class InitHandler
    {
        public static void DoWork()
        {
            try
            {
                File.WriteAllText(Globals.Static.regeditLocation, StringBank.Regedit.DoMerge);
                Process RunRegedit = Process.Start("regedit.exe", String.Format("/s {0}", Globals.Static.regeditLocation));
                RunRegedit.WaitForExit();
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);  
            }
            finally
            {
                File.Delete(Globals.Static.regeditLocation);
            }
        }
    }
}
