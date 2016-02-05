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
        int[] headers;
        bool multi = true;
        public ExportWindow(int header_id)
        {
            InitializeComponent();
            this.header_id = header_id;
            headers = new int[] { header_id };
            multi = false;
            
            init();
            for (int i = 1; i <= (int)header.Tables[0].Rows[0]["cycles"]; i++)
            {
                checkedListBoxCyklyInclude.Items.Add(i);
            }
            checkBoxCyklyAllInclude.CheckState = CheckState.Checked;
            saveFileDialog1.AddExtension = true;
        }
        public ExportWindow(int[] headers)
        {
            
            InitializeComponent();
            this.headers = headers;
            header_id = headers[0];
            multi = true;
            
        }

        private DataSet header;
        private void init()
        {
            DbCommunication db = new DbCommunication();

            normalDataTable = db.meranie(header_id).Tables[0];
            dataMeranie.DataSource = normalDataTable;
            header = db.header(header_id);

            normalItems = new CheckedListBox.ObjectCollection(checkedListBoxInclude);
            
            for (int c = 0; c < dataMeranie.Columns.Count; c++)
            {
                dataMeranie.Columns[c].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataMeranie.Columns[c].Visible = false;
                normalItems.Add(dataMeranie.Columns[c].HeaderText);
            }

           
            refreshIncludeColumns(normalItems);

            checkedListBoxInclude.SetItemChecked(0, true);
            checkedListBoxInclude.SetItemChecked(2, true);
          

            

            
            

            jednotky = new Dictionary<string, string>();
            jednotky.Add("Intensity", "a.u."); // v db premenovat sig
            jednotky.Add("Electron energy", "eV");  //x v pripade energy scan,
            jednotky.Add("m/z", "amu");// x v pripade mass scan
            jednotky.Add("Temperature", "°C");
            jednotky.Add("Current", "nA");
            jednotky.Add("Chamber pressure", "mbar");
            jednotky.Add("Capillar pressure", "Pa");
            

        }

        public DataGridView grid { get; set; }

        private void export()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(headers[0].ToString());
            //MessageBox.Show(headers[1].ToString());
            //funkcia export.. exportovat vybrane zaznamy
            //...
            saveFileDialog1.InitialDirectory = Paths.Default.export_path;
            string filename = vygenerujNazov(headers[0]);
            saveFileDialog1.FileName = filename;
            DialogResult res = saveFileDialog1.ShowDialog();
            switch (res)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    for (int i = 0; i < headers.Length; i++)
                    {
                        filename = vygenerujNazov(headers[i]);
                        header_id = headers[i];
                        save(filename);
                    }
                    
                    break;
                default:
                    break;
            }

                
            
        }

        private string vygenerujNazov(int h_id)
        {
            
            DbCommunication db = new DbCommunication();
            DataSet hset = db.header(h_id);
            
            string date = hset.Tables[0].Rows[0]["datetime"].ToString();
            DateTime datum = Convert.ToDateTime(date);
            date = datum.ToString("dd.MM");

            string type = hset.Tables[0].Rows[0]["type_name"].ToString();
            string ionType = (hset.Tables[0].Rows[0]["ion_type"].ToString().Equals("1")) ? "Positive ions" : "Negative ions";
            string constant = "";
            if (type.Equals("Energy Scan"))
            {
                constant = hset.Tables[0].Rows[0]["constant"].ToString() + " amu";
            }
            if (type.Equals("Mass Scan"))
            {
                constant = hset.Tables[0].Rows[0]["constant"].ToString() + " eV";
            }
            return date + " - " + type + " - " + (constant.Equals("") ? "" : constant + " - ") + ionType;
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
            DbCommunication db = new DbCommunication();
            dataMeranie.DataSource= db.meranie(header_id).Tables[0];
            pocetCyklov = (int)header.Tables[0].Rows[0]["cycles"];
            if (includeHeader.Checked)
            {
                //prvy riadok - nazvy stlpcov - beru sa priamo z nazvov v datagride
                for (int cyklus = 0; cyklus < pocetCyklov; cyklus++)
                {
                    for (int j = 0; j < dataMeranie.Columns.Count; j++)
                    {
                        if (dataMeranie.Columns[j].Visible && dataMeranie.Columns[j].HeaderText != "cycle_num")
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
                        

                        if (dataMeranie.Columns[j].Visible)
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
                }
                file.WriteLine();

                string y = (type.Equals("Mass Scan") || type.Equals("2D Scan")) ? "m/z" : "Electron_energy";
                string x = (type.Equals("Mass Scan") || type.Equals("2D Scan")) ? "Electron_energy" : "m/z";
            }
            //data
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
            if (checkBoxIncludeAll.CheckState == CheckState.Indeterminate) return;

            for (int i = 0; i < checkedListBoxInclude.Items.Count; i++)
            {
                checkedListBoxInclude.SetItemChecked(i, checkBoxIncludeAll.Checked);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxCyklyInclude.Items.Count; i++)
            {
                checkedListBoxCyklyInclude.SetItemChecked(i, checkBoxCyklyAllInclude.Checked);   
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
            else
            {
                //checkBoxIncludeAll.CheckState = CheckState.Indeterminate;
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
                checkBoxCyklyAllInclude.CheckState = e.NewValue;
            }
            else
            {
               // checkBoxCyklyInclude.CheckState = CheckState.Indeterminate;
            }



        }

        CheckedListBox.ObjectCollection avgItems;
        CheckedListBox.ObjectCollection sumItems;
        CheckedListBox.ObjectCollection normalItems;

        private void refreshIncludeColumns(CheckedListBox.ObjectCollection items)
        {
            checkedListBoxInclude.Items.Clear();
            checkedListBoxInclude.Items.AddRange(items);
            for (int i=0; i<dataMeranie.Columns.Count; i++)
            {
                dataMeranie.Columns[i].Visible = false;
            }
            checkBoxIncludeAll.Checked = false;
            checkedListBoxInclude.SetItemChecked(0, true);
            checkedListBoxInclude.SetItemChecked(2, true);

            
        }

        private void dataMeranie_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void normalModeCheckboxChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                radioButton3.BackColor = Color.FromArgb(144, 195, 212);
                dataMeranie.DataSource = normalDataTable;
                refreshIncludeColumns(normalItems);
                checkedListBoxCyklyInclude.Enabled = true;
            }
            else {
                radioButton3.BackColor = default(Color);
            }
        }

        private void avgModeCheckboxChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                radioButton2.BackColor = Color.FromArgb(144, 195, 212);
                //avg urobit, ak neexistuje DataTable, vytvorit, inak iba prepnut.
                if (avgDataTable == null)
                {
                    DbCommunication db = new DbCommunication();
                    avgDataTable = db.meranieAvg(header_id).Tables[0];
                    avgItems = new CheckedListBox.ObjectCollection(checkedListBoxInclude);
                    foreach(DataColumn columnHeader in avgDataTable.Columns)
                    {    
                        avgItems.Add(columnHeader.ToString());
                    }
                }
                dataMeranie.DataSource = avgDataTable;
                refreshIncludeColumns(avgItems);
                checkedListBoxCyklyInclude.Enabled = false;
                checkBoxCyklyAllInclude.Enabled = false;
            }
            else
            {
                radioButton2.BackColor = default(Color);
            }
        }

        private void sumModeCheckboxChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton1.BackColor = Color.FromArgb(144, 195, 212);
                //sum urobit, ak neexistuje DataTable, vytvorit, inak iba prepnut.
                if (sumDataTable == null)
                {
                    DbCommunication db = new DbCommunication();
                    sumDataTable = db.meranieSum(header_id).Tables[0];
                    sumItems = new CheckedListBox.ObjectCollection(checkedListBoxInclude);
                    foreach (DataColumn columnHeader in sumDataTable.Columns)
                    {
                        sumItems.Add(columnHeader.ToString());
                    }
                }
                dataMeranie.DataSource = sumDataTable;
                refreshIncludeColumns(sumItems);
                checkedListBoxCyklyInclude.Enabled = false;
                checkBoxCyklyAllInclude.Enabled = false;
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

        private void checkBoxCyklyInclude_CheckStateChanged(object sender, EventArgs e)
        {

        }
    }
}
