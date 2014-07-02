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
                    if (Settings.StartsWith("Username="))
                    {
                        txtUsername.Text = Cryptography.Decrypt(Settings.Substring(9, Settings.Count() - 9));
                    }
                    if (Settings.StartsWith("Password="))
                    {
                        txtPassword.Text = Cryptography.Decrypt(Settings.Substring(9, Settings.Count() - 9));
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
                if (txtUsername.Text.Trim() != "")
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "Username=" + Cryptography.Encrypt(txtUsername.Text));
                }
                if (txtPassword.Text.Trim() != "")
                {
                    Globals.Settings.Add(Names.Lists.iniRules, "Password=" + Cryptography.Encrypt(txtPassword.Text));
                }
            }
            catch
            {
            }
            finally
            {
                SettingsManager.SaveSettings();
                SettingsManager.LoadSettings();
                this.Close();
            }
        }
    }
}
