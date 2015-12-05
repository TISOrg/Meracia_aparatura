using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace JDLMLab
{
    /// <summary>
    /// autor: Jano
    /// </summary>
    class VMeterDriver
    {
        public static SerialPort sp = new SerialPort();
        public void open()
        {
            sp.Open();
        }
        public void close()
        {
            sp.Close();
        }
        public void write()
        {
     
        }
        public string read()
        {
            return "";
        }
    }
}
