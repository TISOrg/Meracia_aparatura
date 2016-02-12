using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
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
            serialPort = new System.IO.Ports.SerialPort(Properties.Devices.Default.tempPort, 9600, System.IO.Ports.Parity.Even, 7, System.IO.Ports.StopBits.One); //4800 je default

            //The transmitter must not start transmission until 3 character times have elapsed since
            //reception of the last character in a message, and must release the transmission line within 3
            //character times of the last character in a message.
            //Note:Three character times = 1.5ms at 19200, 3ms at 9600, 6ms at 4800, 12ms at 2400 and 24ms at 1200 bps.
            serialPort.DataReceived += dataRecievedHandler;
            serialPort.ReceivedBytesThreshold = 10; //lebo format odpovede je L1Mabcd0A* 
            serialPort.NewLine = "*";
            serialPort.Open();

            IntervalMerania = Properties.Devices.Default.tempFreq*1000;
            base.open();
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
            char c = data.ElementAt(7);
            string ret = value;
            switch (c)
            {
                case '0':
                    break;
                case '1':
                    ret = value.Insert(3, ".");
                    break;
                case '2':
                    ret = value.Insert(2, ".");
                    break;
                case '3':
                    ret = value.Insert(1, ".");
                    break;
                case '5':
                    ret = value.Insert(0, "-");
                    break;
                case '6':
                    ret = value.Insert(0, "-");
                    ret = ret.Insert(3, ".");
                    break;
                case '7':
                    ret = value.Insert(0, "-");
                    ret = ret.Insert(2, ".");
                    break;
                case '8':
                    ret = value.Insert(0, "-");
                    ret = ret.Insert(1, ".");
                    break;
                default:
                    break;
            }
            
            return Double.Parse(ret, System.Globalization.NumberStyles.Float,new CultureInfo("en-US"));
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