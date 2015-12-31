using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    //dominik napisal tuto poznmku, bez zmeny triedy
    class KrokMerania
    {
        public KrokMerania(double x, double y, int sig, double current, double kapillar, double chamber, double temperature)//int cyklus = 1)
        {
            this.x = x;
            this.y = y;
            this.sig = sig;
            this.current = current;
            this.kapillar = kapillar;
            this.chamber = chamber;
            this.temperature = temperature;
//            this.cyklus = cyklus;   //treba to tu??? hmm
            
        }
        public KrokMerania()
        {
        }

        public object[] Data
        {
            get
            {
                return new object[] {x,y,sig,current,chamber,kapillar,temperature
                };
            }
        }
        public object[] DataSCyklom(int i)
        {
            return new object[] { x, y, sig, current, chamber, kapillar, temperature, i };
        }

        public DataRow Datarow{
            get {
                DataRow r=new DataTable().NewRow();
                r.ItemArray = new object[] { x,y,sig,current,kapillar,chamber,temperature};
                return r;
            }
        }
        public DataRow DatarowForGraf
        {
            get
            {
                DataTable t = new DataTable();
                t.Columns.Add("x",typeof(double));
                t.Columns.Add("y",typeof(double));
                DataRow r =t.NewRow();
                r.ItemArray = new object[] { x, sig, };
                r["x"] = x;
                r["y"] = sig;
                return r;
            }
        }
        
        public double x { get; set; }
        public double y { get; set; }
        public int sig { get; set; }
        public double current { get; set; }
        public double  kapillar { get; set; }
        public double chamber { get; set; }
        public double temperature { get; set; }
        //public int cyklus { get; set; }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(x);
            s.Append(" ");
            s.Append(y);
            s.Append(" ");
            s.Append(sig); s.Append(" ");

            s.Append(current);
            s.Append(" ");
            s.Append(kapillar);
            s.Append(" ");
            s.Append(chamber);
            s.Append(" ");
            s.Append(temperature);
            s.Append("\n");
            return s.ToString();
        }
    }

}
