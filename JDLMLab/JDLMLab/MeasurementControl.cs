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
            Parameters = mp;
            //vytvoritMeranievDB(mp);
            //vygenerovatSkusobne2dMerania(mp);
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
        /// v tomto parametri je vsetko k nastaveniam merania. viem zistit aj typ;
        /// </summary>
        public MeasurementParameters Parameters { get; set; }
        private Meranie Meranie { get; set; }
        private KrokMerania KrokMerania { get; set; }
        static VMeterDriver voltmeter = new VMeterDriver();
        static AMeterDriver ampermeter = new AMeterDriver();
        static TeplomerDriver teplomer = new TeplomerDriver();
        static TlakomerPR4000Driver tlakpr4000 = new TlakomerPR4000Driver();
        static TlakomerTG256ADriver tlak256 = new TlakomerTG256ADriver();
        static QmsDriver qms = new QmsDriver();

        DbCommunication database;
        public bool zastavitPoSkonceniCyklu {
            get; set; }

        string typ { get; set; }
        /// <summary>
        /// Metoda nastartuje meranie s prednastavenymi parametrami.
        /// spusta sa v samostatnom vlakne. 
        /// </summary>
        public void start()
        {
            db = new DbCommunication();
            db.open();
            db.vytvoritNoveMeranie(Parameters);

            typ = Parameters.Typ;
           
            new Thread(this.startThread).Start();   //vykonavame meranie v samostatnom threade
            
        }
        public void stop()
        {
            db.close();
        }

        private void startThread()
        {
            inicializujPristroje();
            int aktualnyCyklus = 1;
            while (Parameters.PocetCyklov == 0 || aktualnyCyklus <= Parameters.PocetCyklov)
            {
                vytvorNovyCyklus(); //vytvori datovu strukturu CyklusMerania v strukture Meranie
                merajVAktualnomCykle(); //zacne meranie aktualneho cyklu

                if (zastavitPoSkonceniCyklu) break;
                aktualnyCyklus++;
            }

            //skoncili sa cykly, alebo user nastavil ze sa ma skoncit po ukonceni cyklu
            //ulozime do db
            db.addMeranie(Meranie);
            stop(); 
        }

        /// <summary>
        /// podla typu merania nastavi pristrojom vsetky potrebne udaje
        /// </summary>
        private void inicializujPristroje()
        {
            inicializujQms();
            inicializujTem();
        }

        private void inicializujTem()
        {
            TemDriver.setPoint(Parameters.StartPoint);
        }

        private void inicializujQms()
        {
            QmsDriver.setPoint(Parameters.StartPoint);
            
        }
        int cisloKroku { get; set; }
        private void merajVAktualnomCykle()
        {
           
            if(typ.Equals("Mass Scan"))
            {
                /// v pripade mass  scan
                /// 
                /// Y - y je teraz sig. napatovy bod je konstantny, podla hodnoty parameters.constant
                /// ^ 
                /// |
                /// |
                /// |                 f(amu)=sig
                /// |                 |
                /// |                 |
                /// |     pre amu=3.7 |
                /// Y------------------------> X os (meni sa hmotnostny bod od start point do end point)
                /// 

            }
            else if(typ.Equals("Energy Scan"))
            {
                /// v pripade mass  scan
                /// 
                /// Y - y je teraz sig. hmotnostny bod je konstantny, podla hodnoty parameters.constant
                /// ^ 
                /// |
                /// |
                /// |                f(eV)=sig
                /// |                |
                /// |                |
                /// |     pre eV=7.2 |
                /// Y------------------------> X os (meni sa napatovy bod od start point do end point)
                /// 
                merajEnergyScanCyklus();
            }

            else if(typ.Equals("2D Scan"))
            {
                /// v pripade 2DSCan
                /// 
                /// Y napatovy bod
                /// ^ 
                /// |
                /// |eV--------[amu,ev]=sig
                /// |          |
                /// |          |
                /// |          |
                /// |         amu
                /// Y-------------------> X os (hmotnostny bod)
                /// 
                /// najprv prechadza cez x, pre dane y. Potom zvysi y a znova prechadza cez x
                /// 

            }

            
        }

        private void merajEnergyScanCyklus()
        {
            cisloKroku = 0;
            double krok = ((EnergyScanParameters)Parameters).StartPoint; //ziskame zaciatocny krok = start point pre TEM
            while (cisloKroku < ((EnergyScanParameters)Parameters).PocetBodov)
            {
                TemDriver.setPoint(krok);   //posle na TEM vypocitany bod

                //ADprevodnik. vynulujTrigger;
                Thread.Sleep((int)((EnergyScanParameters)Parameters).StepTime * 1000);    //pockame cas stanoveny v parametroch
                                                                                          //pocas cakania treba zistovat hodnoty na ampermetri //vymysliet ako to urobit,
                                                                                          // napirklad urobit vlakno alebo Task, a v nom cekovat kedy je AD prevodnik hotovy.  v hlavnom vlakne (tomto) ziskat merane hodnoty
                                                                                          // a nastavit eventHandler ktory bude zavolany z vytvoreneho vlakna, ked bude AD pripraveny.
                                                                                          // potom pokracovat v krokoch
                checkAD();
                //zaznamenat
                zapisKrokMerania();

                cisloKroku++;
                krok += ((EnergyScanParameters)Parameters).KrokNapatia;
            }
        }

        private void zapisKrokMerania()
        {
            KrokMerania.chamber = tlak256.read();
            //....atd pre ostatne pristroje
            //pre ampermeter asi nie.
        }

        /// <summary>
        /// toto by malo mozno v threade alebo tak testovat ci uz ad prevodnik prestal merat.
        /// </summary>
        private void checkAD()
        {
            throw new NotImplementedException();
        }

        private double vypocitajAktualnyKrok()
        {
            return vypocitajKrokPreTem(cisloKroku);
        }

        /// <summary>
        /// vrati aktualny napatovy krok pre i-ty krok
        /// </summary>
        /// <param name="i">kolkaty krok hladame</param>
        /// <returns></returns>
        private double vypocitajKrokPreTem(int i)
        {
            if (i < 0)
            {
                return 0;
            }
            if (typ.Equals("Energy Scan"))
            {
                return Parameters.StartPoint + i * ((EnergyScanParameters)Parameters).KrokNapatia;
            }
            else if (typ.Equals("2D Scan"))
            {
                return ((Scan2DParameters)Parameters).EnergyScanParameters.StartPoint + i * ((Scan2DParameters)Parameters).EnergyScanParameters.KrokNapatia;
            }
            return 0;
            
        }
         
        

        private void vytvorNovyCyklus()
        {
            throw new NotImplementedException();
        }

        private void nastavNaDalsiKrokMerania()
        {
            throw new NotImplementedException();
        }
    }

}
