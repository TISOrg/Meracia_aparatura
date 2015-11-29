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
        
        private List<KrokMerania> kroky;
        public void pridajKrok(KrokMerania k)
        {
            try
            {
                kroky.Add(k);
            }
            catch(NullReferenceException e)
            {
                kroky = new List<KrokMerania>();
                kroky.Add(k);
            }
            
        }
        public List<KrokMerania> getKroky()
        {
            return kroky;
        }

    }
}
