using System;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Generic;
using System.Data;


namespace JDLMLab
{
    public partial class Main : Form
    {

        BufferedChart bufferedChart;
        public Main()
        {
            
            Control.CheckForIllegalCrossThreadCalls = true;
            InitializeComponent();
            DoubleBuffered = true;
            SuspendLayout();
            bufferedChart = new BufferedChart();
            bufferedChart.mainForm = this;
            bufferedChart.Dock = DockStyle.Fill;
            kontainerPreGraf.Controls.Add(bufferedChart);
            
            ResumeLayout();
            //fillRandomDataPoints();
            timer1_Tick(this, EventArgs.Empty);
            timer1.Interval = (60 - DateTime.Now.Second) * 1000;
            timer1.Enabled = true;
            setTimer = true;



            MeasurementControl = new MeasurementControl();
            MeasurementControl.Graf = bufferedChart;
            
            MeasurementControl.setMainForm(this);
        }
        bool setTimer;

       
        public void setCurrentCycle(string value)
        {
            if (currentCycle.InvokeRequired)
            {
                currentCycle.Invoke(new MethodInvoker(delegate { currentCycle.Text = value; }));
            }
            else
            {
                currentCycle.Text = value;
                
            }
            
        }

        public void setCurrentStep(string value) {
            if (currentEnergyStep.InvokeRequired)
            {
                currentEnergyStep.Invoke(new MethodInvoker(delegate { currentEnergyStep.Text = value; ; }));
            }
        }

        private void fillRandomDataPoints()
        {
            Random r = new Random();
            bufferedChart.setParameters(0, 0, 300);
            MinimumSize=new System.Drawing.Size(sidebar.Width+bufferedChart.LeftMargin+bufferedChart.RightMargin+100,bufferedChart.BottomMargin+bufferedChart.TopMargin+100);
            for (double i = 0; i < 300; i++)
            {
            
                bufferedChart.addDataPoint(i, i, (ulong)(r.Next(100, 10000)));
            }
        }


        internal MeasurementControl MeasurementControl
        {
            get;
            set;
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void nastaveniaMeraniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            NoveMeranieWindow noveMeranieWindow = new NoveMeranieWindow();
            DialogResult res = noveMeranieWindow.ShowDialog();
            if (res == DialogResult.OK) 
            {
                sidebar.Enabled = true;
                stopButton.Enabled = true;
                stopAfterCycle.Enabled = true;
                nastaveniaMeraniaToolStripMenuItem.Enabled = false;
                //hodnota setMerania.parametreMerania obsahuje instanciu triedy measurementsparameters
                //ktora obsahuje vsetky informacie na zacatie merania.
                MeasurementControl = new MeasurementControl(noveMeranieWindow.parametreMerania, this);
                MeasurementControl.Graf = bufferedChart;
                estTimeLabel.Text = DateTime.Now.AddSeconds(noveMeranieWindow.parametreMerania.StepTime * noveMeranieWindow.parametreMerania.NumberOfCycles * noveMeranieWindow.parametreMerania.NumberOfSteps).ToString("hh:mm tt");
                //energyScanStepTimeLabel.Text = noveMeranieWindow.parametreMerania.EnergyScan.StepTime.ToString();
                resolutionLabel.Text = noveMeranieWindow.parametreMerania.Resolution.ToString();


                MeasurementControl.start();
                
                

                //bufferedChart.setParameters(setmerania.parametreMerania.StartPoint,
                //    setmerania.parametreMerania.EndPoint,
                //    setmerania.parametreMerania.PocetBodov,
                //    setmerania.parametreMerania.PocetCyklov);
                //bufferedChart.init();

            }*/
        }

        internal void meranieSkoncilo()
        {
            if (menuStrip1.InvokeRequired)
            {
                menuStrip1.Invoke(new MethodInvoker(delegate { menuToolStripMenuItem.Enabled = true; }));   
            }
            if (stopAfterCycle.InvokeRequired)
            {
                stopAfterCycle.Invoke(new MethodInvoker(delegate { stopAfterCycle.Enabled = false; }));   
            }
            if (stopButton.InvokeRequired)
            {
                stopButton.Invoke(new MethodInvoker(delegate { stopButton.Enabled = false; }));
            }
        }

        private void oProgrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoveMeranieWindow noveMeranieWindow = new NoveMeranieWindow();
            DialogResult res = noveMeranieWindow.ShowDialog();
            if (res == DialogResult.OK)
            {
                sidebar.Enabled = true;
                stopButton.Enabled = true;
                stopAfterCycle.Enabled = true;
                menuToolStripMenuItem.Enabled = false;
                //hodnota setMerania.parametreMerania obsahuje instanciu triedy measurementsparameters
                //ktora obsahuje vsetky informacie na zacatie merania.
                MeasurementControl = new MeasurementControl(noveMeranieWindow.parametreMerania, this);
                MeasurementControl.Graf = bufferedChart;
                estTimeLabel.Text = DateTime.Now.AddSeconds(noveMeranieWindow.parametreMerania.StepTime * noveMeranieWindow.parametreMerania.NumberOfCycles * noveMeranieWindow.parametreMerania.NumberOfSteps).ToString("hh:mm tt");
                //energyScanStepTimeLabel.Text = noveMeranieWindow.parametreMerania.EnergyScan.StepTime.ToString();
                resolutionLabel.Text = noveMeranieWindow.parametreMerania.Resolution.ToString();
                MeasurementControl.start();

                //bufferedChart.setParameters(setmerania.parametreMerania.StartPoint,
                //    setmerania.parametreMerania.EndPoint,
                //    setmerania.parametreMerania.PocetBodov,
                //    setmerania.parametreMerania.PocetCyklov);
                //bufferedChart.init();

            }
        }

        private void startMeranie_click(object sender, EventArgs e)
        {
            //zrejme bude sluzit na spustenie a prerusenie aktualneho merania
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NastaveniaWindow().ShowDialog();
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Load l = new Load();
            DialogResult res = l.ShowDialog(this);
            if (res==DialogResult.OK)
            {
                if (l.Meranie.Parameters.Typ.Equals("2DScan"))
                {
                    //bufferedChart.setParameters(l);
                }
                else
                {
                    MeasurementControl.OldMeasurement = l.Meranie;
                    MeasurementControl.showOldMeasurement();
                    sidebar.Enabled = true;
                }
                if (!MeasurementControl.isMeasuring)
                {
                    stopButton.Enabled = false;
                    stopAfterCycle.Enabled = false;
                }
                

            }
            
        }

        private void sidebarExportButton_Click(object sender, EventArgs e)
        {
            
            DbCommunication db = new DbCommunication();
            ExportWindow exp = new ExportWindow(1);
            //exp.grid= meranie aktualne
            
        }

        

        event EventHandler ev;
        
        List<SerialPortDriver> drivers;
        private void startbutton_click(object sender, EventArgs e)
        {
            //drivers = new List<SerialPortDriver>();
            //SerialPortDriver voltmeter = new VMeterDriver();
            //SerialPortDriver ampermeter = new AMeterDriver();
            //SerialPortDriver tlakomer = new TlakomerTG256ADriver();
            //SerialPortDriver teplomer = new TeplomerDriver();


            //voltmeter.setTimer(500);
            //ampermeter.setTimer(500);
            //tlakomer.setTimer(500);
            //teplomer.setTimer(500);

            //drivers.Add(ampermeter);
            //drivers.Add(tlakomer);
            //drivers.Add(teplomer);
            //drivers.Add(voltmeter);

            //foreach (SerialPortDriver driver in drivers) {
            //    driver.open();
            //    driver.startReading();
            //}
            //timer1.Enabled = true;
        }

        private void stopClick(object sender, EventArgs e)
        {
            MeasurementControl.abort();
        }
        public bool stopAfterCycleChecked { get { return stopAfterCycle.Checked; } }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

 

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {   
           
        }
        
    
        private void sidebarExportButton_Click_2(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
        
            if (e.KeyCode.ToString() == "N")
            {
                menuToolStripMenuItem_Click(sender, e);

            }
            if (e.KeyCode.ToString() == "L")
            {
                loadToolStripMenuItem_Click(sender,e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            bufferedChart.klikKlavesy(sender, e );

        }

        private void userCloseApp()
        {
            
        }

       
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void stopAfterCycle_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void graf_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }
        private void Main_Resize(object sender, EventArgs e)
        {
            
            kontainerPreGraf.Width = Width - sidebar.Width - 20;
        }

        
        private void displayModeLin_CheckedChanged(object sender, EventArgs e)
        {
            if (displayModeLin.Checked)
            {
                lock (bufferedChart)
                {
                   
                    bufferedChart.DisplayAxisMode = BufferedChart.DisplayAxisModes.Lin;
                    //bufferedChart.obnov();
                }
               
            }
            
        }

        private void displayModeLog_CheckedChanged(object sender, EventArgs e)
        {
            if (displayModeLog.Checked)
            {
                lock (bufferedChart)
                {

                    bufferedChart.DisplayAxisMode = BufferedChart.DisplayAxisModes.Log;
                    //bufferedChart.obnov();
                }
            }
        }
        private void displayModeAuto_CheckedChanged(object sender, EventArgs e)
        {
            //if (displayModeAuto.Checked)
            {
                bufferedChart.DisplayAxisMode = BufferedChart.DisplayAxisModes.Auto;
            }
        }

        private void dataDisplayAvg_CheckedChanged(object sender, EventArgs e)
        {
           
            bufferedChart.DisplayDataMode = BufferedChart.DisplayDataModes.Avg;
        }

        private void dataDisplaySum_CheckedChanged(object sender, EventArgs e)
        {
            bufferedChart.DisplayDataMode = BufferedChart.DisplayDataModes.Avg;
        }

        private void dataDisplayAvg_Click(object sender, EventArgs e)
        {
            bufferedChart.DisplayDataMode = BufferedChart.DisplayDataModes.Avg;
        }

        private void dataDisplaySum_Click(object sender, EventArgs e)
        {
            bufferedChart.DisplayDataMode = BufferedChart.DisplayDataModes.Sum;
        }

        private void dataDisplayCurrent_Click(object sender, EventArgs e)
        {
            
            bufferedChart.DisplayDataMode = BufferedChart.DisplayDataModes.CurrentCycle;
        }

        private void kontainerPreGraf_Paint(object sender, PaintEventArgs e)
        {

        }

        private void currentCycle_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (setTimer)
            {
                timer1.Interval = 60000;
                setTimer = false;
            }
            DateValueLabel.Text = DateTime.Now.ToString("dd.MM.yyyy");
            TimeValueLabel.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void Main_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show(
                    "Do you really want to quit the program?",
                    "Quit?",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

            if (res == DialogResult.Yes)
            {
                return;
            }
            else
            {
                e.Cancel = true;
            }
            
        }

        private void userCloseApp(FormClosingEventArgs e)
        {
            

        }
        

        
        private void switchCurrentLoad_Click(object sender, EventArgs e)
        {
            if (!MeasurementControl.showCurrent)
            {
                showCurrentLoadButton.Text = "Loaded measurement";
                MeasurementControl.showCurrentMeasurement();
                
            }
            else
            {
                showCurrentLoadButton.Text = "Current measurement";
                MeasurementControl.showOldMeasurement();
            }
            
        }

        public int sidebarWidth { get { return sidebar.Width; } }

        private void dataDisplaySum_CheckedChanged_1(object sender, EventArgs e)
        {
            if(dataDisplaySum.Checked){
                bufferedChart.DisplayDataMode = BufferedChart.DisplayDataModes.Sum;
            }

        }

        private void dataDisplayAvg_CheckedChanged_1(object sender, EventArgs e)
        {
            if (dataDisplayAvg.Checked)
            {
                bufferedChart.DisplayDataMode = BufferedChart.DisplayDataModes.Avg;
            }
        }

        private void dataDisplayCurrent_CheckedChanged(object sender, EventArgs e)
        {
            if (dataDisplayCurrent.Checked)
            {
                bufferedChart.DisplayDataMode = BufferedChart.DisplayDataModes.CurrentCycle;
                buttonprevious.Enabled = true;
                buttonnext.Enabled = true;
            }
            else
            {
                buttonprevious.Enabled = false;
                buttonnext.Enabled = false;
            }
        }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }
        
        private void kontainerKeyPreview(object sender, PreviewKeyDownEventArgs e)
        {
            
            //e.IsInputKey = true;
            
            
            //bufferedChart.klikKlavesy(this, e);
        }

        private void kontainerPreGraf_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            

        }

        private void sidebarExportButton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void sidebarExportButton_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void sidebar_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        internal void setCursorInfo(int p,double intensity)
        {
            cursorPositionValue.Text = p.ToString();
            intensityValue.Text = intensity.ToString();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void buttonprevious_Click(object sender, EventArgs e)
        {
            bufferedChart.prevCycle();
        }

        private void buttonnext_Click(object sender, EventArgs e)
        {
            bufferedChart.nextCycle();
        }

        private void currentCycle_TextChanged_1(object sender, EventArgs e)
        {

        }

        
    }
}
