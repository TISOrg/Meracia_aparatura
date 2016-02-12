using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    public class MassScanParameters
    {

        public MassScanParameters(int startpoint, int endpoint, double constant, double  density,double timeperamu)
        {
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
            this.Constant = constant;
            this.Density = density;
            this.TimePerAmu = timeperamu;
        }
        public MassScanParameters()
        {
        }
        public double StepTime { get
            {
                return TimePerAmu / Density;
            }
        }
        public double Step
        {
            get {return 1/Density;}
            

        }
        public int NumberOfSteps
        {
            get
            {
                double x = (EndPoint - StartPoint) * Density + 1;
                return Convert.ToInt32(x);
            }
        }

        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
        public double Constant { get; set; }
        public double Density { get; set; }
        public double TimePerAmu{ get; set; }
    }
}
