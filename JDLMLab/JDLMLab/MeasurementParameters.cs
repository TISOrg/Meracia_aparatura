using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    public class MeasurementParameters
    {
        public MeasurementParameters(string name, bool ionType, string note = "", int cycles = 0,bool test=false)
        {
            Name = name;
            Note = note;
            NumberOfCycles = cycles;
            IonType = ionType;
            TestRun = test;
        }
        public bool TestRun { get; set; }
        public int NumberOfCycles {get; set;}
        public string Name { get; set; }
        public string Note { get; set; }
        public bool IonType { get; internal set; }
        public double Resolution { get; set; }  //qms, pre vsetky typy merani
        public string Typ { get; set; }      

        public EnergyScanParameters EnergyScan { get; set; }
        public MassScanParameters MassScan { get; set; }

        public double StepTime
        {
            get
            {
                if (Typ.Equals("Energy Scan"))
                {
                    return EnergyScan.StepTime;
                }
                else if (Typ.Equals("Mass Scan"))
                {
                    return MassScan.StepTime;
                }
                else //2D scan
                {
                    return 0;
                }
            }
        }

        public int NumberOfSteps {
            get
            {
                if (Typ.Equals("Energy Scan"))
                {
                    return EnergyScan.NumberOfSteps;
                }
                else if (Typ.Equals("Mass Scan"))
                {
                    return MassScan.NumberOfSteps;
                }
                else
                {
                    //2D scan
                    return 0;
                }
            }
        }
        public void setParameters(string name,double resolution, int pocetcyklov=0, string note="")    //0 pre pocetcyklov znamena neobmedzene
        {
            Name = name;
            Note = note;
            NumberOfCycles = pocetcyklov;
            Resolution = resolution;
        }

        
    }
}

