using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace JDLMLab
{
    /// <summary>
    ///  Trieda pre jedno meranie
    /// Autor - Jano
    /// </summary>
    class Meranie
    {
        public MeasurementParameters Parameters { get; private set; }

        public Meranie(MeasurementParameters parameters)
        {
            this.Parameters = parameters;
            cykly = new List<CyklusMerania>(parameters.PocetCyklov);

        }
        public List<CyklusMerania> cykly {get; set; }
        
    }
}
