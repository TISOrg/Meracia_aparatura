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
    }
}
