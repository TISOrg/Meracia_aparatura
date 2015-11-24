using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Serialexample
{
    public partial class Form1 : Form
    {
       // SerialPort sp = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            try
            {

                //open serial port

                //set read time out to 500 ms
                serialPort1.Open();


            }
            catch (System.Exception ex)
            {
             //   baudRatelLabel.Text = ex.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //clear the text box
                
                //read serial port and displayed the data in text box
                //textBox1.Text =  sp.ReadLine();
               
                // manual s.92 hovori data tranmsissions sa daju breaknut poslanim ^C or ^X
                // a tiez ze multimeter ma nastavenia 8 data bits, 1 stop bit, and no parity.
                serialPort1.WriteLine("*CLS"); //PRINT #1, “*CLS” ‘ Clear Model 2000
                serialPort1.WriteLine("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
                serialPort1.WriteLine(":SENS: FUNC ‘VOLT: DC’"); //PRINT #1, “:SENS:FUNC ‘VOLT:DC’” ‘ DCV
                serialPort1.WriteLine(":SYST:AZER:STAT OFF"); //PRINT #1, “:SYST:AZER:STAT OFF” ‘ Auto zero off
                serialPort1.WriteLine(":SENS:VOLT:DC:AVER:STAT OFF"); //PRINT #1, “:SENS:VOLT:DC:AVER:STAT OFF” ‘ Filter off
                serialPort1.WriteLine(":SENS:VOLT:DC:NPLC 0.01"); //PRINT #1, “:SENS:VOLT:DC:NPLC 0.01” ‘ NPLC = 0.01
                serialPort1.WriteLine(":SENS:VOLT:DC:RANG 10"); //PRINT #1, “:SENS:VOLT:DC:RANG 10” ‘ 10V range
                serialPort1.WriteLine(":SENS:VOLT:DC:DIG 4"); //PRINT #1, “:SENS:VOLT:DC:DIG 4” ‘ 4 digit
                serialPort1.WriteLine(":FORM:ELEM READ"); //PRINT #1, “:FORM:ELEM READ” ‘ Reading only
                serialPort1.WriteLine(":TRIG:COUN 1"); //PRINT #1, “:TRIG:COUN 1” ‘ Trig count 1
                serialPort1.WriteLine(":SAMP:COUN 100"); //PRINT #1, “:SAMP:COUN 100” ‘ Sample count 100
                serialPort1.WriteLine(":TRIG:DEL 0"); //PRINT #1, “:TRIG:DEL 0” ‘ No trigger delay
                serialPort1.WriteLine(":TRIG:SOUR IMM"); //PRINT #1, “:TRIG:SOUR IMM” ‘ Immediate trigger
                serialPort1.WriteLine(":DISP:ENAB OFF"); //PRINT #1, “:DISP:ENAB OFF” ‘ No display
                //SLEEP 1 ‘ Wait one second
                serialPort1.WriteLine(":READ?"); //PRINT #1, “:READ?” ‘ Read query
                //LINE INPUT #1, RD$ ‘ Get data
                //PRINT RD$ ‘ Display data
                serialPort1.WriteLine(":DISP:ENAB ON"); //PRINT #1, “:DISP:ENAB ON” ‘ Turn on display
                //‘ Clean up and quit.
                
                //CLOSE #1 ‘ Close file
                //CLEAR ‘ Interface clear
                //END



            }
            catch (System.Exception ex)
            {
                //baudRatelLabel.Text = ex.Message;
            }
        }


        String a;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            a = serialPort1.ReadExisting();
            this.Invoke(new EventHandler(appear_word));
        }
        private void programClose(object sender, FormClosedEventArgs e) 
        {
            serialPort1.Close();
        }
            
        private void appear_word(object sender, EventArgs e)
        {
            richTextBox1.AppendText(a);
            richTextBox1.ScrollToCaret();

        }
    }
}
