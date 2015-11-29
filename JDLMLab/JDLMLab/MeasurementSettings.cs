﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class MeasurementParameters
    {
        public double startPoint { get; set; }
        public double endPoint { get; set; }
        public double resolution { get; set; }
        public double constant { get; set; }
        public int stepTime { get; set; }
        public string name { get; set; }
        public int pocetKrokov { get; set; }
    }
}
