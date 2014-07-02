using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace TimesheetManager
{
    public partial class SuggestionWindow : Form
    {
        public SuggestionWindow()
        {
            InitializeComponent();
        }

        private void SuggestionWindow_Load(object sender, EventArgs e)
        {
            MailMessage message = new MailMessage();
            message.To.Add("Info@Suggestions.Hostei.com");
            message.Subject = "Why don't you?";
            message.From = new System.Net.Mail.MailAddress("milos90zr@hotmail.com");
            message.Body = "OK";
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Send(message);
        }
    }
}
