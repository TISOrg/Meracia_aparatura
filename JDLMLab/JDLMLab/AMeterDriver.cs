using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class AMeterDriver : SerialPortDriver
    {
        public AMeterDriver()
        {
            serialPort = new SerialPort(Properties.Devices.Default.ampermeterPort,9600,Parity.None,8,StopBits.One);
            //...
        }

        public override void close()
        {
            throw new NotImplementedException();
        }

        public override void open()
        {
            throw new NotImplementedException();
        }

        protected override void readRequest()
        {
            throw new NotImplementedException();
        }
    }
}
