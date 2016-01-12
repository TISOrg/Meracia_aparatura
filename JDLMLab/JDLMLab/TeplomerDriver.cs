using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDLMLab
{
    class TeplomerDriver : SerialPortDriver
    {
        public override void close()
        {
            serialPort.Close();
        }

        public override void open()
        {
            serialPort = new System.IO.Ports.SerialPort(Properties.Devices.Default.tempPort, 4800, System.IO.Ports.Parity.Even, 7, System.IO.Ports.StopBits.One); //4800 je default

            //The transmitter must not start transmission until 3 character times have elapsed since
            //reception of the last character in a message, and must release the transmission line within 3
            //character times of the last character in a message.
            //Note:Three character times = 1.5ms at 19200, 3ms at 9600, 6ms at 4800, 12ms at 2400 and 24ms at 1200 bps.
            serialPort.DataReceived += dataRecieved;
            serialPort.ReceivedBytesThreshold = 10; //lebo format odpovede je L1Mabcd0A* 
            serialPort.Open();

        }

        protected override void readRequest()
        {
            serialPort.Write("L1M?*");            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">format odpovede je: L {N} {P} {DATA} A *. {DATA} comprises five ASCII-coded digits. vid tabulku str. 128,
        /// cizeu to je napr. L1M abcd0 A* </param>
        /// <returns></returns>
        protected override double convertToDouble(string data)
        {

            string value = data.Substring(3, 4); //to je nase {DATA} bez poslednej cifry, cize iba abcd
            return base.convertToDouble(data);
        }
        ///tabulka formatov {DATA}
        /// abcd0    +abcd   Positive value, no decimal place
        /// abcd1    +abc.d  Positive value, one decimal place
        /// abcd2    +ab.cd  Positive value, two decimal places
        /// abcd3    +a.bcd  Positive value, three decimal places
        /// Abcd5    -abcd   Negative value, no decimal place
        /// Abcd6    -abc.d  Negative value, one decimal place
        /// Abcd7    -ab.cd  Negative value, two decimal places
        /// Abcd8    -a.bcd  Negative value, three decimal places
    }
}