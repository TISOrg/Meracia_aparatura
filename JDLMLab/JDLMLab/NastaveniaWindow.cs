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
    public partial class NastaveniaWindow : Form
    {
        public NastaveniaWindow()
        {
            InitializeComponent();
            fillValues();
        }

        private void fillValues()
        {

            dbSettingsFieldHost.Text = Database.Default.host;
            dbSettingsFieldPort.Text = Database.Default.port.ToString();
            dbSettingsFieldUser.Text = Database.Default.user;
            dbSettingsFieldPassword.Text = Database.Default.password;
            dbSettingsFieldDatabase.Text = Database.Default.database;

            devAmpermeterComTextField.Text = Properties.Devices.Default.ampermeterPort;
            devVoltmeterComTextField.Text = Properties.Devices.Default.voltmeterPort;
            devTempFreqTextField.Text = Properties.Devices.Default.tempFreq.ToString();
            devTempComTextField.Text = Properties.Devices.Default.tempPort;
            devKapillarComTextField.Text = Properties.Devices.Default.pr4000Port;
            devKapillarFreqTextField.Text = Properties.Devices.Default.pr4000Freq.ToString();
            devQmsComTextField.Text = Properties.Devices.Default.qmsPort;
            devChamberComTextField.Text = Properties.Devices.Default.tpg256aPort.ToString();
            devChamberFreqTextField.Text = Properties.Devices.Default.tpg256aFreq.ToString();
            devChamberChannel.Value = Properties.Devices.Default.tpg256aChannel;
            TemConstantField.Text = Properties.Devices.Default.TemConstant.ToString();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("512", 512);
            dict.Add("1024", 1024);
            dict.Add("2048", 2048);

            QmsTypeCombo.DataSource = new BindingSource(dict, null);
            QmsTypeCombo.DisplayMember = "Key";
            QmsTypeCombo.ValueMember = "Value";

            QmsTypeCombo.SelectedValue = Properties.Devices.Default.QmsType;

            
          
            export_path_text.Text = Paths.Default.export_path;
        }


        private void saveDbSettingsButton_Click(object sender, EventArgs e)
        {
         
        }

        private void FormValidateError(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void devicesSaveButton_Click(object sender, EventArgs e)
        {
    


        }

        

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            if(fd.ShowDialog()==DialogResult.OK) export_path_text.Text = fd.SelectedPath;
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(export_path_text.Text)){
                Paths.Default.export_path = export_path_text.Text;
            }
            else
            {
            DialogResult res = MessageBox.Show("Zadaná zložka neexistuje. Vytvoriť?","Zložka neexistuje",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                try
                {
                    DirectoryInfo i = Directory.CreateDirectory(export_path_text.Text);
                    export_path_text.Text = i.FullName;
                    Paths.Default.export_path = i.FullName;

                }
                catch (Exception ef)
                {
                    FormValidateError("Zadajte správnu cestu", "Chyba");
                    return;
                }

            }
                else return;
            }
            Paths.Default.Save();
            showSaveInfo();

        }

        private void saveDbSettingsButton_Click_1(object sender, EventArgs e)
        {
            if (validateDbSettings())
            {
                saveDbSettings();
                showSaveInfo();
            }
        }

        private bool validateDbSettings() 
        {
            //testovat validitu fieldov
            int port;
            if (dbSettingsFieldHost.Text.Length < 3 || dbSettingsFieldHost.Text.IndexOf('.') == -1)
            {
                FormValidateError("Zadajte správnu hodnotu host", "Neplatná hodnota");
            }
            else if (dbSettingsFieldUser.Text.Length < 1) FormValidateError("Zadajte hodnotu user", "Neplatná hodnota");
            else if (dbSettingsFieldPassword.Text.Length < 1) FormValidateError("Zadajte hodnotu password", "Neplatná hodnota");
            else if (dbSettingsFieldDatabase.Text.Length < 1) FormValidateError("Zadajte hodnotu database", "Neplatná hodnota");
            else if (!int.TryParse(dbSettingsFieldPort.Text, out port)) FormValidateError("Zadajte hodnotu port", "Neplatná hodnota");
            else
            {
                return true;
            }
            return false;
        }

        private void saveDbSettings()
        {
            fillDbSettings();
            Database.Default.Save();
        }
        private void fillDbSettings()
        {
            Database.Default.host = dbSettingsFieldHost.Text;
            Database.Default.port = int.Parse(dbSettingsFieldPort.Text);
            Database.Default.user = dbSettingsFieldUser.Text;
            Database.Default.password = dbSettingsFieldPassword.Text;
            Database.Default.database = dbSettingsFieldDatabase.Text;
        }

        private void devicesSaveButton_Click_1(object sender, EventArgs e)
        {
            int a;
            double b;
            if (devVoltmeterComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu voltmetra", "Neplatná hodnota");
            else if (devAmpermeterComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu ampérmetra", "Neplatná hodnota");
            else if (devQmsComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu QMS", "Neplatná hodnota");
            else if (devKapillarComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu tlakomera PR4000", "Neplatná hodnota");
            else if (!int.TryParse(devKapillarFreqTextField.Text, out a)) FormValidateError("Zadajte hodnotu frekvencia čítania tlakomera PR4000", "Neplatná hodnota");
            else if (devChamberComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu tlakomera TPG256a", "Neplatná hodnota");
            else if (!int.TryParse(devChamberFreqTextField.Text, out a)) FormValidateError("Zadajte hodnotu frekvencia čítania portu tlakomera TPG256a", "Neplatná hodnota");
            else if (!double.TryParse(TemConstantField.Text, out b) || TemConstantField.Text.IndexOf(',')!=-1) FormValidateError("Zadajte správnu hodnotu TEM Constant", "Neplatná hodnota");
            else
            {
                Properties.Devices.Default.ampermeterPort = devAmpermeterComTextField.Text;
                Properties.Devices.Default.voltmeterPort = devVoltmeterComTextField.Text;
                Properties.Devices.Default.tempFreq = int.Parse(devTempFreqTextField.Text);
                Properties.Devices.Default.tempPort = devTempComTextField.Text;
                Properties.Devices.Default.tpg256aChannel = (int)devChamberChannel.Value;
                Properties.Devices.Default.tpg256aFreq = int.Parse(devChamberFreqTextField.Text);
                Properties.Devices.Default.tpg256aPort = devChamberComTextField.Text;
                Properties.Devices.Default.qmsPort = devQmsComTextField.Text;
                Properties.Devices.Default.pr4000Freq = int.Parse(devKapillarFreqTextField.Text);
                Properties.Devices.Default.pr4000Port = devKapillarComTextField.Text;
                Properties.Devices.Default.TemConstant=double.Parse(TemConstantField.Text);
                Properties.Devices.Default.QmsType = int.Parse(QmsTypeCombo.Text);
                Properties.Devices.Default.Save();
                showSaveInfo();
            }
        }

        private void showSaveInfo()
        {
            MessageBox.Show("Nastavenia boli uložené", "Zmena nastavení", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {            
            if (validateDbSettings())
            {
                fillDbSettings();   //vyplni db nastavenia do settings filu docasne
                try
                {
                    DbCommunication.testConnection();
                    MessageBox.Show("Pripojenie úspešné", "Pripojenie úspešné", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    if (ex.Number == 0)
                    {
                        FormValidateError("Pripojenie k databáze zlyhalo. Zadajte správne prihlasovacie údaje!\n", "Chybné prihlásenie");
                    }
                    else
                    {
                        FormValidateError("Nepodarilo sa pripojiť na doménu " + dbSettingsFieldHost.Text, "Chybná doména");
                    }
                }
                Database.Default.Reset();   //zresetuje povodne nastavenia v settings file
                
            }
        }

        private void QmsTypeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NastaveniaWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) 
            {
                DialogResult = DialogResult.Cancel;
            }
        }
    }
}
