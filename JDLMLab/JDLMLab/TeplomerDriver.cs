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

        public override double read()
        {
            serialPort.Write("L1M?*");
            
            ///docasne riesenie. vyriesit casovu medzeru medzi odoslanim poziadavku a prijatim dat. Po prijati na port sa zavola datareceived()
            /// zreme to ostane takto... metoda bude aj tak spustena v threade, a tu sa aj tak musi cakat az do prijdenia dat. takze while .
            double ret;
            while (data.Equals("")) ;
            ret = convertToDouble(data);
            data = "";
            return ret;
        }
    }
}