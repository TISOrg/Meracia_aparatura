using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
     class EnergyScanParameters : MeasurementParameters
    {
        
        public EnergyScanParameters()
        {

        }
        /// <summary>
        /// konstruktor vola aj init, lebo ma zadane potrebne udaje
        /// </summary>
        /// <param name="startpoint"></param>
        /// <param name="endpoint"></param>
        /// <param name="constant"></param>
        /// <param name="steptime"></param>
        /// <param name="pocetkrokov"></param>
        public EnergyScanParameters(double startpoint,double endpoint,double constant,double steptime,int pocetkrokov)
        {            
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
            this.Constant = constant;
            this.StepTime = steptime;
            this.PocetKrokov = pocetkrokov;
            
            Typ = "EnergyScan";
            init();
        }
        public void init()
        {
            kn = (EndPoint - StartPoint) / PocetKrokov;
        }
        
        public int PocetKrokov { get; set; }    //tem, pre energy scan
        public override int PocetBodov { get
            {
                return PocetKrokov+1;
            }
        }
        public double KrokNapatia { get
            {
                return kn;
            }
        }
        
        private double kn;
    }
            
}
    
