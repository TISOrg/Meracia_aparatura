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
            throw new NotImplementedException();
        }

        public override void open()
        {
            throw new NotImplementedException();
        }

        protected override void readRequest()
        {
            serialPort.Write("L1M?*");            
        }
    }
}