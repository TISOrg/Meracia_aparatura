using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    public abstract class MeasurementParameters
    {
        public MeasurementParameters()
        {

        }
        public bool TestRun { get; set; }
        public int PocetCyklov {get; set;}
        public string Name { get; set; }
        
        public string Note { get; set; }
        public double Resolution { get; set; }  //qms, pre vsetky typy merani

        public double StartPoint { get; set; }
        public double EndPoint { get; set; }
        public double Constant { get; set; }
        public double StepTime { get; set; }
        public string Typ { get; set; }
        public abstract int PocetBodov { get; }
        public void setParameters(string name,double resolution, int pocetcyklov=0, string note="")    //0 pre pocetcyklov znamena neobmedzene
        {
            Name = name;
            Note = note;
            PocetCyklov = pocetcyklov;
            Resolution = resolution;
        }

        //zrejme netreba nacitavat tu, ale kazdy prisrtoj si zoberie tu informaciu z properties...
        public string VoltmeterPortName { get { return Properties.Devices.Default.voltmeterPort; } }
        public string AmpermeterPortName { get { return Properties.Devices.Default.ampermeterPort; } }
        public string QMSPortName { get { return Properties.Devices.Default.qmsPort; } }
        public string TeplomerPortName { get { return Properties.Devices.Default.tempPort; } }
        public string TlakomerPR4000PortName { get { return Properties.Devices.Default.pr4000Port; } }
        public string TlakomerTPG256APortName { get { return Properties.Devices.Default.tpg256aPort; } }
        public int TeplomerFrekvenciaMerania { get { return Properties.Devices.Default.tempFreq; } }
        public int TlakomerPR4000FrekvenciaMerania { get { return Properties.Devices.Default.pr4000Freq; } }
        public int TlakomerTPG256AFrekvenciaMerania { get { return Properties.Devices.Default.tpg256aFreq; } }
        public int TlakomerTPG256AKanal { get { return Properties.Devices.Default.tpg256aChannel; } }
    }
}

