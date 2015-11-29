using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class KrokMerania
    {
        public KrokMerania(double x,double y,int det,double current,int p1,int p2,int temperature)
        {
            this.x = x;
            this.y = y;
            this.det = det;
            this.current = current;
            this.p1 = p1;
            this.p2 = p2;
            this.temperature = temperature;
        }
        public KrokMerania()
        {
        }
        public double x { get; set; }
        public double y { get; set; }
        public int det { get; set; }
        public double current { get; set; }
        public int p1 { get; set; }
        public int p2 { get; set; }
        public int temperature { get; set; }

        public string toString()
        {
            StringBuilder s = new StringBuilder();
            s.Append(x);
            s.Append(" ");
            s.Append(y);
            s.Append(" ");
            s.Append(det);s.Append(" ");

            s.Append(current);
            s.Append(" ");
            s.Append(p1);
            s.Append(" ");
            s.Append(p2);
            s.Append(" ");
            s.Append(temperature);
            s.Append("\n");
            return s.ToString();
        }
    }

}
