using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TimesheetManager.Helpers
{
    public partial class elasticForm : Form
    {
        public Point lastLocation;
        public Size lastSize;

        bool mouseDown = false;
        Point startingPoint = Point.Empty;
        Point endingPoint = Point.Empty;

        MainWindow mainWindow;

        Pen pen;

        Rectangle bounds = new Rectangle();

        public elasticForm(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            
            InitializeComponent();

            this.TopMost = true;
            this.Opacity = .25;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Location = new Point(0, 0);

            DoubleBuffered = true;

            pen = new Pen(System.Drawing.Color.Black, 2);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            int maxX = 0;
            int maxY = 0;

            foreach (Screen screen in System.Windows.Forms.Screen.AllScreens)
            {
                int x = screen.Bounds.X + screen.Bounds.Width;
                if (x > maxX)
                {
                    maxX = x;
                }
                int y = screen.Bounds.Y + screen.Bounds.Height;
                if (y > maxY)
                {
                    maxY = y;
                }
            }
            bounds.X = 0;
            bounds.Y = 0;
            bounds.Width = maxX;
            bounds.Height = maxY;

            this.Size = new Size(bounds.Width, bounds.Height);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseDown = true;
            endingPoint = startingPoint = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseDown = false;

            this.lastLocation = new Point(Math.Min(startingPoint.X, endingPoint.X), Math.Min(startingPoint.Y, endingPoint.Y));
            this.lastSize = new Size(Math.Abs(startingPoint.X - endingPoint.X), Math.Abs(startingPoint.Y - endingPoint.Y));
            this.Close();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            endingPoint = e.Location;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Region region = new Region(bounds);

            if (mouseDown)
            {
                Rectangle selectionWindow = new Rectangle(Math.Min(startingPoint.X, endingPoint.X), Math.Min(startingPoint.Y, endingPoint.Y), Math.Abs(startingPoint.X - endingPoint.X), Math.Abs(startingPoint.Y - endingPoint.Y));
                region.Xor(selectionWindow);
                e.Graphics.FillRegion(Brushes.Black, region);
            }
            else
            {
                e.Graphics.FillRegion(Brushes.LightGray, region);
                e.Graphics.DrawLine(pen, endingPoint.X, 0, endingPoint.X, this.Size.Height);
                e.Graphics.DrawLine(pen, 0, endingPoint.Y, this.Size.Width, endingPoint.Y);
            }
        }
    }
}

