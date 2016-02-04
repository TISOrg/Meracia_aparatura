using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace JDLMLab
{
    public class BufferedChart : Panel
    {
        /// <summary>
        /// trieda, ktora uchovava jeden BAR. (aj pre 2D Scan), pre MS a ES len X:Intensity
        /// </summary>
        public class DataPoint
        {
            public double X { get; set; }
            public double Y { get; set; }
            public int Intensity { get; set; }
            public DataPoint(double x,double y,int intensity) {
                X = x;
                Y = y;
                Intensity = intensity;
            }
        }
        public class DataPoints
        {
            public DataPoints(int capacity)
            {
                Points = new List<DataPoint>(capacity);
            }
            public List<DataPoint> Points {
                get; set; }
        }
        public enum DisplayAxisModes
        {
            Lin=0,
            Log=1,
            Auto=2
        }
        public enum DisplayDataModes
        {
            CurrentCycle,
            Sum,
            Avg
        }
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
        public List<List<KeyValuePair<double, int>>> Cyclesss;
        public List<DataPoints> Cycles { get; set; }
        private int startDragX;
        private int endDragX;
       
        /// <summary>
        /// refresh rate in miliseconds
        /// </summary>
        public int RefreshRate { get; set; }
        public int CurrentCycleNum { get; set; }
        public int PocetCyklov { get; set; }
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
        public int XAxisWidth
        {
            get
            {
                return Width - LeftMargin - RightMargin;
            }
        }
        public int yAxisHeight
        {
            get
            {
                return Height - BottomMargin - TopMargin;
            }
        }
        int ScrollDriverWidth{get;set;}
        int ScrollDriverX{get;set;}
        int ScrollBarWidth { get
            {
                return (int)(Width - LeftMargin - RightMargin);
            }
        }
        
        public DisplayAxisModes DisplayAxisMode {
            get; set; }
        public DisplayDataModes DisplayDataMode { get; set; }

        /// <summary>
        /// poradove cislo VIDITELNEHO baru(od nuly), na ktorom je kurzor.
        /// </summary>
        int CursorIndex { get; set; }
        /// <summary>
        /// number of currently displayed bars
        /// </summary>
        int NumberofDisplayedBars { get; set; }
        public List<double[]> CyclesKroky { get; private set; }
        public double MaxXView { get; private set; }
        public double MinXView { get; private set; }
        /// <summary>
        /// index najlavejsie zobrazeneho baru
        /// </summary>
        int firstDisplayedBarIndex { get; set; }
        public int scrollBarHeight { get; set; }
        public int scrollBarY
        {
            get
            {
                return Height - BottomMargin + 5;
            }
        }

        //private Dictionary<double, int> DataPoints;

        public BufferedChart() : base()
        {
            AutoScroll = true;
            AutoScrollMinSize = new Size(100, 100);
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
            scrollBarHeight = 10;
            setParameters(0, 1, 1); //default na zaciatku... prepise sa pri volani metody zvonka
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            // Configure the Form for this example.
            this.Text = "User double buffering";
            this.MouseDown += new MouseEventHandler(this.MouseDownHandler);
            this.MouseDown += klikMysi;
            this.MouseMove += pohybMysi;
            this.MouseUp += uvolnenieMysi;
            //this.PreviewKeyDown += klikKlavesy;
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
            //DrawToBuffer(grafx.Graphics);
        }

        public void klikKlavesy(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
            {
                zoomYIn();
                blank();
                DrawToBuffer(grafx.Graphics);
                Refresh();

            }
            if (e.KeyCode == Keys.PageDown)
            {
                zoomYOut();
                blank();
                DrawToBuffer(grafx.Graphics);
                Refresh();
            }
            if (e.KeyCode == Keys.Q)
            {
                zoomXIn();
                ScrollDriverX = firstDisplayedBarIndex*ScrollBarWidth / NumberofBars;
                blank();
                DrawToBuffer(grafx.Graphics);
                Refresh();
            }
            if (e.KeyCode == Keys.W)
            {
                zoomXOut();
               
            }

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

        public void addDataPoint(double x, double y, int intensity)
        {
            Cycles[CurrentCycleNum].Points.Add(new DataPoint(x, y, intensity));
            obnov();
        }

        private void addIntensityPoint(int i, int Intensity)
        {
            addIntensityPoint(i, Intensity, CurrentCycleNum);
        }

        private void addIntensityPoint(int i, int Intensity, int cycleNum)
        {
            try
            {
                CyclesIntensities[cycleNum][i] = Intensity;
            }
            catch (ArgumentOutOfRangeException e)
            {
                CyclesIntensities.Add(new int[NumberofBars]);
                addIntensityPoint(i, Intensity, cycleNum);
            }
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
        bool scrollBarDragging;

        private void klikMysi(object sender, MouseEventArgs e)
        {
            startDragX = e.X;
            endDragX = e.X;
            if (e.Y > TopMargin && e.Y < Height - BottomMargin && e.X > LeftMargin && e.X < Width - RightMargin)
            {
                dragging = true;
                int xGraf = e.X - LeftMargin;
                CursorIndex = NumberofDisplayedBars * xGraf / XAxisWidth;
                blank();
                DrawToBuffer(grafx.Graphics);
                Refresh();
            }

            //if (e.Y > scrollBarY && e.Y < scrollBarY+scrollBarHeight && e.X > LeftMargin && e.X < Width - RightMargin)
            //{
            //    //sme v scrollbare
            //    ScrollDriverX = e.X - ScrollDriverWidth / 2;
            //    if (ScrollDriverX < 0) ScrollDriverX = 0;
            //    else if (ScrollDriverX + ScrollDriverWidth > Width - RightMargin)
            //          ScrollDriverX = Width - RightMargin - ScrollBarWidth;

            //    blank();
            //    DrawToBuffer(grafx.Graphics);
            //    Refresh();
            //}
        }


        /// <summary>
        /// nastavi minimalne a maximalne x, pocetbodov, a pripadne pocet cyklov
        /// </summary>
        /// <param name="minX"></param>
        /// <param name="maxX"></param>
        /// <param name="pocetBodov"> je pocet barov</param>
        /// <param name="cyklov"></param>
        public void setParameters(double minX,double maxX,int pocetBodov,int cyklov=1)
        {
            NumberofBars = pocetBodov;
            PocetCyklov = cyklov;
            MinXView = minX;
            MaxXView = maxX;
            
            init();
        }
        
        /// <summary>
        /// nastavit vsetky potrebne hodnoty pre dane meranie
        /// </summary>
        public void init()
        {
            dragging = false;
            CurrentCycleNum = 0;
            zoomYScalesIndex = 15;
            NumberofDisplayedBars = NumberofBars;   //nastavi zoom na 100%
            firstDisplayedBarIndex = 0;
            //nastavit datapointy na potrebne velkosti a hodnoty
            Cycles = new List<DataPoints>(PocetCyklov);
            for (int i=0;i<PocetCyklov;i++)
            {
                Cycles.Add(new DataPoints(NumberofBars));
            }
            ScrollDriverX = 0;
            ScrollDriverWidth = 100;
            //Random r = new Random();            
        }

        internal void zoomXOut()
        {

        }


        internal void zoomXIn()
        {
            if (NumberofDisplayedBars > 8) //zrusit true
            {
                int start = CursorIndex - (NumberofDisplayedBars / 4);
                int fieldStart = start + firstDisplayedBarIndex;
                if (fieldStart < 0)
                {
                    fieldStart = 0;
                }
                int lastPoint = fieldStart + (NumberofDisplayedBars / 2) ;
                if (lastPoint > NumberofBars)
                {
                    fieldStart += NumberofBars - lastPoint;
                }
                CursorIndex += firstDisplayedBarIndex - fieldStart;
                firstDisplayedBarIndex = fieldStart;
                NumberofDisplayedBars = (NumberofDisplayedBars / 2);

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
            
        }
        internal void zoomYOut()
        {
            if (zoomYScalesIndex == zoomYScales.Length - 1) return;
            zoomYScalesIndex++;

            blank();
            DrawToBuffer(grafx.Graphics);
            Refresh();



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
            g.DrawString(firstDisplayedBarIndex.ToString(), new Font("Arial", 8), Brushes.White, 100, 30);

            ///
            ///...
            /// 


            ///
            /// scrollbar
            /// 
            ScrollDriverWidth = (int)((double)(NumberofDisplayedBars*(double)(XAxisWidth) / (double)NumberofBars));
            int scrollbarX = (int)(LeftMargin + 0.01 * XAxisWidth);
            
            g.FillRectangle(new SolidBrush(Color.BlueViolet), new Rectangle(
                LeftMargin, 
                scrollBarY, 
                (int)(XAxisWidth), 
                scrollBarHeight));
            //scrollDriver
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(
                LeftMargin+ScrollDriverX, 
                Height - BottomMargin + 7, 
                ScrollDriverWidth, 
                6));

            ///
            ///bars
            /// 
            List<DataPoint> dataPoints=Cycles[CurrentCycleNum].Points;
            //kreslime bary len ked je aspon jeden
            double barWidth;
            if (dataPoints.Count > 0)
            {
                barWidth = (double)(XAxisWidth) / (double)(NumberofDisplayedBars);
                for (int c=0, i = firstDisplayedBarIndex;i<firstDisplayedBarIndex+NumberofDisplayedBars; i++,c++)
                {
                    long barHeight;
                    try {
                        barHeight = (long)((yAxisHeight) * dataPoints[i].Intensity) / zoomYScales[zoomYScalesIndex];
                    }
                    catch(ArgumentOutOfRangeException e)
                    {
                        //ak dalsie datapointy este nie su
                        barHeight = 0;
                    }
                    int barHeightInt = (int)barHeight;
                    g.DrawLine(new Pen(Color.Aqua,
                        (int)Math.Round(barWidth)),
                        new Point(
                            LeftMargin + (int)Math.Round(c * barWidth) + (int)Math.Round(barWidth / 2),
                              Height - BottomMargin),
                        new Point(
                            LeftMargin + (int)Math.Round(c * barWidth) + (int)Math.Round(barWidth / 2),
                            Height - BottomMargin - barHeightInt));
                }

                ///
                ///cursor
                /// 
                g.DrawLine(new Pen(Color.Red, 1),
                    new Point((int)(CursorIndex * barWidth + LeftMargin + barWidth / 2), TopMargin),
                    new Point((int)(CursorIndex * barWidth + LeftMargin + barWidth / 2), Height - BottomMargin));
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
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, Width+1000, TopMargin / 2);
        }


        private void blank()
        {
            grafx.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            grafx.Render(e.Graphics);
        }



        
    }
}