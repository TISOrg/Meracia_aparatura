using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            NoveMeranieWindow setmerania = new NoveMeranieWindow();
            DialogResult res = setmerania.ShowDialog();
            if (res == DialogResult.OK) 
            {
                //hodnota setMerania.parametreMerania obsahuje instanciu triedy measurementsparameters
                //ktora obsahuje vsetky informacie na zacatie merania.
                measurementControl = new MeasurementControl();
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

        SerialPortDeviceController c;
        private void startbutton_click(object sender, EventArgs e)
        {
            
            
            //AutoResetEvent autoEvent = new AutoResetEvent(false);

            //SerialPortDeviceController statusChecker = new SerialPortDeviceController(new XXXDriver());
            
            //// Create an inferred delegate that invokes methods for the timer.
            //TimerCallback tcb = statusChecker.readAndSave;

            //// Create a timer that signals the delegate to invoke 
            //// CheckStatus after one second, and every 1/4 second 
            //// thereafter.
            //richTextBox1.AppendText("{0} Creating timer.\n"+DateTime.Now.ToString("h:mm:ss.fff"));
            //System.Threading.Timer stateTimer = new System.Threading.Timer(tcb, autoEvent, 1000, 1500);

            //// When autoEvent signals, change the period to every
            //// 1/2 second.
            //autoEvent.WaitOne(5000, false);
            //stateTimer.Change(0, 500);
            //richTextBox1.AppendText("\nChanging period.\n");

            //// When autoEvent signals the second time, dispose of 
            //// the timer.
            //autoEvent.WaitOne(5000, false);
            //stateTimer.Dispose();
            //richTextBox1.AppendText("\nDestroying timer.");

            //for (int i = 0; i < 10; i++)
            //{
            //    try
            //    {  
            //        richTextBox1.AppendText(c.q.Dequeue().ToString() + "\n");
            //    }
            //    catch(InvalidOperationException ex)
            //    {
            //        richTextBox1.AppendText("<prazdny>" + "\n");
            //    }
            //}
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            

        }
    }
}
