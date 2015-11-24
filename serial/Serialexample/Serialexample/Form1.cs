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
using System.Threading;


namespace Serialexample
{
    public partial class Form1 : Form
    {
        internal class Senzor
        {
            public string status;
            public string reading;
        }
        // SerialPort sp = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            try
            {
                //serialPort2.Open();
                //open serial port
               // serialPort2.Open();
                //set read time out to 500 ms
               
                //vypnut pre tlakomer teraz
                /*serialPort1.Open();
                serialPort1.Write(":System:Preset");
                serialPort1.Write("\r\n");
                serialPort1.Write("*RST");
                serialPort1.Write("\r\n");
                serialPort1.Write("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
                serialPort1.Write("\r\n");
                 */

                /*serialPort1.Write(":SENS: FUNC ‘VOLT: DC’"); //PRINT #1, “:SENS:FUNC ‘VOLT:DC’” ‘ DCV
                serialPort1.Write("\r\n");
                serialPort1.Write(":SYST:AZER:STAT OFF"); //PRINT #1, “:SYST:AZER:STAT OFF” ‘ Auto zero off
                serialPort1.Write("\r\n");
                serialPort1.Write(":SENS:VOLT:DC:AVER:STAT OFF"); //PRINT #1, “:SENS:VOLT:DC:AVER:STAT OFF” ‘ Filter off
                serialPort1.Write("\r\n");
                serialPort1.Write(":SENS:VOLT:DC:NPLC 0.01"); //PRINT #1, “:SENS:VOLT:DC:NPLC 0.01” ‘ NPLC = 0.01
                serialPort1.Write("\r\n");
                serialPort1.Write(":SENS:VOLT:DC:RANG 10"); //PRINT #1, “:SENS:VOLT:DC:RANG 10” ‘ 10V range
                serialPort1.Write("\r\n");
                serialPort1.Write(":SENS:VOLT:DC:DIG 5"); //PRINT #1, “:SENS:VOLT:DC:DIG 4” ‘ 4 digit
                serialPort1.Write("\r\n");
                serialPort1.Write(":FORM:ELEM READ"); //PRINT #1, “:FORM:ELEM READ” ‘ Reading only
                serialPort1.Write("\r\n");
                serialPort1.Write(":TRIG:COUN 1"); //PRINT #1, “:TRIG:COUN 1” ‘ Trig count 1
                serialPort1.Write("\r\n");
                serialPort1.Write(":SAMP:COUN 1"); //PRINT #1, “:SAMP:COUN 100” ‘ Sample count 100
                serialPort1.Write("\r\n");
                serialPort1.Write(":TRIG:DEL 0"); //PRINT #1, “:TRIG:DEL 0” ‘ No trigger delay
                serialPort1.Write("\r\n");
                serialPort1.Write(":TRIG:SOUR IMM"); //PRINT #1, “:TRIG:SOUR IMM” ‘ Immediate trigger
                serialPort1.Write("\r\n");
                serialPort1.Write(":DISP:ENAB OFF"); //PRINT #1, “:DISP:ENAB OFF” ‘ No display
                //SLEEP 1 ‘ Wait one second
                serialPort1.Write("\r\n");
                serialPort1.Write(":DISP:ENAB ON"); //PRINT #1, “:DISP:ENAB ON” ‘ Turn on display
                serialPort1.Write("\r\n");*/


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

                //serialPort1.Write("*IDN?" + "\r\n");
                //clear the text box

                //read serial port and displayed the data in text box
                //textBox1.Text =  sp.ReadLine();

                // manual s.92 hovori data tranmsissions sa daju breaknut poslanim ^C or ^X
                // a tiez ze multimeter ma nastavenia 8 data bits, 1 stop bit, and no parity.

                // serialPort1.Write(":System:Preset");
                // serialPort1.Write("\r\n");
                // serialPort1.Write("*RST");
                // serialPort1.Write("\r\n");
                /*serialPort1.Write("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":SENS: FUNC ‘VOLT: DC’"); //PRINT #1, “:SENS:FUNC ‘VOLT:DC’” ‘ DCV
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":SYST:AZER:STAT OFF"); //PRINT #1, “:SYST:AZER:STAT OFF” ‘ Auto zero off
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":SENS:VOLT:DC:AVER:STAT OFF"); //PRINT #1, “:SENS:VOLT:DC:AVER:STAT OFF” ‘ Filter off
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":SENS:VOLT:DC:NPLC 0.01"); //PRINT #1, “:SENS:VOLT:DC:NPLC 0.01” ‘ NPLC = 0.01
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":SENS:VOLT:DC:RANG 10"); //PRINT #1, “:SENS:VOLT:DC:RANG 10” ‘ 10V range
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":SENS:VOLT:DC:DIG 4"); //PRINT #1, “:SENS:VOLT:DC:DIG 4” ‘ 4 digit
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":FORM:ELEM READ"); //PRINT #1, “:FORM:ELEM READ” ‘ Reading only
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":TRIG:COUN 1"); //PRINT #1, “:TRIG:COUN 1” ‘ Trig count 1
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":SAMP:COUN 10"); //PRINT #1, “:SAMP:COUN 100” ‘ Sample count 100
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":TRIG:DEL 0"); //PRINT #1, “:TRIG:DEL 0” ‘ No trigger delay
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":TRIG:SOUR IMM"); //PRINT #1, “:TRIG:SOUR IMM” ‘ Immediate trigger
                 serialPort1.Write("\r\n");
                 serialPort1.Write(":DISP:ENAB OFF"); //PRINT #1, “:DISP:ENAB OFF” ‘ No display
                 //SLEEP 1 ‘ Wait one second
                 serialPort1.Write("\r\n");*/
                serialPort1.Write(":READ?"); //PRINT #1, “:READ?” ‘ Read query
                //LINE INPUT #1, RD$ ‘ Get data
                //PRINT RD$ ‘ Display data
                serialPort1.Write("\r\n");
                //serialPort1.Write(":DISP:ENAB ON"); //PRINT #1, “:DISP:ENAB ON” ‘ Turn on display
                //serialPort1.Write("\r\n");
                //‘ Clean up and quit.

                //CLOSE #1 ‘ Close file
                //CLEAR ‘ Interface clear
                //END



                richTextBox1.AppendText(serialPort1.ReadLine());
            }
            catch (System.Exception ex)
            {
                //baudRatelLabel.Text = ex.Message;
            }
        }


        String a;
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           // a = serialPort1.ReadLine();
            //this.Invoke(new EventHandler(appear_word));
        }
        private void programClose(object sender, FormClosedEventArgs e)
        {
            serialPort1.Write(":INITiate:CONTinuous ON");
            serialPort1.Write("\r\n");
            serialPort1.Close();

        }

        private void appear_word(object sender, EventArgs e)
        {
            richTextBox1.AppendText(a);
            richTextBox1.ScrollToCaret();

        }

   
        private void button2_Click_1(object sender, EventArgs e)
        {
            serialPort1.Write(":INITiate:CONTinuous ON");
            serialPort1.Write("\r\n");
            serialPort1.Close();
            Application.Exit();
        }


         public SerialPort Port;
        private char[] receiveBuffer = new char[65];
        string prijate;
       // public static List<Senzor> Senzory = new List<Senzor>(6);
        private char[] znaky = new char[3];
        private string poslednyPrikaz = "";
        public Thread zistovacTlakov;

        

        private void button3_Click(object sender, EventArgs e)
        {

          
            serialPort2.NewLine = "\r\n";
            //serialPort2.DataReceived += new SerialDataReceivedEventHandler(serialPort2_DataReceived);
            serialPort2.Open();

            znaky[0] = '\x02';
            znaky[1] = '\x03';
            znaky[2] = '\x05';

            //for (int i = 0; i <= 5; i++)
            //{
            //    Senzory.Add(new Senzor());
            //}

            Thread.Sleep(100);

            zistovacTlakov = new Thread(new ThreadStart(this.zistovac));
            zistovacTlakov.Start();

           
        }
        private static string hodnota="";
        


            
            //serialPort2.Write("\r");
            //tlakomerBox.AppendText(serialPort2.ReadLine());
            //serialPort2.Write("@sts1");
            //serialPort2.Write("\r");
            //tlakomerBox.AppendText("aaa");
          
        

        private void serialPort2_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
           // tlakomerBox.AppendText("aaa");
           // tlakomerBox.AppendText(Convert.ToString(serialPort2.ReadByte()));
        }

      private void zistovac()
        {
            do
            {
                int i = 1;
                Thread.Sleep(3000);

                //foreach (Senzor senzor in Senzory)
                //{
                    serialPort2.Write("PR" + "1" + "\r\n");
                    Thread.Sleep(100);
                    serialPort2.ReadLine();
                    serialPort2.Write(znaky, 2, 1);
                    i++;
                    Thread.Sleep(100);
                    prijate = serialPort2.ReadLine();
                    spracujStatusTlak(prijate);
                //}
            }
            while (true);
        }

        private void spracujStatusTlak(string prijate)
        {
            char[] sep = new char[1];
            sep[0] = ',';

            string[] temp = prijate.Split(sep, 2);

            hodnota=temp[0]+"\t"+temp[1]+"\n";
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tlakomerBox.AppendText(hodnota);
        }
    }
}
