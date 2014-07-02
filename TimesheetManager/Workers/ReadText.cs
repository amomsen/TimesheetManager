using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tessnet2;
using TimesheetManager.Library;

namespace TimesheetManager.Workers
{
    public static class ReadText
    {
        public static void Read()
        {
            try
            {
                Globals.Dialog.IssueNumber = string.Empty;
                Globals.Save.IssueNumber = string.Empty;
                Globals.Save.Description = string.Empty;

                string languagePath = Globals.Static.tessnetLangauge;

                Tesseract OCR = new Tesseract();

                OCR.Init(Globals.Static.tessnetLangauge, "Eng", false);

                List<Word> results = OCR.DoOCR(Globals.Mech.Bitmap, System.Drawing.Rectangle.Empty);

                foreach (Word w in results)
                {
                    if (w.Text.StartsWith("SYM"))
                    {
                        Globals.Dialog.IssueNumber = String.Format("[#{0}]", w.Text.ToString());
                        Globals.Save.IssueNumber = String.Format("[#{0}]", w.Text.ToString());
                    }
                    else
                    {
                        Globals.Save.Description += String.Format("{0}{1}", " ", w.Text.ToString());
                    }
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
    }
}
