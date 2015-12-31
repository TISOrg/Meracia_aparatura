using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class VMeterController
    {
        VMeterDriver driver;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="casCitania">cas ako casto ma citat napatie. Vyplyva z parametru merania PocetKrokov,PocetBodov,ci?</param>
        public VMeterController(double casCitania)
        {
            driver = new VMeterDriver();
            CasCitania = casCitania;
            Queue = new Queue<double>();
             
        }
        public Queue<double> Queue {
            get; private set; }

        public double CasCitania { get; set; }

        internal VMeterDriver VMeterDriver
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        /// <summary>
        /// metoda spusti citanie voltmetra kazdych CasCitania sekund, a vysledky dava do??? 
        /// Malo by to byt asi v threade
        /// </summary>
        public void start()
        {
            double napatie=Convert.ToDouble(driver.read());
            Queue.Enqueue(napatie);
        }

        /// <summary>
        /// jednorazove precitanie hodnoty z voltmetra
        /// </summary>
         public double getValue()
        {
            return Convert.ToDouble(driver.read());
        }   


    }
}
