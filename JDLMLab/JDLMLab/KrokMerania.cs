﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    //dominik napisal tuto poznmku, bez zmeny triedy
    class KrokMerania
    {
        public KrokMerania(double x, double y, ulong intensity, double current, double kapillar, double chamber, double temperature)
        {
            this.X = x;
            this.Y = y;
            this.Intensity = intensity;
            this.Current = current;
            this.Capillar = kapillar;
            this.Chamber = chamber;
            this.Temperature = temperature;
        }
        public KrokMerania()
        {
        }
        
        public double X { get; set; }
        public double Y { get; set; }
        public ulong Intensity { get; set; }
        public double Current { get; set; }
        public double  Capillar { get; set; }
        public double Chamber { get; set; }
        public double Temperature { get; set; }
        //public int cyklus { get; set; }
        
    }

}
