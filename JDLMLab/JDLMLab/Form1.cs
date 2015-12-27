using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace JDLMLab
{
    public partial class Form1 : Form
    {
        Settings setmerania;
        About info;
        public Form1()
        {
            InitializeComponent();
            setmerania = new Settings();
            info = new About();
            DbConnectionSettings ss = new DbConnectionSettings();
            ss.database = "aparatura";
            ss.userName = "aparatura";
            ss.password = "JDLMaparatura";
            ss.port = 3306;
            ss.serverName = "kempelen.ii.fmph.uniba.sk";
            //MessageBox.Show(Database.Default.user);
            db= new DbCommunication(ss);
            
            try {
                roky.DataSource = db.roky().Tables[0];
            }
            catch(MySqlException e)
            {   
                MessageBox.Show("Vyskytla sa chyba pri pripojení na databázu. Overte nastavenie pripojenia","Chyba v spojení s databázou",MessageBoxButtons.RetryCancel);
            }
            filter = new Filter();
        }
        DbCommunication db;
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
        Filter filter;
        private void roky_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                filter.Rok = roky[e.ColumnIndex, e.RowIndex].Value.ToString();
                nazvy.DataSource = db.nazvyMerani(filter.Rok).Tables[0];

                nazvy_CellClick(sender, new DataGridViewCellEventArgs(0, 0));
                //dates.DataSource = null;
                //typy.DataSource = null;
            }
        }

        private void nazvy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filter.Nazov = nazvy[e.ColumnIndex, e.RowIndex].Value.ToString();
                dates.DataSource = db.datumyMerani(filter.Rok, filter.Nazov).Tables[0];
                
                typy.DataSource = null;
            }
        }

       
        private void dates_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filter.Datum = dates[e.ColumnIndex, e.RowIndex].Value.ToString();
                typy.DataSource = db.typyMerani(filter.Nazov,filter.Datum+","+filter.Rok).Tables[0];
            }
            
        }
        

        private void typy_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filter.Typ = typy[e.ColumnIndex, e.RowIndex].Value.ToString();
                merania.DataSource = db.merania(filter.Nazov,filter.Datum+","+filter.Rok,filter.Typ).Tables[0];
            }
            Database d = new Database();
            d.user = "jan";
            d.Save();


            
        }

        private void merania_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                meranie.DataSource = db.meranie((int)merania[e.ColumnIndex,e.RowIndex].Value).Tables[0];
            }
        }
    }
}
