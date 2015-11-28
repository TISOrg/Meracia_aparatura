using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    /// <summary>
    ///  Trieda pre jednu hlavicku merania
    /// Autor - Jano
    /// </summary>
    class Meranie
    {
        public Meranie(string name,int startPoint,int endPoint,int constant,int resolution,int stepTime,string note,int cycles)
        {
            this.name = name;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.name = name;
            this.constant = constant;
            this.resolution = resolution;
            this.stepTime = stepTime;
            this.note = note;
            this.cycles = cycles;

        }
        public Meranie(string name, string typMerania, int startPoint, int endPoint, int constant, int resolution, int stepTime, string note)
        {
            this.name = name;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.name = name;
            this.constant = constant;
            this.resolution = resolution;
            this.stepTime = stepTime;
            this.note = note;
            this.cycles = 0;    //nula bude reprezentovat nekonecne vela cyklov.

        }
        public string note { get; set; }
        public string name { get; set; }
        public DateTime datetime
        {
            get; private set;
        }
        public int startPoint {
            get; set; }
        public int endPoint {
            get; set;
        }
        public int constant {
            get; set; }
        public int resolution {
            get; set; }
        public int stepTime {
            get; set;
        }
        public int cycles {
            get; set;
        }
        public string header { get; set; }
        public List<CyklusMerania> cykly {get; set; }
        public void pridajCyklus(CyklusMerania c)
        {
            cykly.Add(c);            
        }
        public CyklusMerania getCyklus(int i) { return cykly[i]; }
        public void addKrok(int cyklus,KrokMerania k) 
        {
            cykly[cyklus].pridajKrok(k);
        }
    }
}
