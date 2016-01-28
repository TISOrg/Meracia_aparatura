using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class MassScanParameters : MeasurementParameters
    {

        public MassScanParameters(double startpoint, double endpoint, double constant, double  density,double timeperamu)
        {
            this.StartPoint = startpoint;
            this.EndPoint = endpoint;
            this.Constant = constant;
            this.Dens = density;
            this.TimeperAmu = timeperamu;
            Typ = "Mass Scan";
            init();
        }

        public MassScanParameters()
        {
        }

        public void init()
        {
            pb = (EndPoint - StartPoint) * Dens + 1;
        }

        public override int PocetBodov
        {
            get
            {
                return  (int)((EndPoint - StartPoint) * Dens + 1);
            }
        }
        private double pb;
        
    }
}
