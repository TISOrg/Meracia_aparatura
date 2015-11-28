using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class CyklusMerania 
    {
        public CyklusMerania(int i)
        {
            cisloCyklu = i;
        }
        public int cisloCyklu { get; set; }
        
        private LinkedList<KrokMerania> kroky;
        public void pridajKrok(KrokMerania k)
        {
            kroky.AddLast(k);
        }
        public LinkedList<KrokMerania> getKroky()
        {
            return kroky;
        }

    }
}
