using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class Scan2DParameters : MeasurementParameters
    {
        public Scan2DParameters()
        {

        }
        /// <summary>
        /// konstruktor ocakava parametre ktore uz maju potrebne hodnoty pre init. vola init obidvoch
        /// </summary>
        /// <param name="e"></param>
        /// <param name="m"></param>
        public Scan2DParameters(EnergyScanParameters e,MassScanParameters m)
        {
            EnergyScanParameters = e;
            MassScanParameters = m;
            Typ = "2DScan";
            init();
        }

        public void init()
        {
            EnergyScanParameters.init();
            MassScanParameters.init();
        }
        public override int PocetBodov
        {
            get
            {
                return 0;
            }
        }
        public EnergyScanParameters EnergyScanParameters { get; set; }
        public MassScanParameters MassScanParameters { get; set; }
    }
    
}
