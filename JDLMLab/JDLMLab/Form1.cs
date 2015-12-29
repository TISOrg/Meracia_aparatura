﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDLMLab
{
    public partial class Form1 : Form
    {
        NoveMeranieWindow setmerania;
        AboutBox1 info;
        GrafControl grafcontrol;
        public Form1()
        {
            InitializeComponent();
            setmerania = new NoveMeranieWindow();
            info = new AboutBox1();

            grafcontrol=new GrafControl(graf);
            //nacitat vsetky nastavenia
            for (int i = 1; i < 11; i++)
            {
                grafcontrol.addxy(i, i, "current");
            }
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

        }

        private void nastaveniaMeraniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setmerania.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void oProgrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info.ShowDialog();
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            setmerania.ShowDialog();
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
            DialogResult res=l.ShowDialog();
            if (res == DialogResult.OK)
            {
                //zobrazit do grafu vybrate meranie
                grafcontrol.addMeranie(l.Meranie);
                
            }

            
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
