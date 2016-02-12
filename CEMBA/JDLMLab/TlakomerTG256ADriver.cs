using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Windows.Forms;
namespace JDLMLab
{
    /// <summary>
    /// prerobit, aby fungovalo
    /// </summary>
    class TlakomerTG256ADriver : SerialPortDriver
    {
        int kanal;
        public override void close()
        {
            serialPort.Close();
        }

        public override void open()
        {
            serialPort = new System.IO.Ports.SerialPort(Properties.Devices.Default.tpg256aPort, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

            kanal = Properties.Devices.Default.tpg256aChannel;
            // serialPort.Handshake = System.IO.Ports.Handshake.None;
            serialPort.DataReceived += dataRecievedHandler;
            znaky[0] = '\x02';
            znaky[1] = '\x03';
            znaky[2] = '\x05';
            serialPort.NewLine = "\r\n";
            serialPort.ReceivedBytesThreshold = 7;//format je x,x.xxxEsx
            serialPort.Open();
            IntervalMerania = Properties.Devices.Default.tpg256aFreq * 1000;
            base.open();
        } 

        private char[] znaky = new char[3];
       
        protected override void readRequest()
        {
            serialPort.Write("PR" + kanal.ToString() + "\r\n");
            serialPort.ReadLine();
            serialPort.Write(znaky,2,1);
        }

        /// <summary>
        /// treba prekonat tuto metodu, lebo data prijate z tlakomera su vo formate y,x.xxxEsx <CR><LF>
        /// kde x.xxx je vzdy v exponecialnom formate, a y je 0 ak je meranie ok, ostatne cisla pozriet v dokumentacii pristroja
        /// y=3 je sensor error
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        protected override double convertToDouble(string data)
        {
            string[] temp = data.Split(new char[] { ',' }, 2);
            //teoreticky by sa dalo vyuzit temp[0] pre osetrenie pripadu nefunkcneho senzora
            //MessageBox.Show(temp[1]);
            return Double.Parse(temp[1], System.Globalization.NumberStyles.Float, new CultureInfo("en-US"));
        }
        
    }
}
