using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimesheetManager.Library;
using TimesheetManager.Workers;

namespace TimesheetManager
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SettingsWindow_Load(object sender, EventArgs e)
        {
            try
            {
                foreach(string Settings in File.ReadAllLines(Globals.Settings.iniPath))
                {
                    switch (Settings)
                    {
                        case "ShowBalloon=1":
                            rbShowBalloonY.Checked = true;
                            break;
                        case "ShowBalloon=0":
                            rbShowBalloonN.Checked = true;
                            break;
                        case "ShowDialog=1":
                            rbShowNoteY.Checked = true;
                            break;
                        case "ShowDialog=0":
                            rbShowNoteN.Checked = true;
                            break;
                        case "RunatStart=1":
                            rbStartupY.Checked = true;
                            break;
                        case "RunatStart=0":
                            rbStartupN.Checked = true;
                            break;
                        case "TrackingMethod=Service":
                            rbService.Checked = true;
                            break;
                        case "TrackingMethod=OCR":
                            rbOCR.Checked = true;
                            break;
                    }

                    //Globals.Settings.Add(Names.Lists.TempRules, Settings);
                }
            }
            catch
            {
                //PROBABLY BECAUSE IT IS GONE
            }
            finally
            {
                
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbShowBalloonY.Checked)
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "ShowBalloon=1");
                }
                else
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "ShowBalloon=0");
                }

                if (rbShowNoteY.Checked)
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "ShowDialog=1");
                }
                else
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "ShowDialog=0");
                }

                if (rbStartupY.Checked)
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "RunatStart=1");
                }
                else
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "RunatStart=0");
                }

                if (rbOCR.Checked)
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "TrackingMethod=OCR");
                }

                if (rbService.Checked)
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "TrackingMethod=Service");
                }
            }
            catch
            {
            }
            finally
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
                SettingsManager.LoadSettings();
                this.Close();
            }
        }
    }
}
