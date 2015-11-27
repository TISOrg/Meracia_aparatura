using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{   /// <summary>
    /// Zdedena trieda pre energyScan, obsahuje navyse numberOfSteps
    /// Autor Jano
    /// </summary>
    /// 
    class EnergyScanMeranie :  Meranie
    {
        public EnergyScanMeranie(string name, int startPoint, int endPoint, int constant, int resolution, int stepTime, string note, int cycles,int numberOfSteps) : base(name, startPoint, endPoint, constant, resolution, stepTime, note, cycles)
        {
            this.numberOfSteps = numberOfSteps;
        }
        public int numberOfSteps { get; set; }
    }
}
