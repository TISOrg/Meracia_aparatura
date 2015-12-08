using System;
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
        public Form1()
        {
            InitializeComponent();
            setmerania = new Settings();
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
    }
}
