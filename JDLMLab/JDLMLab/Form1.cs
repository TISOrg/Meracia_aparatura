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
        Settings setmerania;
        AboutBox1 info;
        public Form1()
        {
            InitializeComponent();
            setmerania = new Settings();
            info = new AboutBox1();
            
            //nacitat vsetky nastavenia
            


        }

        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("hello world! IDE TOOOO");
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

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Load().Show();
        }

        private void sidebarExportButton_Click(object sender, EventArgs e)
        {
            
            DbCommunication db = new DbCommunication();
            ExportWindow exp = new ExportWindow(1);
            //exp.grid= meranie aktualne
        }
    }
}
