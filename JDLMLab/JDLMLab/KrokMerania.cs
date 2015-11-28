using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class KrokMerania
    {
        public KrokMerania(int x,int y,int det,int current,int p1,int p2,int temperature)
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
        public int x { get; set; }
        public int y { get; set; }
        public int det { get; set; }
        public int current { get; set; }
        public int p1 { get; set; }
        public int p2 { get; set; }
        public int temperature { get; set; }
    }
}
