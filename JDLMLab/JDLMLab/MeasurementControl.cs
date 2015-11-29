using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace JDLMLab
{
    class MeasurementControl
    {
        /// <summary>
        /// Metoda nastartuje meranie s prednastavenymi parametrami.
        /// spusta sa v samostatnom vlakne. 
        /// </summary>
        public void start()
        {
            new Thread(this.startThread);   //vykonavame meranie v samostatnom threade
        }

        public int pocetCyklov {get; set; }
        public string typ { get; set; }
        private int pocetBodov { get; set; }
        public int pocetKrokov { get; private set; }
        public MeasurementParameters parameters { get; set; }
        public double krokNapatia { get; private set; }

        private void startThread()
        {
            //nakonfigurovat pristroje
            if (typ.Equals("EnergyScan"))
            {
                //start point,end point,cas na 1 krok -> TEM
                //cez AD


                //konstanta, resolution -> QMS
                //cez RS232

                pocetBodov = pocetKrokov + 1;
                krokNapatia = (parameters.endPoint - parameters.startPoint) / parameters.pocetKrokov;
                
            }
            if (typ.Equals("MassScan"))
            {
                //start,end,resolution,steptime ->QMS
                //konstanta -> TEM


                //pre massscan nacitat konstantu merania z voltmetra do hlavicky merania
                pocetBodov = (int)(parameters.endPoint - parameters.startPoint) / (parameters.stepTime) + 1;
            }
            //vykonat meranie podla zadaneho poctu cyklov, alebo nekonecne ak je pocet=0
            int pCyklus = 0;
            while (pCyklus<pocetCyklov || pocetCyklov==0)
            {
                //pre kazdy cyklus merania, urob vsetky body merania
                int pBod = 0;
                while (pBod<pocetBodov)
                {


                    //nacitaj detektor
                    //...


                    //ak je energy scan, urob krok, tj zvys eV na TEM o krokNapatia
                    double napatie = parameters.startPoint + (krokNapatia * pBod);
                    // class PristrojTEM.write(...

                    //vynuluj trigger v AD
                    //class AD.write(...

                    //cakaj cas t na nacitanie zaznameneho poctu TTL v AD
                    // wait(t)...


                    pBod++;
                }
                pCyklus++;
            }
        }
    }
    
}
