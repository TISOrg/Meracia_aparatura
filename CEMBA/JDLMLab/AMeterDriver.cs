using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace JDLMLab
{
    /// <summary>
    /// zrejme tie iste veci ako u Voltmetra
    /// </summary>
    class AMeterDriver : SerialPortDriver
    {
        
        public override void close()
        {
         
            serialPort.Close();
        }

        public override void open()
        {
            serialPort = new SerialPort(Properties.Devices.Default.ampermeterPort, 9600, Parity.None, 8, StopBits.One);   //zakladne nastavenia, najma COM sa bude menit, zmeni sa v gui
            serialPort.DataReceived += dataRecievedHandler;
            serialPort.ReceivedBytesThreshold = 5;  //velmi uzitocna vec... zavola recieved handler iba pri urcenom pocte bytov na vstupe. napr. pre teplomer
            //sp.NewLine ="\n";   //urci sa new line. vacsniou \n
            serialPort.Open();
            serialPort.NewLine = "\r";
            //serialPort.Write("System:Preset");
            //serialPort.Write("\r\n");
            serialPort.Write("*RST");
            serialPort.Write("\r\n");
            //serialPort.Write("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
            //serialPort.Write("\r\n");
            serialPort.Write("SYST:ZCH OFF");
            serialPort.Write("\r\n");
            serialPort.Write("FORM:ELEM READ");
            serialPort.Write("\r\n");
            //serialPort.Write("");
            //serialPort.Write("\r\n");
            base.open();
        }

        protected override void readRequest()
        {
            serialPort.Write("READ?");
            serialPort.Write("\r\n");
        }
        protected override double convertToDouble(string data)
        {
           // data=data.Replace('+', ' ');
            return Double.Parse(data, System.Globalization.NumberStyles.Float, new CultureInfo("en-US"));
           
        }
    }
}
