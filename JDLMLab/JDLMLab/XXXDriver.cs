using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace JDLMLab
{
    class XXXDriver : SerialPortDriver
    {
        public XXXDriver()
        {
            serialPort = new System.IO.Ports.SerialPort("COM31", 32800, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            serialPort.ReceivedBytesThreshold = 5;
            serialPort.DataReceived += dataRecieved;
            testq = new Queue<string>();

        }
        

        public override void close()
        {
            serialPort.Close();
            blockingCollection.CompleteAdding();
        }


        public override void open()
        {
            blockingCollection = new BlockingCollection<double>();
            serialPort.Open();
        }
        protected override double convertToDouble(string data)
        {
            if (data.Equals("On"))
            {
                return 1.0;

            }
            if (data.Equals("Off"))
            {
                return 0;
            }
            return -1;
        }

        protected override void readRequest()
        {
            ;
        }
       
        
    }
}
