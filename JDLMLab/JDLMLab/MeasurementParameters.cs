using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class MeasurementParameters
    {
        public int pocetCyklov {get; set;}
        public double startPoint { get; set; }
        public double endPoint { get; set; }
        public double resolution { get; set; }
        public double constant { get; set; }
        public int stepTime { get; set; }
        public string name { get; set; }
        public string typ { get; set; }
        public int pocetKrokov { get; set; }
        public double tlakKapilaryIntervalMerania { get; set; }
        public double tlakTPGIntervalMerania { get; set; }
        public double teplotaIntervalMerania { get; set; }
        public string note { get; set; }
    }
}
