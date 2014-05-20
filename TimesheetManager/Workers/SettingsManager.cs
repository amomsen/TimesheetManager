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
                                if (!asyncStatusWorker.IsBusy)
                                {
                                    asyncStatusWorker.Dispose();
                                }
                                Globals.Rules.TrackingMethod = "OCR";
                                break;
                            case "TrackingMethod=Service":
                                if (!asyncStatusWorker.IsBusy)
                                {
                                    asyncStatusWorker.RunWorkerAsync();
                                }
                                //EnsureService();
                                Globals.Rules.TrackingMethod = "Service";
                                break;
                        }
                    }
                }
                else
                {
                    Globals.Rules.ShowNotesDialog = true;
                    Globals.Rules.ShowBalloon = true;
                    Globals.Rules.TrackingMethod = "OCR";
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
        public static void SaveSettings()
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

        private static void EnsureService()
        {
            //Check if the service still exists
            //if (!File.Exists(Application.StartupPath + "\\Issue Tracking Service.exe"))
            //{
            //    //write it if it does not exist
            //    File.WriteAllBytes(Application.StartupPath + "\\Issue Tracking Service.exe", TimesheetManager.Properties.Resources.Overseer_Service);
            //}
            ////Check for the fiddler core dll 
            //if (!File.Exists(Application.StartupPath + "\\FiddlerCore4.dll"))
            //{
            //    //write it if it does not exist
            //    File.WriteAllBytes(Application.StartupPath + "\\FiddlerCore4.dll", TimesheetManager.Properties.Resources.FiddlerCore4);
            //}

            ////Service checks if it is not found install and start it
            //if (ServiceInstaller.GetServiceStatus("Issue Tracking Service") == ServiceState.NotFound)
            //{
            //    ServiceInstaller.InstallAndStart("Issue Tracking Service", "Overseer Tracking Service", Application.StartupPath + "\\Issue Tracking Service.exe");
            //}
            
            ////Service is found but is stoped start it
            //if (ServiceInstaller.GetServiceStatus("Issue Tracking Service") == ServiceState.Stopped)
            //{
            //    ServiceInstaller.StartService("Issue Tracking Service");
            //}
        }
    }
}
