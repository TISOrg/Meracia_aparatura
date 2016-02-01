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
            this.timePerAmu = timeperamu;
            Typ = "Mass Scan";
            init();
        }

        public MassScanParameters()
        {
        }

        public void init()
        {
            double x = (EndPoint - StartPoint) * Dens + 1;
            pb = Convert.ToInt32(x);
            steps = timePerAmu / Dens; 

        }

        public override int PocetBodov
        {
            get
            {
                return pb;// (int)((EndPoint - StartPoint) * Dens + 1);
            }
        }

        public double Steps
        {
            get
            {
                return steps;
            }
        }


        private int pb;
        public double timePerAmu;
        private double steps;
    }
}
