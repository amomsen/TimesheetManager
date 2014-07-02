using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TimesheetManager.Helpers;

namespace TimesheetManager.Links
{
    public static class Instances
    {
        public static KeyboardHook KeyBinder = new KeyboardHook();
        public static Form customDialog = new Form();
        public static SettingsWindow settingsWindow = new SettingsWindow();
        public static HistoryWindow historyWindow = new HistoryWindow();
    }
}
