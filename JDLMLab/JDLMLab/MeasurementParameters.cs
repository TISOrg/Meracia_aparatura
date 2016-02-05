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
        public bool testRun { get; set; }
        public int PocetCyklov {get; set;}
        public string Name { get; set; }
        public string Note { get; set; }
        public double Resolution { get; set; }  //qms, pre vsetky typy merani
        public string Typ { get; set; }
        public bool IonType { get; internal set; }

        public double StartPoint { get; set; }
        public double EndPoint { get; set; }
        public double Constant { get; set; }
        public double StepTime { get; set; }
        public double Dens { get; set; }
        //public double TimeperAmu { get; set; }
        
        public abstract int PocetBodov { get; }
        
        public void setParameters(string name,double resolution, int pocetcyklov=0, string note="")    //0 pre pocetcyklov znamena neobmedzene
        {
            Name = name;
            Note = note;
            PocetCyklov = pocetcyklov;
            Resolution = resolution;
        }

        
    }
}

