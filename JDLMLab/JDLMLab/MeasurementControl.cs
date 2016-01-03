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
        public MeasurementControl(MeasurementParameters mp)
        {
            db = new DbCommunication();
            db.open();
            //vytvoritMeranievDB(mp);
            //vygenerovatSkusobne2dMerania(mp);
            db.close();
        }

        DbCommunication db;
        private void vytvoritMeranievDB(MeasurementParameters mp)
        {
            
            
            db.vytvoritNoveMeranie(mp);
            
        }

        private void vygenerovatSkusobneMerania(MeasurementParameters mp)
        {
            Meranie m = new Meranie(mp);
            m.addKrok(1, new KrokMerania(1, 5, 120, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(2, 5, 130, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(3, 5, 160, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(4, 5, 170, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(2, new KrokMerania(1, 5, 156, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(2, 5, 100, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(3, 5, 132, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(4, 5, 110, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(3, new KrokMerania(1, 5, 156, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(3, new KrokMerania(2, 5, 100, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(3, new KrokMerania(3, 5, 132, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(3, new KrokMerania(4, 5, 110, 3.4, 3.4, 6.7, 3.2));

            db.addCyklus(m.getCyklus(1));
            db.addCyklus(m.getCyklus(2));
            db.addCyklus(m.getCyklus(3));
            
        }

        private void vygenerovatSkusobne2dMerania(MeasurementParameters mp)
        {
            Meranie m = new Meranie(mp);
            m.addKrok(1, new KrokMerania(1, 5, 120, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(2, 5, 130, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(3, 5, 160, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(4, 5, 170, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(1, new KrokMerania(1, 6, 156, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(2, 6, 100, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(3, 6, 132, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(4, 6, 110, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(1, new KrokMerania(1, 7, 156, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(2, 7, 100, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(3, 7, 132, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(4, 7, 110, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(1, new KrokMerania(1, 8, 256, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(2, 8, 200, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(3, 8, 232, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(1, new KrokMerania(4, 8, 210, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(2, new KrokMerania(1, 5, 120, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(2, 5, 130, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(3, 5, 160, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(4, 5, 170, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(2, new KrokMerania(1, 6, 156, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(2, 6, 100, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(3, 6, 132, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(4, 6, 110, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(2, new KrokMerania(1, 7, 156, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(2, 7, 100, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(3, 7, 132, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(4, 7, 110, 3.4, 3.4, 6.7, 3.2));

            m.addKrok(2, new KrokMerania(1, 8, 256, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(2, 8, 200, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(3, 8, 232, 3.4, 3.4, 6.7, 3.2));
            m.addKrok(2, new KrokMerania(4, 8, 210, 3.4, 3.4, 6.7, 3.2));


            db.addCyklus(m.getCyklus(1));
            db.addCyklus(m.getCyklus(2));
            

        }

        /// <summary>
        /// Metoda nastartuje meranie s prednastavenymi parametrami.
        /// spusta sa v samostatnom vlakne. 
        /// </summary>
        public void start()
        {
            new Thread(this.startThread);   //vykonavame meranie v samostatnom threade
        }

        public int pocetCyklov { get; set; }
        public string typ { get; set; }
        private int pocetBodov { get; set; }
        public int pocetKrokov { get; private set; }
        public MeasurementParameters parameters { get; set; }
        public double krokNapatia { get; private set; }

        private void startThread()
        {
            //zisti typ
            //nakonfigurovat pristroje
            if (typ.Equals("EnergyScan"))
            {
                //start point,end point,cas na 1 krok -> TEM
                //cez AD

                //konstanta, resolution -> QMS
                //cez RS232

                pocetBodov = pocetKrokov + 1;
                //krokNapatia = (parameters.EndPoint - parameters.StartPoint) / parameters.pocetKrokov;
            }
            if (typ.Equals("MassScan"))
            {
                //start,end,resolution,steptime ->QMS
                //konstanta -> TEM


                //pre massscan nacitat konstantu merania z voltmetra do hlavicky merania

            }
            if (typ.Equals("2DScan"))
            {

            }
            meraj();
        }
        int teplota = 0, tlakKapilara = 0, tlakTPG = 0, det = 0;
        double napatie = 0, prud = 0, x, y;
        Meranie meranie;
        Stopwatch watch = new Stopwatch();

        private void meraj()
        {
            //vykonat meranie podla zadaneho poctu cyklov, alebo nekonecne ak je pocet=0
            meranie = new Meranie(parameters);
            int pCyklus = 0;
            while (pCyklus < pocetCyklov || pocetCyklov == 0)
            {
                //pre kazdy cyklus merania, urob vsetky body merania
                int pBod = 0;
                x = parameters.StartPoint; y = parameters.Constant;
                while (pBod < pocetBodov)
                {
                    zmerajBod(pBod);
                    pBod++;
                }
                meranie.addKrok(pCyklus, new KrokMerania(x, y, det, prud, tlakKapilara, tlakTPG, teplota));
                pCyklus++;
            }
        }

        private void zmerajBod(int pBod)
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
                    x = parameters.StartPoint + (krokNapatia * pBod);

                    // class PristrojTEM.write(...

                    //vynuluj trigger v AD
                    //class AD.write(...

                }
                //mass scan, zvys krok na QMS
                if (typ.Equals("MassScan"))
                {
                    // class PristrojQMS.write(...
                    x = parameters.StartPoint + (pBod);

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
            if (watch.ElapsedMilliseconds > parameters.TlakomerTPG256AFrekvenciaMerania)
            {
                //zatial je tento interval pre vsetky tri pristroje
                // tlakKapilara = Class TLAK . read(...)
                // tlakTPG = Class TlakTPG . read(...)
                // teplota = Class Teplota . read(...)
                watch.Restart();
            }



        }

     
    }

}
