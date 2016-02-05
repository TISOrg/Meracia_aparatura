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
        public MeasurementControl(MeasurementParameters mp,Main mainForm)
        {
            Parameters = mp;
            ADPrevodnik = new NIDriver(Parameters.NumberOfSteps);
            this.mainForm = mainForm; 
        }

        Main mainForm { get; set; }
        public BufferedChart Graf { get; internal set; }
        DbCommunication db;
        private void vytvoritMeranievDB(MeasurementParameters mp)
        {   
            db.vytvoritNoveMeranie(mp);   
        }

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

        string typ { get; set; }

        /// <summary>
        /// Metoda nastartuje meranie s prednastavenymi parametrami.
        /// </summary>
        public void start()
        {
            if (!Parameters.TestRun)
            {
                db = new DbCommunication();
                db.open();
                db.vytvoritNoveMeranie(Parameters);
            }
            typ = Parameters.Typ;
            Graf.setParameters(Parameters.EnergyScan.StartPoint, Parameters.EnergyScan.EndPoint, Parameters.NumberOfSteps + 1, Parameters.NumberOfCycles);
            new Thread(this.startThread).Start();   //vykonavame meranie v samostatnom threade   
        }

        CyklusMerania aktualnyCyklus;
        int currentCycleNum;
        int cisloKroku;
        private void startThread()
        {
            inicializujPristroje();
            currentCycleNum = 1;
            while (Parameters.NumberOfCycles == 0 || currentCycleNum <= Parameters.NumberOfCycles)
            {
                aktualnyCyklus = new CyklusMerania(currentCycleNum); //vytvori datovu strukturu CyklusMerania
                merajAktualnyCyklus(); //zacne meranie aktualneho cyklu
                if(!Parameters.TestRun) db.addCyklus(aktualnyCyklus);//ulozime aktualne namerany cyklus do db
                if (mainForm.stopAfterCycleChecked) break;  //stlacil user checkbox zastavit???
                currentCycleNum++;
            }
            //skoncili sa cykly, alebo user nastavil ze sa ma skoncit po ukonceni cyklu
            if (!Parameters.TestRun)
            {
                //db.addMeranie(Meranie);
                stop();
            }
            
            //skoncili sme meranie, vypiseme nejaku haluz, povolime spustenie noveho merania atd...

        }

        public void stop()
        {
            if (!Parameters.TestRun) db.close();
            ADPrevodnik.UlohaCounter.Dispose();
        }

        /// <summary>
        /// podla typu merania nastavi pristrojom vsetky potrebne udaje
        /// </summary>
        private void inicializujPristroje()
        {
            inicializujQms();
            inicializujTem();
            ADPrevodnik.triggerInit(Parameters.StepTime);
        }

        private void inicializujTem()
        {
            //TemDriver.setPoint(Parameters.StartPoint);
        }

        private void inicializujQms()
        {
            //QmsDriver.setPoint(Parameters.StartPoint);
            
        }
        private void merajAktualnyCyklus()
        {
            mainForm.setCurrentCycle(currentCycleNum.ToString());
            Graf.clear();
            if (typ.Equals("Mass Scan")) { merajMassScanCyklus(); }
            else if(typ.Equals("Energy Scan")){merajEnergyScanCyklus();}
            else if(typ.Equals("2D Scan")){ meraj2DScanCyklus(); }     
        }
        private void merajMassScanCyklus()
        {

        }

        private void merajEnergyScanCyklus()
        {
            cisloKroku = 0;
            double krok = (Parameters.EnergyScan.StartPoint); //ziskame zaciatocny krok = start point pre TEM
            Thread ADThread;
            
            while (cisloKroku <= Parameters.NumberOfSteps)
            {
                mainForm.setCurrentStep(cisloKroku.ToString() + "/" + Parameters.NumberOfSteps.ToString());
                KrokMerania = new KrokMerania();
                //ADPrevodnik.setAnalogOutput(krok);//.setPoint(krok);   //posle na TEM vypocitany bod
                ADThread = new Thread(ADPrevodnik.CounterStart); //novy thread ad prevodnika
                ADThread.Start();  //nastartovanie prevodnika
                ///precitaj zatial vsetky ostatne pristroje
                KrokMerania.Current = 5.2;
                KrokMerania.Capillar = 10;
                KrokMerania.Chamber = 11;
                KrokMerania.Temperature = 4.8;
                KrokMerania.Y = 4;
                KrokMerania.X = krok;   //potom nebudeme zapisovat prepokladany krok, ale odmerany z voltmetra
                ADThread.Join();   //cakas na skoncenie ADThreadu
                //vieme, ze AD prevodnik uz zapisal novu hodnotu intenzity
                KrokMerania.Intensity = ADPrevodnik.Intensity;
                //zaznamenat 
             
                aktualnyCyklus.KrokyMerania.Add(KrokMerania);
                lock (Graf)
                {
                    Graf.addDataPoint(KrokMerania.X, KrokMerania.Y, KrokMerania.Intensity);
                }
                
                cisloKroku++;
                krok = (Parameters.EnergyScan.StartPoint)+cisloKroku*Parameters.EnergyScan.KrokNapatia;
            }
        }
        private void meraj2DScanCyklus()
        {

        }



    }

}
