using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
using System.Windows.Forms;

namespace JDLMLab
{
    /// <summary>
    /// autor: Jano
    /// </summary>
    class VMeterDriver : SerialPortDriver
    {
        RichTextBox richTextBox1;
        public override void open()
        {
            serialPort = new SerialPort(Properties.Devices.Default.voltmeterPort, 9600, Parity.None, 8, StopBits.One);   //zakladne nastavenia, najma COM sa bude menit, zmeni sa v gui
            

            serialPort.DataReceived += dataRecieved;
            serialPort.ReceivedBytesThreshold = 1;  //velmi uzitocna vec... zavola recieved handler iba pri urcenom pocte bytov na vstupe. napr. pre teplomer
            //sp.NewLine ="\n";   //urci sa new line. vacsniou \n
            
            serialPort.Open();
            serialPort.NewLine = "\r\n";
            serialPort.Write(":System:Preset");
            serialPort.Write("\r\n");
            serialPort.Write("*RST");
            serialPort.Write("\r\n");
            serialPort.Write("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
            serialPort.Write("\r\n");
            ///readRequest();
        }

        public override void close()
        {
            serialPort.Write(":INITiate:CONTinuous ON");
            serialPort.Write("\r\n");
            serialPort.Close();
        }

        protected override void readRequest()
        {
            serialPort.Write(":READ?");
            serialPort.Write("\r\n");
        }
        protected override double convertToDouble(string data)
        {
            NumberStyles styles;
            //styles = NumberStyles.AllowExponent;
            double d=Double.Parse(data.Replace('.',','), System.Globalization.NumberStyles.Float);
            //MessageBox.Show(d.ToString());
            return d;
        }

        internal void o(RichTextBox r)
        {
            richTextBox1 = r;
        }
    }
}
