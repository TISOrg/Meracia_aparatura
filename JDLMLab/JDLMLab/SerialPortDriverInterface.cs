using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace JDLMLab
{
    interface SerialPortDriverInterface
    {
        double read();
        void open();
        void close();
        
        
        
    }
}
