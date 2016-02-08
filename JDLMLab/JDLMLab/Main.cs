﻿using System;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Generic;


namespace JDLMLab
{
    public partial class Main : Form
    {
        MeasurementControl measurementControl;

        BufferedChart bufferedChart;
        public Main()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SuspendLayout();
            bufferedChart = new BufferedChart();
            bufferedChart.Dock = DockStyle.Fill;
            kontainerPreGraf.Controls.Add(bufferedChart);
            ResumeLayout();
            fillRandomDataPoints();
            timer1_Tick(this, EventArgs.Empty);
            timer1.Interval = (60 - DateTime.Now.Second) * 1000;
            timer1.Enabled = true;
            setTimer = true;
        }
        bool setTimer;

        public void setCurrentCycle(string value) {

            currentCycle.Text = value;
        }

        public void setCurrentStep(string value) {
            currentEnergyStep.Text = value;
        }

        private void fillRandomDataPoints()
        {
            Random r = new Random();
            bufferedChart.setParameters(0, 0, 11);
            MinimumSize=new System.Drawing.Size(sidebar.Width+bufferedChart.LeftMargin+bufferedChart.RightMargin+100,bufferedChart.BottomMargin+bufferedChart.TopMargin+100);
            for (double i = 0; i < 100; i++)
            {
            
                bufferedChart.addDataPoint(i, i, (ulong)(r.Next(100, 10000)));
            }
        }

        
        internal MeasurementControl MeasurementControl
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void nastaveniaMeraniaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            NoveMeranieWindow noveMeranieWindow = new NoveMeranieWindow();
            DialogResult res = noveMeranieWindow.ShowDialog();
            if (res == DialogResult.OK) 
            {
                nastaveniaMeraniaToolStripMenuItem.Enabled = false;
                //hodnota setMerania.parametreMerania obsahuje instanciu triedy measurementsparameters
                //ktora obsahuje vsetky informacie na zacatie merania.
                measurementControl = new MeasurementControl(noveMeranieWindow.parametreMerania, this);
                measurementControl.Graf = bufferedChart;
                estTimeLabel.Text = DateTime.Now.AddSeconds(noveMeranieWindow.parametreMerania.StepTime * noveMeranieWindow.parametreMerania.NumberOfCycles * noveMeranieWindow.parametreMerania.NumberOfSteps).ToString("hh:mm tt");
                energyScanStepTimeLabel.Text = noveMeranieWindow.parametreMerania.EnergyScan.StepTime.ToString();
                resolutionLabel.Text = noveMeranieWindow.parametreMerania.Resolution.ToString();
                measurementControl.start();
                
                MinimumSize = new System.Drawing.Size(noveMeranieWindow.parametreMerania.NumberOfSteps + bufferedChart.LeftMargin + bufferedChart.RightMargin + sidebar.Width, 0);

                //bufferedChart.setParameters(setmerania.parametreMerania.StartPoint,
                //    setmerania.parametreMerania.EndPoint,
                //    setmerania.parametreMerania.PocetBodov,
                //    setmerania.parametreMerania.PocetCyklov);
                //bufferedChart.init();

            }
        }

        internal void meranieSkoncilo()
        {
            nastaveniaMeraniaToolStripMenuItem.Enabled = true;
        }

        private void oProgrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox1().ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
                //zobrazit do grafu vybrate meranie
                
                
            }
            l.Dispose();
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            foreach (SerialPortDriver driver in drivers)
            {
                driver.stopReading();
                driver.close();
            }
            timer1.Enabled = false;
        }
        public bool stopAfterCycleChecked { get { return stopAfterCycle.Checked; } }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

 

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (drivers != null)
            {

                foreach (SerialPortDriver driver in drivers)
                {
                    if (driver.isOpen())
                    {
                        driver.close();
                    }

                }
            }
           
        }
        
    
        private void sidebarExportButton_Click_2(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            //e.Control && 
            if (e.KeyCode.ToString() == "N")
            {
                nastaveniaMeraniaToolStripMenuItem_Click(sender, e);

            }
            if (e.KeyCode.ToString() == "L")
            {
                loadToolStripMenuItem_Click(sender,e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult res = MessageBox.Show(
                    "Do you really want to quit the program?", 
                    "Quit?", 
                    MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }
            }
            bufferedChart.klikKlavesy(sender, e );

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
                    bufferedChart.obnov();
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
                    bufferedChart.obnov();
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
    }
}
