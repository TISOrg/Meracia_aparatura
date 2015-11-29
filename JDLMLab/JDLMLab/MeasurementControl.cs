using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;


namespace JDLMLab
{
    /// <summary>
    /// Autor: Jano
    /// Trieda, ktora riadi meranie, vola citania a zapisy pristrojov, vypocitava casy a pocet bodov pre merania, a vola ukladanie do databazy,a notifyuje graf
    /// </summary>
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
            Meranie meranie = new Meranie(parameters);
            
            int pCyklus = 0;
            while (pCyklus<pocetCyklov || pocetCyklov==0)
            {
                //pre kazdy cyklus merania, urob vsetky body merania
                int pBod = 0;
                Stopwatch watch = new Stopwatch();
                double napatie=0,prud=0,x=parameters.startPoint,y=parameters.constant;
                int teplota=0, tlakKapilara=0, tlakTPG=0, det=0;

                while (pBod<pocetBodov)
                {


                    //nacitaj detektor
                    //...

                    if (typ.Equals("2DScan"))
                    {
                        /////
                        //x=parameters.startPoint
                    }
                    else
                    {
                        //ak je energy scan, urob krok, tj zvys eV na TEM o krokNapatia
                        if (typ.Equals("EnergyScan"))
                        {
                            x = parameters.startPoint + (krokNapatia * pBod);

                            // class PristrojTEM.write(...

                            //vynuluj trigger v AD
                            //class AD.write(...

                        }
                        //mass scan, zvys krok na QMS
                        if (typ.Equals("MassScan"))
                        {


                            // class PristrojQMS.write(...
                            x = parameters.startPoint + (pBod);

                            //vynuluj trigger v AD
                            //class AD.write(...



                        }
                    }
                    //cakaj cas t na nacitanie zaznameneho poctu TTL v AD
                    // wait(t)...

                    //nacitaj TTL, 
                    //det=class ADDet.read()
                    det = 0;
                    //prud
                    prud = 0;
                    //napatie
                    napatie = 0;

                    //tlak1,tlak2,teplota kazdych x sekund, kde x je nastavene v global nastaveniach
                    if (watch.ElapsedMilliseconds > parameters.tlakKapilaryIntervalMerania)
                    {
                        //zatial je tento interval pre vsetky tri pristroje

                        // tlakKapilara = Class TLAK . read(...)
                        // tlakTPG = Class TlakTPG . read(...)
                        // teplota = Class Teplota . read(...)
                        watch.Restart();

                    }

                    meranie.addKrok(pCyklus, new KrokMerania(x, y, det, prud, tlakKapilara, tlakTPG, teplota));

                    pBod++;
                }
                pCyklus++;
            }
        }
    }
    
}
