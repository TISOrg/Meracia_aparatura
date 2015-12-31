using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class MassScanParameters : MeasurementParameters
    {

        public MassScanParameters(double startpoint, double endpoint, double constant, double  steptime)
        {
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
            this.Constant = constant;
            this.StepTime = steptime;
            Typ = "MassScan";
            init();
        }

        public MassScanParameters()
        {
        }

        public void init()
        {
            pb = (EndPoint - StartPoint) / StepTime + 1;
        }

        public override int PocetBodov
        {
            get
            {
                return  (int)((EndPoint - StartPoint) / StepTime + 1);
            }
        }
        private double pb;
        
    }
}
