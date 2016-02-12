using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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
            public ulong Intensity { get; set; }
            public double Temperature { get; set; }
            public double Capillar { get; set; }
            public double Current { get; set; }

            public DataPoint(double x,double y,ulong intensity) {
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
        public uint yAxisHeight
        {
            get
            {
                
                return (uint)(Height - BottomMargin - TopMargin);
            }
        }
        int ScrollDriverWidth{get
            {
                return (int)((double)(NumberofDisplayedBars * (double)(XAxisWidth) / (double)NumberofBars));
            }}
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
                return 5;
            }
        }

        //private Dictionary<double, int> DataPoints;
        public Main mainForm { get; set; }
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
            LeftMargin = 60;
            RightMargin = 30;
            BottomMargin = 30;
            TopMargin = 40;
            scrollBarHeight = 10;
            dragging = false;
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
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(previewKlik);
            // Configure a timer to draw graphics updates.
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 50;
            timer1.Tick += new EventHandler(this.OnTimer);

            bufferingMode = 2;
            count = 0;
            bufferedChartClassReference = this;
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
            // DrawToBuffer(grafx.Graphics);
            timer1.Enabled = true;



            
        }

        void previewKlik(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        public void klikKlavesy(object sender, KeyEventArgs e)
        {

           
            if (e.KeyCode == Keys.W)
            {
                zoomYIn();
                lock (bufferedChartClassReference)
                {
                    //obnov();
                }
                

            }
            if (e.KeyCode == Keys.S)
            {
                zoomYOut();
                lock (bufferedChartClassReference)
                {
                    //obnov();
                }
                
            }
            if (e.KeyCode == Keys.Q)
            {
                zoomXIn();
                ScrollDriverX = LeftMargin+ firstDisplayedBarIndex*ScrollBarWidth / NumberofBars;
                
            }
            if (e.KeyCode == Keys.E)
            {
                zoomXOut();
                ScrollDriverX = LeftMargin + firstDisplayedBarIndex * ScrollBarWidth / NumberofBars;
                
            }
            if (e.KeyCode == Keys.A)
            {

                CursorIndex--;
                if (CursorIndex < 0)
                {
                    CursorIndex = 0;
                    if (firstDisplayedBarIndex > 0) firstDisplayedBarIndex--;
                    ScrollDriverX = LeftMargin + firstDisplayedBarIndex * ScrollBarWidth / NumberofBars;

                }

                
                

            }
            if (e.KeyCode == Keys.D)
            {

                CursorIndex++;
                if (CursorIndex >= NumberofDisplayedBars)
                {
                    CursorIndex = NumberofDisplayedBars - 1;
                    if (firstDisplayedBarIndex + NumberofDisplayedBars < NumberofBars) firstDisplayedBarIndex++;
                    ScrollDriverX = LeftMargin + firstDisplayedBarIndex * ScrollBarWidth / NumberofBars;
                }
                

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

        public void addDataPoint(double x, double y, ulong intensity)
        {
            Cycles[CurrentCycleNum].Points.Add(new DataPoint(x, y, intensity));
            //obnov();
        }
        public void addDataPoint(double x, double y, ulong intensity,int cycle)
        {
            if (cycle > Cycles.Count-1)
            {
               // MessageBox.Show(Cycles.Count.ToString()+" "+CurrentCycleNum.ToString());
                Cycles.Add(new DataPoints(NumberofBars));
            }
            Cycles[cycle].Points.Add(new DataPoint(x, y, intensity));   
            //obnov();
            
        }


        private void MouseDownHandler(object sender, MouseEventArgs e)
        {
            return; //  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //if (e.Button == MouseButtons.Right)
            //{
            //    // Cycle the buffering mode.
            //    if (++bufferingMode > 2)
            //        bufferingMode = 0;

            //    // If the previous buffering mode used 
            //    // the OptimizedDoubleBuffering ControlStyle,
            //    // disable the control style.
            //    if (bufferingMode == 1)
            //        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            //    // If the current buffering mode uses
            //    // the OptimizedDoubleBuffering ControlStyle,
            //    // enabke the control style.
            //    if (bufferingMode == 2)
            //        this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);

            //    // Cause the background to be cleared and redraw.
            //    count = 6;
            //    DrawToBuffer(grafx.Graphics);
            //    this.Refresh();
            //}
            //else
            //{
            //    // Toggle whether the redraw timer is active.
            //    if (timer1.Enabled)
            //        timer1.Stop();
            //    else
            //        timer1.Start();    
            //}
        }



        /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// VYRIESTIT TIMER VS refresh z druheho threadu.



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>












        private void OnTimer(object sender, EventArgs e)
        {
            // Draw randomly positioned ellipses to the buffer.
            //DrawToBuffer(grafx.Graphics);
            obnov();
            mainForm.setCurrentCycle((CurrentCycleNum+1).ToString());
            
            // If in bufferingMode 2, draw to the form's HDC.
            //if (bufferingMode == 2)
                // Render the graphics buffer to the form's HDC.
            //    grafx.Render(Graphics.FromHwnd(this.Handle));
            // If in bufferingMode 0 or 1, draw in the paint method.
            //else
              ;  
            //    this.Refresh();
        }

        private void OnResize(object sender, EventArgs e)
        {
            lock (bufferedChartClassReference)
            {
                if (Width == 0 || Height == 0)
                {
                    timer1.Enabled = false;
                    return;
                }
                else
                {
                    if (!timer1.Enabled) timer1.Enabled = true;
                }
                // Re-create the graphics buffer for a new window size.
                context.MaximumBuffer = new Size(this.Width + 1, this.Height + 1);
                if (grafx != null)
                {
                    grafx.Dispose();
                    grafx = null;
                }
                
                grafx = context.Allocate(this.CreateGraphics(),
                    new Rectangle(0, 0, this.Width, this.Height));


                //TUTO fixnut scrollbar

                //   <--------------------------
                //

                // Cause the background to be cleared and redraw.
                count = 6;
                //obnov();
            }
        }
        private void uvolnenieMysi(object sender, MouseEventArgs e)
        {
            dragging = false;
            scrollBarDragging = false;
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
                lock(bufferedChartClassReference) {
                    //obnov();
                }
            }
            if (scrollBarDragging)
            {
                
                ScrollDriverX = e.X-ScrollDriverWidth/2;
                if (ScrollDriverX < LeftMargin)
                {
                    ScrollDriverX = LeftMargin;
                    return;
                }
                if (ScrollDriverX + ScrollDriverWidth > Width - RightMargin)
                {
                    ScrollDriverX = Width-RightMargin-ScrollDriverWidth;
                    return;
                }

                firstDisplayedBarIndex = (int)((double)((ScrollDriverX - LeftMargin) * NumberofBars) / (double)XAxisWidth);
                lock(bufferedChartClassReference)
                {
                    //obnov();
                }
            }
            
            
        }

        internal void clear()
        {
            foreach(DataPoints dp in Cycles){
                dp.Points.Clear();
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
                lock(bufferedChartClassReference) {
                    //obnov();
                }
            }

            if (e.Y > scrollBarY && e.Y < scrollBarY + scrollBarHeight && e.X > LeftMargin && e.X < Width - RightMargin)
            {
                //sme v scrollbare
                scrollBarDragging= true;
                ScrollDriverX = e.X - ScrollDriverWidth/2;
                if (ScrollDriverX < LeftMargin)
                {
                    ScrollDriverX = LeftMargin;
                }

                if (ScrollDriverX + ScrollDriverWidth > Width - RightMargin)
                {

                    ScrollDriverX = Width - RightMargin- ScrollDriverWidth;
                }

                firstDisplayedBarIndex = (int)((double)((ScrollDriverX - LeftMargin) * NumberofBars) / (double)XAxisWidth);
                lock(bufferedChartClassReference)
                {
                    //obnov();
                }
            }
            
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

            countkrok = 0;
            
        }
        
        /// <summary>
        /// nastavit vsetky potrebne hodnoty pre dane meranie
        /// </summary>
        public void init()
        {
            dragging = false;
            DisplayDataMode = DisplayDataModes.CurrentCycle;
            CurrentCycleNum = 0;
            zoomYScalesIndex = 15;
            NumberofDisplayedBars = NumberofBars;   //nastavi zoom na 100%
            firstDisplayedBarIndex = 0;
            //nastavit datapointy na potrebne velkosti a hodnoty
            Cycles = new List<DataPoints>(PocetCyklov);
            Cycles.Add(new DataPoints(NumberofBars));
            
            ScrollDriverX = LeftMargin;
            
            //Random r = new Random();            
        }

        internal void zoomXOut()
        {
            int fieldStart;
            if (NumberofDisplayedBars * 2 > NumberofBars)
            {
                fieldStart = 0;
                NumberofDisplayedBars = NumberofBars;
            }
            else
            {
                int cursor_real = CursorIndex + firstDisplayedBarIndex;
                fieldStart = cursor_real - NumberofDisplayedBars;
                if (fieldStart < 0)
                {
                    fieldStart = 0;
                }
                int lastPoint = fieldStart + NumberofDisplayedBars * 2;
                if (lastPoint > NumberofBars)
                {
                    fieldStart += NumberofBars - lastPoint;
                }
                NumberofDisplayedBars = NumberofDisplayedBars * 2;
            }
            CursorIndex += firstDisplayedBarIndex - fieldStart;
            firstDisplayedBarIndex = fieldStart;
            lock (bufferedChartClassReference)
            {
                //obnov();
            }
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

                lock(bufferedChartClassReference)
                {
                    //obnov();
                }
            }

        }

        public void obnov()
        {
            lock(bufferedChartClassReference)
            {
                blank();
                DrawToBuffer(grafx.Graphics);
                Refresh();
                
            }
        }

        internal void setCursor(MouseEventArgs e)
        {
            
        }

        private long[] zoomYScales;
        private int zoomYScalesIndex;
        private BufferedChart bufferedChartClassReference;

        internal void zoomYIn()
        {
            if (zoomYScalesIndex == 0) return;
            zoomYScalesIndex--;
            
        }
        internal void zoomYOut()
        {
            if (zoomYScalesIndex == zoomYScales.Length - 1) return;
            zoomYScalesIndex++;
        }


        void RgbValues(float minimumValue, float maximumValue, float value,out int r,out int g,out int b)
        {
            var halfmax = (maximumValue - minimumValue) / 2.0;
             b = (int)Math.Max(0.0, 255.0 * (1 - (value - minimumValue) / halfmax));
             r = (int)Math.Max(0.0, 255.0 * ((value - minimumValue) / halfmax - 1));

             g = 255 - b - r;

        }

        public static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = Convert.ToInt32(value);
            int p = Convert.ToInt32(value * (1 - saturation));
            int q = Convert.ToInt32(value * (1 - f * saturation));
            int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

            if (hi == 0)
                return Color.FromArgb(255, v, t, p);
            else if (hi == 1)
                return Color.FromArgb(255, q, v, p);
            else if (hi == 2)
                return Color.FromArgb(255, p, v, t);
            else if (hi == 3)
                return Color.FromArgb(255, p, q, v);
            else if (hi == 4)
                return Color.FromArgb(255, t, p, v);
            else
                return Color.FromArgb(255, v, p, q);
        }

        ulong sumOverCycles(int index, int cycleMax)
        {
            ulong x = 0;
            for (int i = 0; i < cycleMax; i++)
            {
                try
                {
                    x += Cycles[i].Points[index].Intensity;
                }
                catch (Exception)
                {
                    return sumOverCycles(index, cycleMax - 1);
                }
                
            }
            return x;
        }
        int countkrok;
        ulong avgOverCycles(int index, int cycleMax)
        {
            ulong x = 0;
            for (int i = 0; i < cycleMax; i++)
            {
                try
                {
                    x += Cycles[i].Points[index].Intensity;
                }
                catch (Exception)
                {
                    x += 0;
                }
            }
            return x / (uint)cycleMax;
        }

        /// <summary>
        /// hlavna funckia na kreslenie vsetkeho
        /// </summary>
        /// <param name="g"></param>
        private void DrawToBuffer(Graphics g)
        {
            //double inte = 0; // nula
            //Random r = new Random();
            //int range = 10000;
            //double satur;
            //double inteToFarba;
            //int hodnotaPreMin = 200;
            //for (int i = 0; i < 500; i++)
            //{
            //    for (int j = 0; j < 500; j++)
            //    {
            //        inte = (int)(r.NextDouble() * range + 1000); // inte = napr 1258
            //        if (j == 20) inte = 0;
            //        if (j == 40) inte = range;
            //        satur = 0.5;
            //        inteToFarba = hodnotaPreMin - (inte / (range / hodnotaPreMin));
            //        if (inte > range) { satur = 0; }
            //        g.FillRectangle(new SolidBrush(ColorFromHSV(inteToFarba, satur, 1)), new Rectangle(100 + j * 1, 100 + i * 1, 1, 1));

            //    }
            //}
            //int pocetbodovlegenda2D = hodnotaPreMin;
            //for (int k = 0; k <= pocetbodovlegenda2D; k++)
            //{
            //    inteToFarba = hodnotaPreMin - k;
            //    g.FillRectangle(new SolidBrush(ColorFromHSV(inteToFarba, 0.5, 1)), new Rectangle(20, 50 + k * 3, 10, 3));
            //    if (k == pocetbodovlegenda2D) { g.FillRectangle(new SolidBrush(ColorFromHSV(inteToFarba, 0, 1)), new Rectangle(20, 50 + k * 3, 10, 3)); }
            //}


            // inte =0 - max hodnota
            // pocet intwervalov je 200 * 0.02 = 10000
            //max / 10 000 = element interval, kedz sa zmani farba 
            //max je definovane ako aktual zoom value napr. 10^6
                
       
                
            
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
            //g.DrawString(CursorIndex.ToString(), new Font("Arial", 8), Brushes.White, 10, 34);
            //g.DrawString(firstDisplayedBarIndex.ToString(), new Font("Arial", 8), Brushes.White, 100, 30);

            ///
            ///...
            /// 

            ///
            /// y ticks for mass and energy
            /// 
            for (int i = 0; i <= 9; i++)
            {
                int sirkaCiarky=8;
                int pocetCiarok=XAxisWidth/sirkaCiarky;
                
                for (int j = 0; j <= pocetCiarok; j++)
                {
                    if (j % 2 == 1) continue;
                    g.DrawLine(new Pen(Color.Gray, 1),
                    new Point((int)(
                    LeftMargin + sirkaCiarky*j),
                    TopMargin + (int)(yAxisHeight / 10) * i),
                    new Point((int)(
                    LeftMargin - 10+j*sirkaCiarky),
                    TopMargin + (int)(yAxisHeight / 10) * i));
                }
            }

            double intensityvalueoncursor = 0;
            string pom = "";
            ///
            ///bars
            /// 
            
            //kreslime bary len ked je aspon jeden
            double barWidth;
            if (Cycles[0].Points.Count > 0)
            {
                barWidth = (double)(XAxisWidth) / (double)(NumberofDisplayedBars);
                int pomer = XAxisWidth / 100;
                double pixelRange = 0;
                
                for (int c = 0, i = firstDisplayedBarIndex; i < firstDisplayedBarIndex + NumberofDisplayedBars; i++, c++)
                {
                    ulong barHeight = 0;
                    ulong intensity = 0;
                   
                    if (c == 0 || (c * barWidth - pixelRange) > 100)
                    {
                        g.DrawLine(new Pen(Color.Red, (int)3),
                            LeftMargin + (int)Math.Round(c * barWidth) + (int)Math.Round(barWidth / 2),
                            Height - BottomMargin,
                            LeftMargin + (int)Math.Round(c * barWidth) + (int)Math.Round(barWidth / 2),
                            Height - BottomMargin + 10);

                        pixelRange = (barWidth * c);

                        try
                        {
                            g.DrawString(Cycles[CurrentCycleNum].Points[i].X.ToString(), new Font("Arial", 8), Brushes.White,
                            LeftMargin + (int)Math.Round(c * barWidth) + (int)Math.Round(barWidth / 2) - 3,
                                Height - BottomMargin + 10);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            
                        }
                    }

                       
                    if (DisplayDataMode == DisplayDataModes.CurrentCycle)
                    {
                        try
                        {
                            intensity = Cycles[CurrentCycleNum].Points[i].Intensity;
                                
                        }
                        catch (Exception)
                        {
                            if (CurrentCycleNum > 0)
                            {
                                  
                                intensity = Cycles[CurrentCycleNum - 1].Points[i].Intensity;
                         
                            }
                            else
                            {
                                intensity = 0;
                            }
                                
                        }
                            
                    }
                        
                   
                    if (DisplayDataMode == DisplayDataModes.Sum)
                    {
                        intensity = sumOverCycles(i, Cycles.Count);   

                    }
                    if (DisplayDataMode == DisplayDataModes.Avg)
                    {
                        intensity = avgOverCycles(i, Cycles.Count);  
                    }
                    if(CursorIndex+firstDisplayedBarIndex==i)
                    {
                        intensityvalueoncursor = intensity;
                    }


                    if (DisplayAxisMode == DisplayAxisModes.Log)
                    {
                        double d = 0;
                        if (intensity != 0)
                        {
                            d = Convert.ToUInt32(yAxisHeight / 10) * (1 + Math.Log10((double)intensity));
                        }
                        barHeight = Convert.ToUInt64(d);
                    }
                    if (DisplayAxisMode == DisplayAxisModes.Lin)
                    {
                        barHeight = (ulong)((yAxisHeight) * intensity) / (ulong)(zoomYScales[zoomYScalesIndex]);
                    }
                    if (DisplayAxisMode == DisplayAxisModes.Auto)
                    {

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
            if (startDragX > endDragX)
            {
                lavaCast = endDragX;
                rectWidth = startDragX - endDragX;
            }
            else
            {
                rectWidth = endDragX - startDragX;
            }
            g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.LightBlue)), new Rectangle(lavaCast, TopMargin, rectWidth, Convert.ToInt32(yAxisHeight)));

            ///axis
            /// 
            g.DrawLine(new Pen(Color.Orange, 2), new Point(LeftMargin, Height - BottomMargin), new Point(Width - RightMargin, Height - BottomMargin));
            g.DrawLine(new Pen(Color.Orange, 2), new Point(LeftMargin, TopMargin), new Point(LeftMargin, Height - BottomMargin));


            // MessageBox.Show(XAxisWidth.ToString());


            ///
            ///Y labels
            /// 
            if(DisplayAxisMode== DisplayAxisModes.Lin) {
              string maxYAxisValue = "x10";

              g.DrawString(maxYAxisValue, new Font("Arial", 12), Brushes.White, 10, 15 - 5);
              string exponent = (zoomYScalesIndex / 3 ).ToString();
              g.DrawString(exponent, new Font("Arial", 10), Brushes.White, 40, 15 - 7);

                maxYAxisValue = "";
                if (zoomYScalesIndex % 3 == 0) maxYAxisValue += "1";
                if (zoomYScalesIndex % 3 == 1) maxYAxisValue += "2";
                if (zoomYScalesIndex % 3 == 2) maxYAxisValue += "5";
                string odloz = maxYAxisValue;

            

                //if (zoomYScalesIndex % 3 == 0) maxYAxisValue += "1";
                //if (zoomYScalesIndex % 3 == 1) maxYAxisValue += "2";
                //if (zoomYScalesIndex % 3 == 2) maxYAxisValue += "5";
                //maxYAxisValue += "x10";
                double partialmaxvalue = Convert.ToDouble(odloz) / 10.0;
                for (int i = 0; i <= 9; i++)
                {
                    maxYAxisValue = (partialmaxvalue*(10-i)*10).ToString();
                    g.DrawString(maxYAxisValue, new Font("Arial", 9), Brushes.White, 15, TopMargin + i*(yAxisHeight/10) - 5);

                }
            }
            if (DisplayAxisMode == DisplayAxisModes.Log) 
            {
                string maxYAxisValue = "10";
                for (int i = 0; i <= 9; i++)
                {
                    g.DrawString(maxYAxisValue, new Font("Arial", 12), Brushes.White, 15, TopMargin + i * (yAxisHeight / 10) - 5);
                    string exponent = (zoomYScalesIndex / 3 + 1).ToString();
                    g.DrawString((9-i).ToString(), new Font("Arial", 10), Brushes.White, 35, TopMargin + i * (yAxisHeight / 10) - 10);
                }
            }

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
            g.FillRectangle(new SolidBrush(Color.Black), LeftMargin, 0, Width + 1000, TopMargin * 2 / 3);

            ///
            /// scrollbar
            /// 

            int scrollbarX = (int)(LeftMargin + 0.01 * XAxisWidth);

            g.FillRectangle(new SolidBrush(Color.BlueViolet), new Rectangle(
                LeftMargin,
                scrollBarY,
                (int)(XAxisWidth),
                scrollBarHeight));
            //scrollDriver
            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(
                ScrollDriverX,
                scrollBarY + 2,
                ScrollDriverWidth,
                scrollBarHeight - 4));


            //nastavit info o aktualnej polohe a hodnote.
            try
            {
                
                mainForm.setCursorInfo(CursorIndex + firstDisplayedBarIndex + 1, intensityvalueoncursor);
            }
            catch (Exception)
            {
                mainForm.setCursorInfo(0,0);
            }
        }


        private void blank()
        {
            grafx.Graphics.FillRectangle(Brushes.Black, 0, 0, this.Width, this.Height);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            grafx.Render(e.Graphics);
        }





        internal void prevCycle()
        {
            if (CurrentCycleNum == 0) return;
            CurrentCycleNum--;
        }

        internal void nextCycle()
        {
            if (CurrentCycleNum == Cycles.Count-1) return;
            CurrentCycleNum++;
        }

        internal void prepareNextCycle()
        {
            Cycles.Add(new DataPoints(NumberofBars));
            nextCycle();
        }
    }
}
