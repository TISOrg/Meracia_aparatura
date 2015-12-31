using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class CyklusMerania 
    {
        public CyklusMerania(int i)
        {
            kroky = new List<KrokMerania>();
            cisloCyklu = i;
        }
        public int cisloCyklu { get; set; }
        
        public DataTable Table {
            get
            {
                DataTable t = new DataTable();
                t.Columns.Add("x", typeof(double));
                t.Columns.Add("y", typeof(double));
                t.Columns.Add("sig", typeof(double));
                t.Columns.Add("current", typeof(double));
                t.Columns.Add("chamber", typeof(double));
                t.Columns.Add("kapillar", typeof(double));
                t.Columns.Add("temperature", typeof(double));
                t.Columns.Add("cycle_num", typeof(Int32));
                foreach(KrokMerania k in kroky)
                {
                    DataRow r = t.NewRow();
                    r.ItemArray=k.DataSCyklom(cisloCyklu);
                    t.ImportRow(r);
                }
                return t;
            }
        }
        public DataTable TableForGraf
        {
            get
            {
                DataTable t = new DataTable(cisloCyklu.ToString());
                t.Columns.Add("x", typeof(double));
                t.Columns.Add("y", typeof(double));
                foreach (KrokMerania k in kroky)
                {
                    DataRow r = t.NewRow();
                    t.ImportRow(k.DatarowForGraf);
                }
                return t;
            }
        }
        private List<KrokMerania> kroky;
        public void pridajKrok(KrokMerania k)
        {
                kroky.Add(k);
        }
        public List<KrokMerania> getKroky()
        {
            return kroky;
        }

    }
}
