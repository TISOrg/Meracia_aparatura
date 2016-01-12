using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class TlakomerPR4000Driver : SerialPortDriver
    {
        public override void close()
        {
            throw new NotImplementedException();
        }

        public override void open()
        {
            serialPort = new System.IO.Ports.SerialPort(Properties.Devices.Default.tpg256aPort, 9600, System.IO.Ports.Parity.Odd, 7, System.IO.Ports.StopBits.One);
            //overit spravne hodnoty
            serialPort.Handshake = System.IO.Ports.Handshake.None;
            
            
        }

        protected override void readRequest()
        {
            serialPort.Write("\r");
            serialPort.Write("@sts1");
            serialPort.Write("\r");
        }
    }
}
