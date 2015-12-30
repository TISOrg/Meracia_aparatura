using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class MeasurementParameters
    {
        public MeasurementParameters()
        {

        }
        public int PocetCyklov {get; set;}
        public string Name { get; set; }
        public double tlakKapilaryIntervalMerania {
            get
            {
                return Properties.Devices.Default.pr4000Freq;
            }
        }
        public double tlakTPGIntervalMerania
        {
            get
            {
                return Properties.Devices.Default.tpg256aFreq;
            }
        }
        public double teplotaIntervalMerania {
            get
            {
                return Properties.Devices.Default.tempFreq;
            }
        }
        public string Note { get; set; }
        public double Resolution { get; set; }  //qms, pre vsetky typy merani

        public void setParameters(string name,double resolution, int pocetcyklov=-1, string note="")    //-1 pre pocetcyklov znamena neobmedzene
        {
            Name = name;
            Note = note;
            PocetCyklov = pocetcyklov;
            Resolution = resolution;
        }
        
        
    }
}
