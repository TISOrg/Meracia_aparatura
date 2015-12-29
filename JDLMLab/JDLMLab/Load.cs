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
    public partial class Load : Form
    {
        public Load()
        {
            InitializeComponent();
            filter = new Filter();
            DbConnectionSettings dbpar=new DbConnectionSettings();
            dbpar.database = Database.Default.database;
            dbpar.serverName =Database.Default.host;
            dbpar.userName= Database.Default.user;
            dbpar.password= Database.Default.password;
            dbpar.port = Database.Default.port;

            db = new DbCommunication();
            try
            {
                dataRoky.DataSource = db.roky().Tables[0];
            }
            catch (MySqlException e)
            {
                MessageBox.Show("Vyskytla sa chyba pri pripojení na databázu. Overte nastavenie pripojenia", "Chyba v spojení s databázou", MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
            }
            filter = new Filter();
        }
        Filter filter;
        DbCommunication db;
        private void dataRoky_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filter.Rok = dataRoky[e.ColumnIndex, e.RowIndex].Value.ToString();
                dataNazvy.DataSource = db.nazvyMerani(filter.Rok).Tables[0];
                
                dataNazvy_CellEnter(sender, new DataGridViewCellEventArgs(0, 0));
                //dates.DataSource = null;
                //typy.DataSource = null;
            }
        }

        private void dataNazvy_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filter.Nazov = dataNazvy[e.ColumnIndex, e.RowIndex].Value.ToString();
                dataDatumy.DataSource = db.datumyMerani(filter.Rok, filter.Nazov).Tables[0];

                dataDatumy_CellEnter(sender, new DataGridViewCellEventArgs(0, 0));


            }
        }

        private void dataDatumy_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filter.Datum = dataDatumy[e.ColumnIndex, e.RowIndex].Value.ToString();
                dataTypy.DataSource = db.typyMerani(filter.Nazov, filter.Datum + "," + filter.Rok).Tables[0];

                dataTypy_CellEnter(sender, new DataGridViewCellEventArgs(0, 0));
            }
        }

        private void dataTypy_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                filter.Typ = dataTypy[e.ColumnIndex, e.RowIndex].Value.ToString();
                dataMerania.DataSource = db.merania(filter.Nazov, filter.Datum + "," + filter.Rok, filter.Typ).Tables[0];
                dataMerania_CellEnter(sender, new DataGridViewCellEventArgs(0, 0));
            }
        }

        private void dataMerania_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataTable dt = db.header((int)dataMerania[e.ColumnIndex, e.RowIndex].Value).Tables[0];
                nameValue.Text = dt.Rows[0]["name"].ToString();
                startPointValue.Text = dt.Rows[0]["start_point"].ToString();
                endPointValue.Text = dt.Rows[0]["end_point"].ToString();
                constantValue.Text = dt.Rows[0]["constant"].ToString();
                noteValue.Text = dt.Rows[0]["note"].ToString();
                resolutionValue.Text = dt.Rows[0]["resolution"].ToString();
                stepTimeValue.Text = dt.Rows[0]["steptime"].ToString();
                dateValue.Text = dt.Rows[0]["datetime"].ToString();
                cyclesValue.Text = dt.Rows[0]["cycles"].ToString();
                
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateValue_Click(object sender, EventArgs e)
        {

        }

        private void stepTimeValue_Click(object sender, EventArgs e)
        {

        }

        private void resolutionValue_Click(object sender, EventArgs e)
        {

        }

        private void constantValue_Click(object sender, EventArgs e)
        {

        }

        private void endPointValue_Click(object sender, EventArgs e)
        {

        }

        private void startPointValue_Click(object sender, EventArgs e)
        {

        }

        private void nameValue_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExportWindow exp = new ExportWindow((int)dataMerania.SelectedCells[0].Value);
            exp.ShowDialog();


        }
        public int Meranie {
            get { return meranie; }}

        int meranie { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                meranie = (int)dataMerania.SelectedCells[0].Value;
                DialogResult = DialogResult.OK;
                //Close();
            }
            catch (Exception ef) //ak este neexistuje meranie, tak vybrata nebude ziadna bunka
            {
                //DialogResult = DialogResult.No;
                MessageBox.Show("Nie je vybraté žiadne meranie","Chyba",MessageBoxButtons.OK,MessageBoxIcon.Warning); 

            }
            finally
            {
             
            }
        }

        private void dataNazvy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Load_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
