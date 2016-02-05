using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace JDLMLab
{
    /// <summary>
    /// Autor: Jano, Dominik(ano, aj sa som to robil :P )
    /// Trieda, ktora riadi meranie, vola citania a zapisy pristrojov, vypocitava casy a pocet bodov pre merania, a vola ukladanie do databazy,a notifyuje graf
    /// </summary>
    class MeasurementControl
    {
        int aktualneCisloCyklu;

        public MeasurementControl(MeasurementParameters mp)
        {
            Parameters = mp;
            ADPrevodnik = new NIDriver(Parameters.NumberOfSteps);   
        }
           

        DbCommunication db;
        private void vytvoritMeranievDB(MeasurementParameters mp)
        {   
            db.vytvoritNoveMeranie(mp);   
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
        NIDriver ADPrevodnik;

        public bool zastavitPoSkonceniCyklu {
            get; set;
        }

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
            // new Thread(this.startThread).Start();   //vykonavame meranie v samostatnom threade   

            //Graf.setParameters(Parameters.StartPoint, Parameters.EndPoint,Parameters.NumberOfSteps);   //inicializuj graf podla parametrov merania

            startThread();
        }
        public void stop()
        {
            db.close();
        }
         
        CyklusMerania aktualnyCyklus;

        private void startThread()
        {
            inicializujPristroje();
            ADPrevodnik.triggerInit(Parameters.StepTime);
            aktualneCisloCyklu = 1;

            while (Parameters.NumberOfCycles == 0 || aktualneCisloCyklu <= Parameters.NumberOfCycles)
            {
                vytvorNovyCyklus(aktualneCisloCyklu); //vytvori datovu strukturu CyklusMerania v strukture Meranie
                merajVAktualnomCykle(); //zacne meranie aktualneho cyklu

                if (zastavitPoSkonceniCyklu) break;
                aktualneCisloCyklu++;
            }

            //skoncili sa cykly, alebo user nastavil ze sa ma skoncit po ukonceni cyklu
            //ulozime do db
            //db.addMeranie(Meranie);
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
            //TemDriver.setPoint(Parameters.StartPoint);
        }

        private void inicializujQms()
        {
            //QmsDriver.setPoint(Parameters.StartPoint);
            
        }
        int cisloKroku { get; set; }
        public BufferedChart Graf { get; internal set; }

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
            double krok = (Parameters.EnergyScan.StartPoint); //ziskame zaciatocny krok = start point pre TEM
            Thread ADThread;
            //MessageBox.Show();
            while (cisloKroku < Parameters.NumberOfSteps)
            {

                KrokMerania = new KrokMerania();
                KrokMerania.X = krok;
                
                //ADPrevodnik.setAnalogOutput(krok);//.setPoint(krok);   //posle na TEM vypocitany bod
                 ADThread = new Thread(ADPrevodnik.CounterStart); //novy thread ad prevodnika
                ADThread.Start();  //nastartovanie prevodnika
                ///precitaj zatial vsetky ostatne pristroje
                // itaj vmeter
                ///citaj ameter...
                /// krokmerania.tlakomer=hodnota...
                
                
                ADThread.Join();   //cakas na skoncenie ADThreadu
             //   MessageBox.Show(cisloKroku.ToString());
                //vieme, ze AD prevodnik uz zapisal novu hodnotu intenzity
                KrokMerania.Intensity = ADPrevodnik.Intensity[cisloKroku];
                //zaznamenat 
             
                //Meranie.addKrok(aktualneCisloCyklu, KrokMerania);
                aktualnyCyklus.KrokyMerania.Add(KrokMerania);

                cisloKroku++;
                krok += (Parameters.EnergyScan.KrokNapatia);
            }
            string s = "";
            //foreach (KrokMerania i in aktualnyCyklus.getKroky())
            //{
            //    s += i.sig.ToString() + "\n";
            //}
            //MessageBox.Show(s);
            
            Graf.clear();
            Graf.init();
            //Graf.init();
           
            foreach(KrokMerania k in aktualnyCyklus.KrokyMerania)
            {
                Graf.addDataPoint(8, 8, k.Intensity);
            }

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
                return Parameters.EnergyScan.StartPoint + i * Parameters.EnergyScan.KrokNapatia;
            }
            else if (typ.Equals("2D Scan"))
            {
                return (Parameters.EnergyScan.StartPoint + i * Parameters.EnergyScan.KrokNapatia);
            }
            return 0;
            
        }
     
        



        private void vytvorNovyCyklus(int c)
        {
            aktualnyCyklus = new CyklusMerania(c);
        }

        private void nastavNaDalsiKrokMerania()
        {
           
        }
    }

}
