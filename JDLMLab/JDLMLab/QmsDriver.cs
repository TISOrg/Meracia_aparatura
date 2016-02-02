using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class QmsDriver : SerialPortDriver
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
            throw new NotImplementedException();
        }

        internal static void setPoint(double startPoint)
        {
            
        }
    }
}
