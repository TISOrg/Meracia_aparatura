﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
            init();
        }
        
        public DialogResult Result { get; set; }

        public void init()
        {
            db = new DbCommunication();
            
            try
            {
                dataRoky.DataSource = db.roky().Tables[0];
            }
            catch (MySqlException)
            {
                MessageBox.Show("AN error noccured during connection to database. validate parameters of connection", "Error with  connection to Daatabase", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            
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
                DataRow dr = db.header((int)dataMerania[e.ColumnIndex, e.RowIndex].Value).Tables[0].Rows[0];
                name.Text = dr["name"].ToString();
                date.Text = dr["datetime"].ToString();
                cycles.Text = dr["cycles"].ToString();
                noteValue.Text = dr["note"].ToString();
                resolution.Text = dr["resolution"].ToString();
                typ.Text = dr["type_name"].ToString();
                ionTypeValue.Text = (dr["ion_type"].ToString().Equals("0")) ? "Negative ions" : "Positive ions";
                energy_start_point.Text = "";
                energy_end_point.Text = "";
                mass_density.Text = "";
                energy_steptime.Text = "";
                mass_start_point.Text = "";
                mass_end_point.Text = "";
                constantValue.Text = "";
                pocet_krokov.Text = "";
                mass_timepamu.Text = "";

                if (dr["type_name"].Equals("Energy Scan"))
                {
                    energy_start_point.Text = dr["start_point"].ToString();
                    energy_end_point.Text = dr["end_point"].ToString();
                    constantValue.Text = dr["constant"].ToString();
                    constantLabel.Text = "m/z";
                    
                    energy_steptime.Text = dr["steptime"].ToString();  ///double,time_for_amu  vytvoriť field do Load tak ako ostatnym ///int,pre density//
                    pocet_krokov.Text = dr["pocet_krokov"].ToString();

                }
                if (dr["type_name"].Equals("Mass Scan"))
                {
                    mass_start_point.Text = dr["start_point"].ToString();
                    mass_end_point.Text = dr["end_point"].ToString();
                    constantValue.Text = dr["constant"].ToString();
                    constantLabel.Text = "Electron_energy";
                    mass_timepamu.Text = dr["time_for_amu"].ToString();
                    mass_density.Text = dr["density"].ToString();
                    
                }
                if (dr["type_name"].Equals("2D Scan"))
                {
                    energy_start_point.Text = dr["e_start_point"].ToString();
                    energy_end_point.Text = dr["e_end_point"].ToString();
                    energy_steptime.Text = dr["e_steptime"].ToString();
                    constantValue.Text = "";
                    constantLabel.Text = "";
                    pocet_krokov.Text = dr["pocet_krokov"].ToString();
                    mass_start_point.Text = dr["m_start_point"].ToString();
                    mass_end_point.Text = dr["m_end_point"].ToString();
                    
                    mass_timepamu.Text = dr["time_for_amu"].ToString();
                    mass_density.Text = dr["density"].ToString();
                }

            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {   if (dataMerania.SelectedCells.Count == 1)
            {
                ExportWindow exp = new ExportWindow((int)dataMerania.SelectedCells[0].Value);
                exp.ShowDialog();
            }

            else
            {
                int[] pom=new int[dataMerania.SelectedCells.Count];
                for (int i = 0; i < dataMerania.SelectedCells.Count; i++)
                {
                    pom[i] = (int)dataMerania.SelectedCells[i].Value;
                }
                
                ExportWindow exp = new ExportWindow(pom);
                exp.ShowDialog();
            }
            
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
            //    Close();
            }
            catch (Exception) //ak este neexistuje meranie, tak vybrata nebude ziadna bunka
            {
                //DialogResult = DialogResult.No;
                MessageBox.Show("any measurement is choosen","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning); 

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

        private void Load_Shown(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Load_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void mass_constant_TextChanged(object sender, EventArgs e)
        {

        }

        private void energy_start_point_TextChanged(object sender, EventArgs e)
        {

        }

        private void constantLabel_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void constantLabel_TextChanged(object sender, EventArgs e)
        {
            if (constantLabel.ToString()== "Electron_energy")
            {
                //constantLabel.TextAlign;
            }
        }

        private void constantValue_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
