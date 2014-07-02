using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using TimesheetManager.Helpers;
using TimesheetManager.Library;
namespace TimesheetManager.Workers
{
    public static class GetScreenImage
    {
        public static void CaptureImage(Rectangle rectangle)
        {
            try
            {
                Globals.Mech.Bitmap = new Bitmap(rectangle.Width, rectangle.Height);
                using (Graphics gfx = Graphics.FromImage(Globals.Mech.Bitmap))
                {
                    gfx.CopyFromScreen(rectangle.Location, new Point(0, 0), rectangle.Size);
                }
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.Message);
            }
        }
    }
}

