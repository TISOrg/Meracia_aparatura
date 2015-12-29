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
        }
        private DataSet header;
        private void init()
        {
            checkBoxIncludeAll.Checked = true;
            checkBoxCyklyInclude.Checked = true;
            saveFileDialog1.AddExtension = true;
        }

        public DataGridView grid { get; set; }

        private void export()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //funkcia export.. exportovat vybrane zaznamy do formatu .csv
            //...
            saveFileDialog1.InitialDirectory = Paths.Default.export_path;
            string date = header.Tables[0].Rows[0]["datetime"].ToString();
            date=date.Replace(":", "-");
            
            saveFileDialog1.FileName = header.Tables[0].Rows[0]["name"] + " - " + date;
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

        private void save(string filename)
        {
            StreamWriter file = new StreamWriter(filename, false);
            bool firstColumn = true;
            for (int j = 0; j < dataMeranie.Columns.Count; j++)
            {
                if (dataMeranie.Columns[j].Visible)
                {
                    if (!firstColumn) file.Write(",");
                    file.Write(dataMeranie.Columns[j].HeaderText);
                    firstColumn = false;
                }

            }
            file.WriteLine();
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
                            if (!firstColumn) file.Write(",");
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
            //MessageBox.Show(dataMeranie.Rows.Count.ToString());

            
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
                        e.NewValue = CheckState.Unchecked;
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
    }
}
