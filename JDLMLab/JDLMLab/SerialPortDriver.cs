using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    abstract class SerialPortDriver : SerialPortDriverInterface
    {
        public SerialPortDriver()
        {
            serialPort = new SerialPort();
            serialPort.DataReceived += dataRecieved;
        }
        protected SerialPort serialPort;
        public abstract void close();

        /// <summary>
        /// vseobecna funckia na vratenie double typu pre ziskany text zo zariadenia. Pre ine zariadenie moze byt konverzia menej trivialna, a tak sa iba overriduje  tato funckia
        /// </summary>
        /// <param name="data">string ktory sa ma previest na double</param>
        /// <returns></returns>
        protected double convertToDouble(string data)
        {
            return Convert.ToDouble(data);
        }
        protected static string data;

        protected void dataRecieved(object sender,SerialDataReceivedEventArgs e)
        {
            data = serialPort.ReadLine();
        }
        public abstract void open();
        public abstract double read();
    }
}
