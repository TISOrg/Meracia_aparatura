using System;
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
        Dictionary<string, string> jednotky = new Dictionary<string, string>();

        DataTable avgDataTable;
        DataTable sumDataTable;
        DataTable normalDataTable;
        int header_id;
        public ExportWindow(int header_id)
        {
            InitializeComponent();
            this.header_id = header_id;
            DbCommunication db = new DbCommunication();

            normalDataTable=db.meranie(header_id).Tables[0];
            dataMeranie.DataSource = normalDataTable;
            header = db.header(header_id);

            for (int i = 1; i <= (int)header.Tables[0].Rows[0]["cycles"]; i++)
            {
                checkedListBoxCyklyInclude.Items.Add(i);
            }
            refreshIncludeColumns();

            init();
            jednotky = new Dictionary<string, string>();
            jednotky.Add("Intensity", "a.u."); // v db premenovat sig
            jednotky.Add("Electron energy", "eV");  //x v pripade energy scan,
            jednotky.Add("m/z", "amu");// x v pripade mass scan
            jednotky.Add("Temperature", "°C");
            jednotky.Add("Current", "nA");
            jednotky.Add("Chamber pressure", "mbar");
            jednotky.Add("Capillar pressure", "Pa");
            jednotky.Add("cycle_num", "[1]");

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
            DateTime datum = Convert.ToDateTime(date);
            date = datum.ToString("dd.MM");

            string type = header.Tables[0].Rows[0]["type_name"].ToString();
            string ionType = (header.Tables[0].Rows[0]["ion_type"].ToString().Equals("1")) ? "Positive ions" : "Negative ions";
            string constant = "";
            if (type.Equals("Energy Scan")) {
                constant = header.Tables[0].Rows[0]["constant"].ToString() + " amu";
            }
            if (type.Equals("Mass Scan"))
            {
                constant = header.Tables[0].Rows[0]["constant"].ToString() + " eV";
            }

            //nazov exportu: datum(dd.mm.) - typ - constant - iontype

            saveFileDialog1.FileName = date + " - " + type + " - " + (constant.Equals("") ? "" : constant + " - ") + ionType;
            DialogResult res = saveFileDialog1.ShowDialog();
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



        int pocetCyklov;
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
            bool firstColumn = true;
            pocetCyklov = (int)header.Tables[0].Rows[0]["cycles"];
            //prvy riadok - nazvy stlpcov - beru sa priamo z nazvov v datagride
            for (int cyklus = 0; cyklus < pocetCyklov; cyklus++)
            {
                for (int j = 0; j < dataMeranie.Columns.Count; j++)
                {
                    if (dataMeranie.Columns[j].Visible && dataMeranie.Columns[j].HeaderText!="cycle_num")
                    {
                        if (!firstColumn) file.Write("\t");
                        file.Write(dataMeranie.Columns[j].HeaderText);
                        firstColumn = false;
                    }

                }
            }
            file.WriteLine();

            //druhy riadok - jednotky stlpcov - zatial nic... TODO. vyriesit cez slovnik... current -> A, temperature -> °C
            firstColumn = true;
            for (int cyklus = 0; cyklus < pocetCyklov; cyklus++)
            {
                for (int j = 0; j < dataMeranie.Columns.Count; j++)
                {
                    if (dataMeranie.Columns[j].Visible && !dataMeranie.Columns[j].HeaderText.Equals("cycle_num"))
                    {
                        if (!firstColumn) file.Write("\t");
                        file.Write(jednotky[dataMeranie.Columns[j].HeaderText.ToString()]);
                        firstColumn = false;
                    }
                }
            }
            file.WriteLine();

            
            //treti riadok - commenty - pod stlpcom intensity, constant, , resolution,datum
            string comment = "";
            string type = header.Tables[0].Rows[0]["type_name"].ToString();
            if (type.Equals("Energy Scan"))
            {
                comment = header.Tables[0].Rows[0]["constant"] + " amu, ress " +
                                header.Tables[0].Rows[0]["resolution"] + ", " +
                                header.Tables[0].Rows[0]["datetime"];
            }
            if (type.Equals("Mass Scan"))
            {
                comment = header.Tables[0].Rows[0]["constant"] + " eV, ress " +
                                header.Tables[0].Rows[0]["resolution"] + ", " +
                                header.Tables[0].Rows[0]["datetime"];
            }
            if (type.Equals("2D Scan"))
            {
                comment = "ress " +
                                header.Tables[0].Rows[0]["resolution"] + ", " +
                                header.Tables[0].Rows[0]["datetime"];
            }

            firstColumn = true;
            for (int cyklus = 0; cyklus < pocetCyklov; cyklus++)
            {
                for (int j = 0; j < dataMeranie.Columns.Count; j++)
                {
                    if (!firstColumn) file.Write("\t");
                    if ((type.Equals("Energy Scan") || type.Equals("Mass Scan")) && j > 0)
                    {
                        file.Write(comment);
                    }
                    if (type.Equals("2D Scan") && j > 1)
                    {
                        file.Write(comment);
                    }
                    firstColumn = false;
                }
            }
            file.WriteLine();
            string y = (type.Equals("Mass Scan") || type.Equals("2D Scan")) ? "m/z" : "Electron_energy";
            string x = (type.Equals("Mass Scan") || type.Equals("2D Scan")) ?  "Electron_energy" : "m/z";
            //data
            //dataMeranie.Sort(dataMeranie.Columns[x], ListSortDirection.Ascending); //zoradit datameranie podla X.
            //dataMeranie.Sort(dataMeranie.Columns["cycle_num"], ListSortDirection.Ascending); //zoradit datameranie podla cyklov.
            //dataMeranie.Sort(dataMeranie.Columns[y], ListSortDirection.Ascending); //zoradit datameranie podla Y,
            //todo pre 2dscan.   
            firstColumn = true;
            
            for (int i = 0; i < dataMeranie.Rows.Count; i++)
            {
                
                if (dataMeranie.Rows[i].Visible)
                {
                    for (int j = 0; j < dataMeranie.Columns.Count; j++)
                    {
                        if (dataMeranie.Columns[j].Visible && !dataMeranie.Columns[j].HeaderText.Equals("cycle_num"))
                        {
                            if (!firstColumn) file.Write("\t");
                            file.Write(dataMeranie[j, i].Value);
                            firstColumn = false;
                        }
                    }
                    
                }
                if ((i + 1) % pocetCyklov == 0)
                {
                    file.WriteLine();
                    firstColumn = true;
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
        private void refreshIncludeColumns()
        {
            checkedListBoxInclude.Items.Clear();
            foreach(DataGridViewColumn columnHeader in dataMeranie.Columns)
            {
                checkedListBoxInclude.Items.Add(columnHeader.HeaderText);
                checkedListBoxInclude.SetItemChecked(checkedListBoxInclude.Items.Count - 1, true);
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
                dataMeranie.DataSource = normalDataTable;
                refreshIncludeColumns();
                checkedListBoxCyklyInclude.Enabled = true;
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
                //avg urobit, ak neexistuje DataTable, vytvorit, inak iba prepnut.
                if (avgDataTable == null)
                {
                    DbCommunication db = new DbCommunication();
                    avgDataTable = db.meranieAvg(header_id).Tables[0];
                    
                }
                dataMeranie.DataSource = avgDataTable;
                refreshIncludeColumns();
                checkedListBoxCyklyInclude.Enabled = false;

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
                //sum urobit, ak neexistuje DataTable, vytvorit, inak iba prepnut.
                if (sumDataTable == null)
                {
                    DbCommunication db = new DbCommunication();
                    sumDataTable = db.meranieSum(header_id).Tables[0];
                    
                }
                dataMeranie.DataSource = sumDataTable;
                refreshIncludeColumns();
                checkedListBoxCyklyInclude.Enabled = false;
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataMeranie.Sort(dataMeranie.Columns[0], ListSortDirection.Ascending); //zoradit datameranie podla X.
            dataMeranie.Sort(dataMeranie.Columns["cycle_num"], ListSortDirection.Descending); //zoradit datameranie podla X.
            dataMeranie.Sort(dataMeranie.Columns["Intensity"], ListSortDirection.Ascending); //zoradit datameranie podla X.
        }
    }
}
