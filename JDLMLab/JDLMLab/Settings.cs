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
    public partial class Settings : Form
    {
        public Settings()
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

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void saveDbSettingsButton_Click(object sender, EventArgs e)
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
            else if(!int.TryParse(dbSettingsFieldPort.Text,out port)) FormValidateError("Zadajte hodnotu port", "Neplatná hodnota");
            else
            {
                Database.Default.host = dbSettingsFieldHost.Text;
                Database.Default.port = int.Parse(dbSettingsFieldPort.Text);
                Database.Default.user = dbSettingsFieldUser.Text;
                Database.Default.password = dbSettingsFieldPassword.Text;
                Database.Default.database = dbSettingsFieldDatabase.Text;
                Database.Default.Save();
            }
        }

        private void FormValidateError(string msg,string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void devicesSaveButton_Click(object sender, EventArgs e)
        {
            int a;
            if (devVoltmeterComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu voltmetra","Neplatná hodnota");
            else if (devAmpermeterComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu ampérmetra", "Neplatná hodnota");
            else if (devQmsComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu QMS", "Neplatná hodnota");
            else if (devKapillarComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu tlakomera PR4000", "Neplatná hodnota");
            else if (!int.TryParse(devKapillarFreqTextField.Text,out a)) FormValidateError("Zadajte hodnotu frekvencia čítania tlakomera PR4000", "Neplatná hodnota");
            else if (devChamberComTextField.Text.Length < 1) FormValidateError("Zadajte hodnotu názov portu tlakomera TPG256a", "Neplatná hodnota");
            else if (!int.TryParse(devChamberFreqTextField.Text, out a)) FormValidateError("Zadajte hodnotu frekvencia čítania portu tlakomera TPG256a", "Neplatná hodnota");
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
                Properties.Devices.Default.Save();
            }


        }
    }
        
    }