using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TimesheetManager.Helpers;
using TimesheetManager.Library;
using TimesheetManager.Links;
using TimesheetManager.Workers;

namespace TimesheetManager
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            Instances.KeyBinder.KeyPressed += new EventHandler<KeyPressedEventArgs>(OnCaptureShortcutFired);
            Instances.KeyBinder.RegisterHotKey((Helpers.ModifierKeys.Control) | (Helpers.ModifierKeys.Shift), Keys.X);
            Globals.Mech.IsActiveDraw = false;
            Globals.Mech.IsStarting = true;
            InitHandler.DoWork();
            DBLayer.RunCheck(StringBank.DBQuery.SheetEntry);
        }

        #region FormEvents

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.cmsMenu.Size = new System.Drawing.Size(0, 0);
            SettingsManager.LoadSettings();
        }

        private void NotifyUser_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            IssueTracker.DoQuit();

            File.WriteAllText(Globals.Static.regeditLocation, StringBank.Regedit.DoDelete);
            Process RunRegedit = Process.Start("regedit.exe", String.Format("/s {0}", Globals.Static.regeditLocation));
            RunRegedit.WaitForExit();

            File.Delete(Globals.Static.regeditLocation);
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                NotifyUser.Visible = true;
                this.Hide();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                NotifyUser.Visible = false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sendSuggestionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instances.settingsWindow.ShowDialog();
        }

        private void viewTimesheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Instances.historyWindow.ShowDialog();
        }
  
        #endregion

        #region CustomEvents

        public void OnCaptureShortcutFired(object sender, KeyPressedEventArgs e)
        {
            if (Globals.Mech.IsStarting == true)
            {
                OnCaptureStarting();
            }
            else if (Globals.Mech.IsStarting == false)
            {
                OnCaptureEnding();
            }
            else
            {
                //Error?
            }
        }

        #endregion

        #region FormEventWorkers

        #endregion

        #region CustomEventWorkers

        private void OnCaptureStarting()
        {
            try
            {
                if (Globals.Rules.TrackingMethod == "OCR")
                {
                    OCRMethod();
                }
                else if (Globals.Rules.TrackingMethod == "Service")
                {
                    ServiceMethod();
                }

                Globals.Save.StartDate = DateTime.Now;

                if (Globals.Save.IssueNumber.StartsWith("[#SYM"))
                {
                    NotifyUser.BalloonTipText = String.Format("Started issue: {0},{2}at {1}{2}", Globals.Save.IssueNumber, Globals.Save.StartDate.ToString("t"), Environment.NewLine);
                    if (Globals.Rules.ShowBalloon == true)
                    {
                        NotifyUser.ShowBalloonTip(500);
                    }
                    Globals.Mech.IsStarting = false;
                }
                else
                {
                    Globals.Mech.IsStarting = true;
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        private void OnCaptureEnding()
        {
            try
            {
                Globals.Mech.CurrentNote = string.Empty;
                Globals.Save.EndDate = DateTime.Now;
                if (Globals.Rules.ShowNotesDialog == true)
                {
                    Globals.Save.Notes = customDialog.ShowDialog(Globals.Dialog.IssueNumber);
                }
                DBLayer.Set(String.Format(StringBank.DBQuery.InsertData, DateTime.Now.ToShortDateString(), Globals.Save.StartDate.ToShortTimeString(), Globals.Save.EndDate.ToShortTimeString(), Globals.Save.IssueNumber, Globals.Save.Description, Globals.Save.Notes));
                Globals.Mech.IsStarting = true;
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        private void OCRMethod()
        {
            try
            {
                if (Globals.Mech.IsActiveDraw == true)
                {
                    return;
                }

                Globals.Mech.IsActiveDraw = true;

                if (Globals.Mech.Bitmap != null)
                {
                    Globals.Mech.Bitmap.Dispose();
                }

                using (elasticForm _elastic = new elasticForm(this))
                {
                    _elastic.ShowDialog();
                    Size elasticSize = _elastic.lastSize;
                    if (elasticSize.Width > 0 && elasticSize.Height > 0)
                    {
                        Rectangle rectangle = new Rectangle();
                        rectangle.Location = _elastic.lastLocation;
                        rectangle.Size = elasticSize;
                        GetScreenImage.CaptureImage(rectangle);
                    }
                }

                this.Show();

                Globals.Mech.IsActiveDraw = false;

                ReadText.Read();
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }

        private void ServiceMethod()
        {
            try
            {
                Globals.Dialog.IssueNumber = String.Format("[#{0}]", Globals.OnTime.IssueNumber);
                Globals.Save.IssueNumber = String.Format("[#{0}]", Globals.OnTime.IssueNumber);
                Globals.Save.Description = Globals.OnTime.IssueDescription;
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
        #endregion
    }
}
