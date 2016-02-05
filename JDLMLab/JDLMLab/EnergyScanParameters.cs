using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    public class EnergyScanParameters
    {
        
        public EnergyScanParameters()
        {
        }
        public EnergyScanParameters(double startpoint,double endpoint,int constant,double steptime,int pocetkrokov)
        {            
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
            this.Constant = constant;
            this.StepTime = steptime;
            NumberOfSteps = pocetkrokov;
        }
        public int NumberOfSteps { get; set; }
        public double StartPoint { get; set; }
        public double EndPoint { get; set; }
        public int Constant { get; set; }
        public double StepTime { get; set; }
        
        public double KrokNapatia { get
            {
                return (EndPoint - StartPoint) / NumberOfSteps;
            }
        }

    }
            
}
    
