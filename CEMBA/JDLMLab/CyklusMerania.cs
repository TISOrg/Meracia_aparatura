using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    public class CyklusMerania 
    {
        public CyklusMerania(int i)
        {
            KrokyMerania = new List<KrokMerania>();
            cisloCyklu = i;
        }
        public CyklusMerania()
        {
            KrokyMerania = new List<KrokMerania>();
        }
        public int cisloCyklu { get; set; }
        public List<KrokMerania> KrokyMerania;

    }
}
