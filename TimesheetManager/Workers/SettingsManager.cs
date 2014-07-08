using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text;
//using System.Windows.Forms;
using TimesheetManager.Library;
using System.Threading;
using System.ComponentModel;

namespace TimesheetManager.Workers
{
    public static class SettingsManager
    {
        static BackgroundWorker asyncStatusWorker = new BackgroundWorker();
        public static void LoadSettings()
        {
            try
            {
                asyncStatusWorker.WorkerReportsProgress = true;
                asyncStatusWorker.WorkerSupportsCancellation = true;
                asyncStatusWorker.DoWork += new DoWorkEventHandler(StartService);

				// Set detaults
				Globals.Rules.ShowNotesDialog = true;
				Globals.Rules.ShowBalloon = true;
				Globals.Rules.TrackingMethod = "OCR";

                if (File.Exists(Globals.Settings.iniPath))
                {
                    foreach (string Rule in File.ReadAllLines(Globals.Settings.iniPath))
                    {
                        switch (Rule)
                        {
                            case "ShowBalloon=1":
                                Globals.Rules.ShowBalloon = true;
                                break;
                            case "ShowBalloon=0":
                                Globals.Rules.ShowBalloon = false;
                                break;
                            case "ShowDialog=1":
                                Globals.Rules.ShowNotesDialog = true;
                                break;
                            case "ShowDialog=0":
                                Globals.Rules.ShowNotesDialog = false;
                                break;
                            case "RunatStart=1":
                                AddToStartup();
                                break;
                            case "RunatStart=0":
                                RemoveFromStartup();
                                break;
                            case "TrackingMethod=OCR":
                                try
                                {
                                    IssueTracker.DoQuit();
                                    asyncStatusWorker.CancelAsync();
                                }
                                catch
                                {
                                    //it is not running
                                }
                                Globals.Rules.TrackingMethod = "OCR";
                                break;
                            case "TrackingMethod=Service":
                                try
                                {
                                    IssueTracker.DoQuit();
                                    asyncStatusWorker.RunWorkerAsync();
                                }
                                //EnsureService();
                                catch
                                {
                                    //it is not running
                                }
                                Globals.Rules.TrackingMethod = "Service";
                                break;
                        }
                        if (Rule.StartsWith("Username="))
                        { 
                            Globals.Credentials.Username = Cryptography.Decrypt(Rule.Substring(9, Rule.Count() - 9));
                        }
                        if (Rule.StartsWith("Password="))
                        {
                            Globals.Credentials.Password = Cryptography.Decrypt(Rule.Substring(9, Rule.Count() - 9));
                        }
                    }
                }
                
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
        public static void SaveSettings()
        {
            if (File.Exists(Globals.Settings.iniPath))
            {
                File.Delete(Globals.Settings.iniPath);
                File.WriteAllText(Globals.Settings.iniPath, "[Overseer Settings]" + Environment.NewLine);
            }
            else
            {
                File.WriteAllText(Globals.Settings.iniPath, "[Overseer Settings]" + Environment.NewLine);
            }

            foreach (string Rule in Globals.Settings.Get(Names.Lists.iniRules))
            {
                File.AppendAllText(Globals.Settings.iniPath, String.Format("{0}{1}", Rule, Environment.NewLine));
            }
        }

        public static void LoadDefaults()
        {

        }

        private static void AddToStartup()
        {
            try
            {
                IWshRuntimeLibrary.WshShellClass wshShell = new IWshRuntimeLibrary.WshShellClass();
                IWshRuntimeLibrary.IWshShortcut shortcut;

                shortcut = (IWshRuntimeLibrary.IWshShortcut)wshShell.CreateShortcut(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + Application.ProductName + ".lnk");

                shortcut.TargetPath = Application.ExecutablePath;
                shortcut.WorkingDirectory = Application.StartupPath;
                shortcut.Description = "Launch Overseer";

                shortcut.Save();
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        private static void RemoveFromStartup()
        {
            try
            {
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + Application.ProductName + ".lnk"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Startup) + "\\" + Application.ProductName + ".lnk");
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

		private static void StartService(object sender, DoWorkEventArgs e)
		{
			IssueTracker.Start();
		}
    }
}
