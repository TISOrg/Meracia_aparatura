﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JDLMLab
{
    public partial class ExportWindow : Form
    {
        public ExportWindow(int header_id)
        {
            InitializeComponent();

            DbCommunication db = new DbCommunication();

            dataMeranie.DataSource = db.meranie(header_id).Tables[0];
            header = db.header(header_id);

            for (int i = 1; i <= (int)header.Tables[0].Rows[0]["cycles"]; i++)
            {
                checkedListBoxCyklyInclude.Items.Add(i);
            }
            
            init();
            jednotky.Add("Intensity", "a.u."); // v db premenovat sig
            jednotky.Add("Electron_energy", "eV");  //x v pripade energy scan,
            jednotky.Add("Mass", "amu");// x v pripade mass scan
            jednotky.Add("Temperature", "°C");
            jednotky.Add("Current", "nA");
            jednotky.Add("Chamber_pressure", "mbar");
            jednotky.Add("Capillar_pressure", "Pa");
            
        }
        private DataSet header;
        private void init()
        {
            checkBoxIncludeAll.CheckState = CheckState.Checked;
            checkBoxCyklyInclude.CheckState = CheckState.Checked;
            saveFileDialog1.AddExtension = true;
        }

        public DataGridView grid { get; set; }

        private void export()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //funkcia export.. exportovat vybrane zaznamy
            //...
            saveFileDialog1.InitialDirectory = Paths.Default.export_path;
            string date = header.Tables[0].Rows[0]["datetime"].ToString();
            date=date.Replace(":", "-");
            date = date.Replace("/", "-");

            string type = header.Tables[0].Rows[0]["type_name"].ToString();
            string ionType = header.Tables[0].Rows[0]["ion_type"].ToString();
            //nazov exportu: nazov - datum - typ - iontype

            saveFileDialog1.FileName = header.Tables[0].Rows[0]["name"] + " - " + date ;
            DialogResult res=saveFileDialog1.ShowDialog();
            switch (res)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    save(saveFileDialog1.FileName);
                    break;
                default:
                    break;
            }
            
        }


        static Dictionary<string, string> jednotky = new Dictionary<string, string>();
        
        /// <summary>
        /// metoda na export dat zobrazenych v datagride do formatu .dat
        /// format dat:
        /// -prvy riadok: nazov 
        /// -druhy riadok: jednotka
        /// -treti riadok: koment
        /// -ostatne riadky: data
        /// Oddelovac je taublator,ciarka,bodkociarka,space. Pouzivaju sa desatinne bodky
        /// </summary>
        /// <param name="filename"></param>
        private void save(string filename)
        {
            
            StreamWriter file = new StreamWriter(filename, false);

            //prvy riadok - nazvy stlpcov - beru sa priamo z nazvov v datagride
            bool firstColumn = true;
            for (int j = 0; j < dataMeranie.Columns.Count; j++)
            {
                if (dataMeranie.Columns[j].Visible)
                {
                    if (!firstColumn) file.Write("\t");
                    file.Write(dataMeranie.Columns[j].HeaderText);
                    firstColumn = false;
                }

            }
            file.WriteLine();
            for (int j = 0; j < dataMeranie.Columns.Count; j++)
            {
                if (dataMeranie.Columns[j].Visible)
                {
                    if (!firstColumn) file.Write("\t");
                    if(jednotky.ContainsKey(dataMeranie.Columns[j].ToString())) 
                        file.Write(jednotky[dataMeranie.Columns[j].ToString()]);
                    firstColumn = false;
                }

            }
            //druhy riadok - jednotky stlpcov - zatial nic... TODO. vyriesit cez slovnik... current -> A, temperature -> °C
            file.WriteLine();

            //treti riadok - commenty - tiez nic.

            file.WriteLine();

            //data
            firstColumn = true;
            for (int i = 0; i < dataMeranie.Rows.Count; i++)
            {
                if (dataMeranie.Rows[i].Visible)
                {
                    firstColumn = true;
                    for (int j = 0; j < dataMeranie.Columns.Count; j++)
                    {
                        if (dataMeranie.Columns[j].Visible)
                        {
                            if (!firstColumn) file.Write("\t");
                            file.Write(dataMeranie[j, i].Value);
                            firstColumn = false;
                        }
                        
                    }
                    file.WriteLine();
                }
                
            }
            file.Close();


        }

        private void Export_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxInclude.Items.Count; i++)
            {
                checkedListBoxInclude.SetItemChecked(i, checkBoxIncludeAll.Checked);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxCyklyInclude.Items.Count; i++)
            {
                checkedListBoxCyklyInclude.SelectedItem = checkedListBoxCyklyInclude.Items[i];
                checkedListBoxCyklyInclude.SetItemChecked(i, checkBoxCyklyInclude.Checked);
            }

        }

        private void checkedListBoxInclude_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            dataMeranie.Columns[e.Index].Visible = e.NewValue == CheckState.Checked ? true : false;
            if (e.NewValue==CheckState.Checked && checkedListBoxInclude.CheckedIndices.Count == checkedListBoxInclude.Items.Count - 1 ||
                e.NewValue == CheckState.Unchecked && checkedListBoxInclude.CheckedIndices.Count == 1)
            {
                checkBoxIncludeAll.CheckState = e.NewValue;
            }
        }

        private void checkedListBoxCyklyInclude_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < dataMeranie.Rows.Count; i++)
            {
                if ((int)dataMeranie.Rows[i].Cells["cycle_num"].Value == (checkedListBoxCyklyInclude.SelectedIndex + 1))
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataMeranie.DataSource];
                    currencyManager1.SuspendBinding();
                    try {
                        dataMeranie.Rows[i].Visible = e.NewValue == CheckState.Checked ? true : false;
                    }
                    catch(Exception f)
                    {
                        //e.NewValue = CheckState.Unchecked;
                    }
                    currencyManager1.ResumeBinding();
                }
            }   
            if(e.NewValue == CheckState.Checked && checkedListBoxCyklyInclude.CheckedIndices.Count == checkedListBoxCyklyInclude.Items.Count - 1 || e.NewValue == CheckState.Unchecked && checkedListBoxCyklyInclude.CheckedIndices.Count == 1)
            {     
                checkBoxCyklyInclude.CheckState = e.NewValue;
            }
            
            
            
        }

        private void dataMeranie_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioButton3.BackColor = Color.FromArgb(144, 195, 212);
            }
            else {
                radioButton3.BackColor = default(Color);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton2.BackColor = Color.FromArgb(144, 195, 212);
            }
            else
            {
                radioButton2.BackColor = default(Color);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton1.BackColor = Color.FromArgb(144,195,212);
            }
            else
            {
                radioButton1.BackColor = default(Color);
            }
        }

        private void ExportWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
