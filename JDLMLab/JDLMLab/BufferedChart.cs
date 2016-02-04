﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace JDLMLab
{
    public class BufferedChart : Panel
    {
        private BufferedGraphicsContext context;
        private BufferedGraphics grafx;

        private byte bufferingMode;
        private string[] bufferingModeStrings =
            { "Draw to Form without OptimizedDoubleBufferring control style",
          "Draw to Form using OptimizedDoubleBuffering control style",
          "Draw to HDC for form" };

        private System.Windows.Forms.Timer timer1;
        private byte count;
        public int[] dataPoints { get; set; }
        public List<int[]> CyclesIntensities { get; set; }
        private int startDragX;
        private int endDragX;
        private int yAxisHeight { get
            {
                return Height - BottomMargin - TopMargin;
            } }
        public BufferedChart() : base()
        {
            
            zoomYScales = new long[28];
            for (long f = 1, i = 0; i < 28; i++)
            {
                long c = 0;
                if (i % 3 == 0) c = 10 * f;
                if (i % 3 == 1) c = 20 * f;
                if (i % 3 == 2)
                {
                    c = 50 * f;
                    f *= 10;
                }
                zoomYScales[i] = c;
            }
            LeftMargin = 80;
            RightMargin = 10;
            BottomMargin = 30;
            TopMargin = 10;

            setParameters(0, 100, 500);
            init();

            // Configure the Form for this example.
            this.Text = "User double buffering";
            this.MouseDown += new MouseEventHandler(this.MouseDownHandler);
            this.MouseDown += klikMysi;
            this.MouseMove += pohybMysi;
            this.MouseUp += uvolnenieMysi;
            this.Resize += new EventHandler(this.OnResize);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            // Configure a timer to draw graphics updates.
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 200;
            timer1.Tick += new EventHandler(this.OnTimer);

            bufferingMode = 2;
            count = 0;

            // Retrieves the BufferedGraphicsContext for the 
            // current application domain.
            context = BufferedGraphicsManager.Current;

            // Sets the maximum size for the primary graphics buffer
            // of the buffered graphics context for the application
            // domain.  Any allocation requests for a buffer larger 
            // than this will create a temporary buffered graphics 
            // context to host the graphics buffer.
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);

            // Allocates a graphics buffer the size of this form
            // using the pixel format of the Graphics created by 
            // the Form.CreateGraphics() method, which returns a 
            // Graphics object that matches the pixel format of the form.
            grafx = context.Allocate(this.CreateGraphics(),
                 new Rectangle(0, 0, this.Width, this.Height));

            // Draw the first frame to the buffer.
            DrawToBuffer(grafx.Graphics);
        }

        private void uvolnenieMysi(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pohybMysi(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                if (e.X < LeftMargin)
                {
                    endDragX = LeftMargin;
                    CursorIndex = 0;
                }
                else if (e.X > Width - RightMargin)
                {
                    endDragX = Width - RightMargin;
                    CursorIndex = NumberofDisplayedBars - 1;
                }
                else
                {
                    endDragX = e.X;
                    int xGraf = e.X - LeftMargin;
                    CursorIndex = NumberofDisplayedBars * xGraf / XAxisWidth;
                }
                blank();
                DrawToBuffer(grafx.Graphics);
                //grafx.Render(Graphics.FromHwnd(this.Handle));
                Refresh();
            }
        }
        bool dragging;
        private void klikMysi(object sender, MouseEventArgs e)
        {
            startDragX = e.X;
            endDragX = e.X;
            dragging = true;
            if (e.Y > TopMargin && e.Y < Height - BottomMargin && e.X > LeftMargin && e.X < Width - RightMargin)
            {
                int xGraf = e.X - LeftMargin;
                CursorIndex = NumberofDisplayedBars * xGraf / XAxisWidth;
                blank();
                DrawToBuffer(grafx.Graphics);
                Refresh();
            }
        }

        public void setParameters(double minX,double maxX,int pocetBodov,int pocetCyklov=1)
        {
            NumberofBars = pocetBodov;
            this.pocetCyklov = pocetCyklov;
            MinXView = minX;
            MaxXView = maxX;
            
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        
        /// <summary>
        /// nastavit vsetky potrebne hodnoty pre dane meranie
        /// </summary>
        public void init()
        {
            dragging = false;
            CurrentCycleNum = 1;
            zoomYScalesIndex = 15;
            NumberofDisplayedBars = NumberofBars;

            CyclesKroky = new List<double[]>();
            CyclesKroky.Add(new double[NumberofBars]);
            CyclesIntensities = new List<int[]>();
            CyclesIntensities.Add(new int[NumberofBars]);
            

            Random r = new Random();
            for (int i = 0; i < NumberofBars; i++)
            {
                CyclesIntensities[0][i] = r.Next(1000000);
            }

        }

        internal void zoomXOut()
        {

        }
        int start;

        internal void zoomXIn()
        {
            if (NumberofDisplayedBars > 8 || true) //zrusit true
            {
                int oldNumber = NumberofDisplayedBars;
                NumberofDisplayedBars /= 2;
                int[] novePole = new int[NumberofDisplayedBars];

                if (CursorIndex - NumberofDisplayedBars / 2 >= 0)
                {
                    start = CursorIndex - NumberofDisplayedBars / 2 -1;
                }
                else
                {
                    start = 0;
                }

                if (CursorIndex + NumberofDisplayedBars / 2 > NumberofBars)
                {
                    start -= NumberofDisplayedBars / 2 - (oldNumber - CursorIndex) + 1;
                }
                //MessageBox.Show(NumberofDisplayedBars.ToString());
                int[] starePole = CyclesIntensities[0];
                int pom = start;
                for (int i = 0; i < NumberofDisplayedBars; i++)
                {
                    novePole[i] = starePole[pom++];
                }
                CyclesIntensities[0] = novePole;
                CursorIndex -= start;
                obnov();
            }

        }

        void obnov()
        {
            blank();
            DrawToBuffer(grafx.Graphics);
            Refresh();
        }

        internal void setCursor(MouseEventArgs e)
        {
            
        }

        private long[] zoomYScales;
        private int zoomYScalesIndex;
        

        internal void zoomYIn()
        {
            if (zoomYScalesIndex == 0) return;
            zoomYScalesIndex--;
            blank();
            DrawToBuffer(grafx.Graphics);
            Refresh();
        }
        internal void zoomYOut()
        {
            if (zoomYScalesIndex == zoomYScales.Length - 1) return;
            zoomYScalesIndex++;

            blank();
            DrawToBuffer(grafx.Graphics);
            Refresh();



        }
        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            return; //  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (e.Button == MouseButtons.Right)
            {
                // Cycle the buffering mode.
                if (++bufferingMode > 2)
                    bufferingMode = 0;

                // If the previous buffering mode used 
                // the OptimizedDoubleBuffering ControlStyle,
                // disable the control style.
                if (bufferingMode == 1)
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

                // If the current buffering mode uses
                // the OptimizedDoubleBuffering ControlStyle,
                // enabke the control style.
                if (bufferingMode == 2)
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);

                // Cause the background to be cleared and redraw.
                count = 6;
                DrawToBuffer(grafx.Graphics);
                this.Refresh();
            }
            else
            {
                // Toggle whether the redraw timer is active.
                if (timer1.Enabled)
                    timer1.Stop();
                else
                    ;//     timer1.Start();     //......................................................
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            // Draw randomly positioned ellipses to the buffer.
            DrawToBuffer(grafx.Graphics);

            // If in bufferingMode 2, draw to the form's HDC.
            if (bufferingMode == 2)
                // Render the graphics buffer to the form's HDC.
                grafx.Render(Graphics.FromHwnd(this.Handle));
            // If in bufferingMode 0 or 1, draw in the paint method.
            else
                this.Refresh();
        }

        private void OnResize(object sender, EventArgs e)
        {
            // Re-create the graphics buffer for a new window size.
            context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
            if (grafx != null)
            {
                grafx.Dispose();
                grafx = null;
            }
            grafx = context.Allocate(this.CreateGraphics(),
                new Rectangle(0, 0, this.Width, this.Height));

            

            // Cause the background to be cleared and redraw.
            count = 6;
            DrawToBuffer(grafx.Graphics);
            this.Refresh();
        }


        /// <summary>
        /// hlavna funckia na kreslenie vsetkeho
        /// </summary>
        /// <param name="g"></param>
        private void DrawToBuffer(Graphics g)
        {
            // Clear the graphics buffer every five updates.
            if (++count > 5 && 1 == 0)    ///.................
            {
                count = 0;
                blank();
            }
            //

            ///
            /// testovacie texty
            ///
            g.DrawString(CursorIndex.ToString(), new Font("Arial", 8), Brushes.White, 10, 34);
            g.DrawString(start.ToString(), new Font("Arial", 8), Brushes.White, 100, 30);
            g.DrawString(CyclesIntensities[0].Length.ToString(), new Font("Arial", 8), Brushes.White, 100, 60);
            ///
            ///...
            /// 

         

            ///
            ///bars
            /// 
            int[] hodnoty = CyclesIntensities[0];
            double barWidth = (double)(Width - LeftMargin - RightMargin) / (double)hodnoty.Length;
            int heightYAxis = Height - TopMargin - BottomMargin;
            for (int i = 0; i < hodnoty.Length; i++)
            {
                long barHeight = (long)((heightYAxis) * hodnoty[i]) / zoomYScales[zoomYScalesIndex];
                int barHeightInt = (int)barHeight;
                g.DrawLine(new Pen(Color.Aqua,
                    (int)Math.Round(barWidth)),
                    new Point(
                        LeftMargin + (int)Math.Round(i * barWidth) + (int)Math.Round(barWidth / 2),
                          Height - BottomMargin),
                    new Point(
                        LeftMargin + (int)Math.Round(i * barWidth) + (int)Math.Round(barWidth / 2),
                        Height - BottomMargin - barHeightInt));
            }

            ///
            /// select
            ///
            int lavaCast = startDragX;
            int rectWidth;
            if (startDragX > endDragX) {
                lavaCast = endDragX;
                rectWidth = startDragX - endDragX;
            }
            else
            {
                rectWidth = endDragX - startDragX;
            }
            g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.LightBlue)), new Rectangle(lavaCast, TopMargin, rectWidth, yAxisHeight));

            ///axis
            /// 
            g.DrawLine(new Pen(Color.Orange, 2), new Point(LeftMargin, Height - BottomMargin), new Point(Width - RightMargin, Height - BottomMargin));
            g.DrawLine(new Pen(Color.Orange, 2), new Point(LeftMargin, TopMargin), new Point(LeftMargin, Height - BottomMargin));

            ///
            /// ticks 
            /// 
            


            ///
            ///cursor
            /// 
            g.DrawLine(new Pen(Color.Red, 1),
                new Point((int)(CursorIndex * barWidth + LeftMargin + barWidth / 2), TopMargin),
                new Point((int)(CursorIndex * barWidth + LeftMargin + barWidth / 2), Height - BottomMargin));

            ///
            ///Y labels
            /// 
            string maxYAxisValue = "";
            if (zoomYScalesIndex % 3 == 0) maxYAxisValue += "1";
            if (zoomYScalesIndex % 3 == 1) maxYAxisValue += "2";
            if (zoomYScalesIndex % 3 == 2) maxYAxisValue += "5";
            maxYAxisValue += "x10";
            
            g.DrawString(maxYAxisValue, new Font("Arial", 8), Brushes.White, LeftMargin - 50, TopMargin + 10);
            string exponent= (zoomYScalesIndex / 3 + 1).ToString();
            g.DrawString(exponent, new Font("Arial", 7), Brushes.White, LeftMargin - 25, TopMargin + 8);

            ///
            ///X labels
            /// 

            ///
            /// infoTexty - kolko tickov je nastavenych, rozsahy atd... 
            /// 
            //niekde dole zobrazit

            ///
            ///horne prekrytie grafu nad zaciatkom y osi
            ///
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, Width, TopMargin / 2);
        }


        private void blank()
        {
            grafx.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            grafx.Render(e.Graphics);
        }



        /// <summary>
        /// set mininum and maximum on x axis
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        public void setBoundsX(double minX, double maxX)
        {

        }
        /// <summary>
        /// set mininum and maximum on x axis
        /// </summary>
        /// <param name="minY"></param>
        /// <param name="maxY"></param>
        public void setBoundsY(double minY, double maxY)
        {

        }
        

        /// <summary>
        /// refresh rate in miliseconds
        /// </summary>
        public int RefreshRate { get; set; }
        public int CurrentCycleNum { get; set; }
        public int pocetCyklov { get; set; }
        public double MinX { get; set; }
        public double MaxX { get; set; }
        public double MinY { get; set; }
        public double MaxY { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }
        public int BottomMargin { get; set; }
        public int TopMargin { get; set; }
        public int LeftMargin { get; set; }
        public int RightMargin { get; set; }
        private int cisloKroku { get; set; }
        public int NumberofBars { get; private set; }
        public int XAxisWidth { get
            {
                return Width - LeftMargin - RightMargin;
            }
       }
        /// <summary>
        /// bar number at which the cursor is.
        /// </summary>
        int CursorIndex { get; set; }
        /// <summary>
        /// number of currently displayed bars
        /// </summary>
        int NumberofDisplayedBars { get; set; }
        public List<double[]> CyclesKroky { get; private set; }
        public double MaxXView { get; private set; }
        public double MinXView { get; private set; }

        private Dictionary<double, int> DataPoints;
        
        public void addDataPoint(double x,double y,int intensity)
        {
            addIntensityPoint(cisloKroku, intensity);
            CyclesKroky[CurrentCycleNum][cisloKroku++] = x;
        }

        private void addIntensityPoint(int i, int Intensity)
        {
            addIntensityPoint(i, Intensity, CurrentCycleNum);
        }

        private void addIntensityPoint(int i, int Intensity, int cycleNum)
        {
            try
            {
                CyclesIntensities[cycleNum][i]= Intensity;
            }
            catch (ArgumentOutOfRangeException e)
            {
                CyclesIntensities.Add(new int[NumberofBars]);
                addIntensityPoint(i, Intensity, cycleNum);
            }
        }

    }
}