using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimesheetManager.Helpers
{
    public static class customDialog
    {
        public static string ShowDialog(string IssueNumber)
        {
            Form customDialog = new Form();
            customDialog.Size = new System.Drawing.Size(320, 170);
            customDialog.MinimumSize = new System.Drawing.Size(320, 170);
            customDialog.MaximumSize = new System.Drawing.Size(320, 170);
            customDialog.Text = "Comment or Notes?";
            customDialog.Icon = new System.Drawing.Icon(Application.StartupPath + "\\Clock.ico");
            #region Design
            //lblNoteText
            Label lblNoteText = new Label();
            lblNoteText.AutoSize = true;
            lblNoteText.Location = new System.Drawing.Point(9, 9);
            lblNoteText.Name = "lblNoteText";
            lblNoteText.Size = new System.Drawing.Size(149, 13);
            lblNoteText.TabIndex = 0;
            lblNoteText.Text = String.Format("Notes or comments for issue {0}:", IssueNumber);
            //lblNoteText.KeyDown += new System.Windows.Forms.KeyEventHandler();
            //txtNotes
            TextBox txtNotes = new TextBox();
            txtNotes.Location = new System.Drawing.Point(12, 25);
            txtNotes.Multiline = true;
            txtNotes.Name = "textBox1";
            txtNotes.Size = new System.Drawing.Size(281, 66);
            txtNotes.TabIndex = 1;
            //btnContinue
            Button btnContinue = new Button();
            btnContinue.Location = new System.Drawing.Point(218, 97);
            btnContinue.Name = "btnContinue";
            btnContinue.Size = new System.Drawing.Size(75, 23);
            btnContinue.TabIndex = 2;
            btnContinue.Text = "Continue";
            btnContinue.UseVisualStyleBackColor = true;
            btnContinue.Click += (sender, e) => { customDialog.Close(); };
            //btnCancel
            Button btnCancel = new Button();
            btnCancel.Location = new System.Drawing.Point(12, 97);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(75, 23);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += (sender, e) => { customDialog.Close(); };
            #endregion


            //confirmation.Click += (sender, e) => { prompt.Close(); };
            customDialog.Controls.Add(lblNoteText);
            customDialog.Controls.Add(txtNotes);
            customDialog.Controls.Add(btnContinue);
            //customDialog.Controls.Add(btnCancel);

            customDialog.ShowDialog();
            
            return txtNotes.Text;
        }
    }
}
