using System;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Collections.Generic;

namespace JDLMLab
{
    public partial class Main : Form
    {
        
        AboutBox1 info;
        GrafControl grafcontrol;
        MeasurementControl measurementControl;
        
        public Main()
        {

            
           
            InitializeComponent();
            
            
            
            grafcontrol=new GrafControl(graf);
            //nacitat vsetky nastavenia
            Random r= new Random();
            for (double i = 1; i < 100; i++)
            {
                grafcontrol.addxyToGraf(i, r.NextDouble()*100, 1);    
            }
            //grafcontrol.addMeranie(1);
            //grafcontrol.Cyklus = 2;
            //grafcontrol.repaintGraf();


            //x=new XXXDriver();
            //x.open();
            //x.setTimer(1000);
            //Thread t = new Thread(new ThreadStart(x.startReading));
            // t.Start();
            
            
        }
        XXXDriver x;
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

            NoveMeranieWindow setmerania = new NoveMeranieWindow();
            DialogResult res = setmerania.ShowDialog();
            if (res == DialogResult.OK) 
            {
                //hodnota setMerania.parametreMerania obsahuje instanciu triedy measurementsparameters
                //ktora obsahuje vsetky informacie na zacatie merania.
                measurementControl = new MeasurementControl(setmerania.parametreMerania);

                
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

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

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            
            

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
                grafcontrol.clearGraf();
                grafcontrol.addMeranie(l.Meranie);    
            }
            l.Dispose();
        }

        private void sidebarExportButton_Click(object sender, EventArgs e)
        {
            
            DbCommunication db = new DbCommunication();
            ExportWindow exp = new ExportWindow(1);
            //exp.grid= meranie aktualne
            
        }

        private void graf_KeyDown(object sender, KeyEventArgs e)
        {
            grafcontrol.grafKeyPressed(e);
        }

        event EventHandler ev;
        SerialPortDriver v;
        List<SerialPortDriver> drivers;
        private void startbutton_click(object sender, EventArgs e)
        {
            drivers = new List<SerialPortDriver>();
            SerialPortDriver voltmeter = new VMeterDriver();
            SerialPortDriver ampermeter = new AMeterDriver();
            SerialPortDriver tlakomer = new TlakomerTG256ADriver();
            SerialPortDriver teplomer = new TeplomerDriver();


            voltmeter.setTimer(500);
            ampermeter.setTimer(500);
            tlakomer.setTimer(500);
            teplomer.setTimer(500);

            drivers.Add(ampermeter);
            drivers.Add(tlakomer);
            drivers.Add(teplomer);
            drivers.Add(voltmeter);


            foreach (SerialPortDriver driver in drivers) {
                driver.open();
                driver.startReading();

            }

            timer1.Enabled = true;
            

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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
                try
                {

                foreach (SerialPortDriver dr in drivers)
                {
                    richTextBox1.AppendText(dr.readNext().ToString() + "\t");

                }
                // richTextBox1.AppendText(r.readNext().ToString());
                //  richTextBox1.AppendText("\n");

            }
                catch (Exception f)
                {
                    richTextBox1.AppendText(f.ToString());
                }

        }
         SerialPort serialPort;
        
        
        static string text="";
        private void dataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            text = serialPort.ReadLine();
            //richTextBox1.AppendText("dd");
            richTextBox1.AppendText(text);
        }

        private void Main_Load(object sender, EventArgs e)
        { 
        }
        double i;
        private void button1_Click(object sender, EventArgs e)
        {
            NI.setAnalogOutput(i);
            i++;
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
        VMeterDriver r;
        NIDriver NI;
        private void sidebarExportButton_Click_2(object sender, EventArgs e)
        {
            i = 0;
            NI = new NIDriver();
            NI.setAnalogOutput(5);


            r = new VMeterDriver();
            r.setTimer(1000);
            r.open();
            r.startReading();
            //// Thread.Sleep(100);
            timer1.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "N")
            {
                NoveMeranieWindow setmerania = new NoveMeranieWindow();
                DialogResult res = setmerania.ShowDialog();
                if (res == DialogResult.OK)
                {
                    //hodnota setMerania.parametreMerania obsahuje instanciu triedy measurementsparameters
                    //ktora obsahuje vsetky informacie na zacatie merania.
                    measurementControl = new MeasurementControl(setmerania.parametreMerania);
        

                }
            }
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult res = MessageBox.Show("Do you really want to quit the program?", "Quit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (res == DialogResult.Yes)
                {
                    this.Close();
                    return;
                }
            }
                
            
        }
    }
}
