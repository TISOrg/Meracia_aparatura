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

            sp = new SerialPort(Properties.Devices.Default.voltmeterPort, 4800, Parity.None, 8, StopBits.One);   //zakladne nastavenia, najma COM sa bude menit, zmeni sa v gui
            sp.DataReceived += new SerialDataReceivedEventHandler(this.dataRecieved);
            sp.ReceivedBytesThreshold = 1;  //velmi uzitocna vec... zavola recieved handler iba pri urcenom pocte bytov na vstupe. napr. pre teplomer
            //sp.NewLine ="\n";   //urci sa new line. vacsniou \n
        }

        private static string data;

     

        public SerialPort sp;


        /// <summary>
        /// vseobecna funckia na vratenie double typu pre ziskany text z voltmetra. Pre iny voltmeter moze byt konverzia menej trivialna, a tak sa iba zmeni tato funckia
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double convertToDouble(string data)
        {
            return Convert.ToDouble(data);  
        }

        public void open()
        {
            try {
                sp.Open();
                sp.Write(":System:Preset");
                sp.Write("\r\n");
                sp.Write("*RST");
                sp.Write("\r\n");
                sp.Write("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
                sp.Write("\r\n");
            }
            catch (Exception e)
            {

            }
        }
        Thread readThread;

        private void dataRecieved(object sender, SerialDataReceivedEventArgs e)
        {
            data = sp.ReadLine();
        }
        private void readThreadMethod()
        {
            
        }
        public double read()
        {

            sp.Write(":READ?");
            sp.Write("\r\n");
            ///docasne riesenie. vyriesit casovu medzeru medzi odoslanim poziadavku a prijatim dat. Po prijati na port sa zavola datareceived()
            double ret;
            while (data.Equals("")) ;
            ret = convertToDouble(data);
            data = "";
            ///vyriesit
            return ret;
        }

        public void close()
        {
            sp.Write(":INITiate:CONTinuous ON");
            sp.Write("\r\n");
            sp.Close();
        }

    }
}
