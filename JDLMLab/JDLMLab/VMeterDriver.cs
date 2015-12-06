using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
namespace JDLMLab
{
    /// <summary>
    /// autor: Jano
    /// </summary>
    class VMeterDriver
    {
        public VMeterDriver()
        {
            sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.dataRecieved);
            
        }
        private static string data;
        private void dataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            data = sp.ReadLine();
        }

        public static SerialPort sp = new SerialPort("COM3",4800,Parity.None,8,StopBits.One);   //zakladne nastavenia, najma COM sa bude menit, zmeni sa v gui
        
        public void open()
        {
            sp.Open();
            sp.Write(":System:Preset");
            sp.Write("\r\n");
            sp.Write("*RST");
            sp.Write("\r\n");
            sp.Write("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
            sp.Write("\r\n");
        }
        public void close()
        {
            sp.Write(":INITiate:CONTinuous ON");
            sp.Write("\r\n");
            sp.Close();
        }
        public void write()
        {
     
        }

        public string read()
        {
            string ret = "";
            sp.Write(":READ?");
            sp.Write("\r\n");
            while (data.Equals("")) ;
            ret = data;
            data = "";
            return ret;
        }
    }
}
