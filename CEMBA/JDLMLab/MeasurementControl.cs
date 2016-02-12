using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
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
            showCurrent = true;
            Parameters = mp;
            ADPrevodnik = new NIDriver(Parameters.NumberOfSteps);
            this.mainForm = mainForm;
            showCurrent = true;
        }

        public MeasurementControl()
        {
            // TODO: Complete member initialization
        }

        Main mainForm { get; set; }
        public BufferedChart Graf { get; internal set; }
        DbCommunication db;

        public MeasurementParameters Parameters { get; set; }

        static VMeterDriver voltmeter = new VMeterDriver();
        static AMeterDriver ampermeter = new AMeterDriver();
        static TeplomerDriver teplomer = new TeplomerDriver();
        static TlakomerPR4000Driver tlakpr4000 = new TlakomerPR4000Driver();
        static TlakomerTG256ADriver tlak256 = new TlakomerTG256ADriver();
        static QmsDriver qms = new QmsDriver();
        NIDriver ADPrevodnik;
        Thread measuringThread;
        /// <summary>
        /// Metoda nastartuje meranie s prednastavenymi parametrami.
        /// </summary>
        public void start()
        {
            //voltmeter.open();
            //voltmeter.read();
            //Thread.Sleep(1000);
            //MessageBox.Show(voltmeter.LastValue.ToString());
            //voltmeter.close();
            //return;
            abortStatus = false;
            if (!Parameters.TestRun)
            {
                db = new DbCommunication();
                db.open();
                db.vytvoritNoveMeranie(Parameters);
                db.close();
                db.Cycle = 1;
            }
            if (Parameters.Typ.Equals("Mass Scan")) { Graf.setParameters(Parameters.MassScan.StartPoint, Parameters.MassScan.EndPoint, Parameters.NumberOfSteps + 1, Parameters.NumberOfCycles); }
            else if (Parameters.Typ.Equals("Energy Scan")) { Graf.setParameters(Parameters.EnergyScan.StartPoint, Parameters.EnergyScan.EndPoint, Parameters.NumberOfSteps + 1, Parameters.NumberOfCycles); }
            else if (Parameters.Typ.Equals("2D Scan")) { }     
            
            measuringThread = new Thread(this.startThread);
            measuringThread.Name = "Measuring thread";
            measuringThread.Start();   //vykonavame meranie v samostatnom threade   

        }
        public bool isMeasuring { get {
            try
            {
                return measuringThread.IsAlive;
            }
            catch (Exception)
            {
                return false;
            }
        } }
        /// <summary>
        /// metoda ma zatvorit vsetky pristroje s ktorymi pracuje a ukoncit vsetky thready ktore mozu byt spustene.
        /// </summary>
        public void stop()
        {
            stopDevices();
            if (!Parameters.TestRun) db.close();
            if(measuringThread.ThreadState==System.Threading.ThreadState.Running)
                ADPrevodnik.UlohaCounter.Dispose();

            ADPrevodnik.StartSignal.Dispose();
            
            mainForm.meranieSkoncilo();

        }

        private void collectData()
        {
            for (int j = 0; j < Parameters.NumberOfCycles; j++)
            {

                for (int i = 0; i < Parameters.NumberOfSteps + 1; i++)
                {
                    CyklusMerania c = new CyklusMerania(j+1);
                    KrokMerania k = new KrokMerania();
                    k.X = Parameters.MassScan.StartPoint + i * Parameters.MassScan.Step;
                    k.Y = Parameters.MassScan.Constant;
                    k.Chamber = 0;
                    k.Capillar = tlak256.readNext();
                    k.Temperature = teplomer.readNext();
                    k.Intensity = intensities[i];
                    c.KrokyMerania.Add(k);

                    CurrentMeasurement.cykly.Add(c);
                }
            }
            db.open();
            db.addMeranie(CurrentMeasurement);
            db.close();
         
        }

        public void abort()
        {
            try
            {
                abortStatus = true;
                ADThread.Abort();
                ADPrevodnik.UlohaCounter.Dispose();
               
                teplomer.stopReading();
                teplomer.close();
                tlak256.stopReading();
                tlak256.close();

                voltmeter.close();
                ampermeter.close();

                measuringThread.Abort();
                if (!Parameters.TestRun)
                {
                    db.addCyklus(aktualnyCyklus);
                    db.close();
                }
                mainForm.meranieSkoncilo();
            }
            catch(Exception){
                
            }
            
        }
        private void stopDevices()
        {
            
            voltmeter.close();
            ampermeter.close();
            teplomer.stopReading();
            teplomer.close();
            tlak256.stopReading();
            tlak256.close();
            
            //tlakpr4000.stopReading(); // !!!, asi bude ina, lebo je to na AD
            
        }

        private Meranie CurrentMeasurement { get; set; }
        public Meranie OldMeasurement { get; set; }
        CyklusMerania aktualnyCyklus;
        private KrokMerania KrokMerania { get; set; }
        int currentCycleNum;
        int cisloKroku;
        /// <summary>
        /// podla typu merania nastavi pristrojom vsetky potrebne udaje
        /// </summary>
        private void inicializujPristroje()
        {
            ADPrevodnik.triggerInit(Parameters.StepTime);
            inicializujQms();
            inicializujTem();
            teplomer.open();
            tlak256.open();
            ampermeter.open();
            voltmeter.open();
            teplomer.setTimer();
            tlak256.setTimer();
        }
        ManualResetEvent cakac = new ManualResetEvent(false);
        
        private void massScanreader()
        {
            int cyklusNum=0;
            while(cyklusNum<Parameters.NumberOfCycles)
            {
                int lokalCisloKroku = 0;
                if (currentCycleNum != 1) { Graf.nextCycle(); }
                while (lokalCisloKroku < Parameters.MassScan.NumberOfSteps+1)
                {
                    Thread.Sleep((int)(Parameters.MassScan.StepTime*1000));
                    double X = Parameters.MassScan.StartPoint + cisloKroku * Parameters.MassScan.Step;
                    try
                    {
                        lock (Graf)
                        {
                            if (showCurrent)
                            {
                                if (lokalCisloKroku > cisloKroku) throw new Exception();

                                Graf.addDataPoint(X, Parameters.MassScan.Constant, intensities[lokalCisloKroku], currentCycleNum - 1);
                                lokalCisloKroku++;
                            }
                            mainForm.setCurrentStep((cisloKroku + 1).ToString() + "/" + (Parameters.NumberOfSteps + 1).ToString());
                        }
                    }
                    catch (Exception) { }
                }
                cyklusNum++;
            }
        }

        private void startThread()
        {
            inicializujPristroje();
            currentCycleNum = 1;
            CurrentMeasurement = new Meranie(Parameters);

            if (Parameters.Typ.Equals("Mass Scan"))
            {
                massScan();
            }
            else
            {

                while (Parameters.NumberOfCycles == 0 || currentCycleNum <= Parameters.NumberOfCycles)
                {
                    if (currentCycleNum != 1) { Graf.prepareNextCycle(); }
                    aktualnyCyklus = new CyklusMerania(currentCycleNum); //vytvori datovu strukturu CyklusMerania
                    merajAktualnyCyklus(); //zacne meranie aktualneho cyklu

                    CurrentMeasurement.cykly.Add(aktualnyCyklus);  //lokalna struktura
                    if (mainForm.stopAfterCycleChecked) break;  //stlacil user checkbox zastavit???         
                    currentCycleNum++;
                }
                //skoncili sa cykly, alebo user nastavil ze sa ma skoncit po ukonceni cyklu
                if (!Parameters.TestRun)
                {
                    db.open();
                    db.addMeranie(CurrentMeasurement);
                    db.close();
                }
                stop();
            }
            
            //skoncili sme meranie, vypiseme nejaku haluz, povolime spustenie noveho merania atd...
        }

        private void massScan()
        {
            ADPrevodnik.setAnalogOutput(Parameters.MassScan.Constant);
            Thread.Sleep(500);
            voltmeter.read();
            ampermeter.read();
            Thread.Sleep(50);
            Parameters.MassScan.Constant = voltmeter.LastValue;
            
            startSignalEvent = new ManualResetEvent(false);
            ADPrevodnik.resetFlipFlop();
            
            intensities = new List<ulong>(Parameters.NumberOfSteps+1);
            // tlak256.startReading();
            // teplomer.startReading();
            // voltmeter.startReading();
            // ampermeter.IntervalMerania = (int)(Parameters.MassScan.StepTime * 1000);
            // ampermeter.setTimer();
            // ampermeter.startReading();
            new Thread(massScanreader).Start();

            cisloKroku = 0;
            while (Parameters.NumberOfCycles == 0 || currentCycleNum <= Parameters.NumberOfCycles)
            {
                ADWaitStart = new Thread(ADPrevodnik.startSignal);
                ADWaitStart.Start(startSignalEvent);     //start thread, ktory sleduje start signal z QMS
                startSignalEvent.WaitOne();            //cakaj na signal.
                merajMassScanCyklus(); //zacne meranie aktualneho cyklu
                if (mainForm.stopAfterCycleChecked) break;  //stlacil user checkbox zastavit???         
                currentCycleNum++;
            }
            //skoncili sa cykly, alebo user nastavil ze sa ma skoncit po ukonceni cyklu
            massStop();          
        }

        private void massStop()
        {
            /*
            teplomer.stopReading();
            tlak256.stopReading();
            ampermeter.stopReading();
            */
            ampermeter.close();      
            teplomer.close();   
            tlak256.close();
            voltmeter.close();
            
            collectData();
            ADPrevodnik.UlohaCounter.Dispose();
            
            mainForm.meranieSkoncilo();
          
        }

        private void inicializujTem()
        {
            //TemDriver.setPoint(Parameters.StartPoint);
        }

        private void inicializujQms()
        {   
            //QmsDriver.setPoint(Parameters.StartPoint);
            //nastavit o jedna vacsi krok pre stihnutie dalsieho start signalu
            double novaHodnota;
            if(Parameters.Typ.Equals("Mass Scan")){

                novaHodnota=(0.1/Parameters.MassScan.TimePerAmu>0.01) ? Math.Round((Parameters.EndPoint+0.1/Parameters.MassScan.TimePerAmu),2) : Parameters.EndPoint+0.01;

                //zistit ci je zapnuty QMS,
                //ADPrevodnik.checkQMS(

            }
            //qms.send(novahondota)
        }
        private void merajAktualnyCyklus()
        {
            if (Parameters.Typ.Equals("Mass Scan")) { merajMassScanCyklus(); }
            else if(Parameters.Typ.Equals("Energy Scan")){merajEnergyScanCyklus();}
            else if(Parameters.Typ.Equals("2D Scan")){ meraj2DScanCyklus(); }     
        }
        Thread ADWaitStart;
        private ManualResetEvent startSignalEvent;


        List<ulong> intensities;
        private void merajMassScanCyklus()
        {
            double krok = (Parameters.MassScan.StartPoint); //ziskame zaciatocny krok = start point pre TEM
            //tu cakaj na statstignal
            //zastav current thread az kym nedostane signal
            while (cisloKroku <= Parameters.NumberOfSteps)
            {
                if (abortStatus)
                {
                    break;
                }
                ADThread = new Thread(ADPrevodnik.CounterStart); //novy thread ad prevodnik                
                ADThread.Start();  //nastartovanie prevodnika
                ADThread.Join();   //cakas na skoncenie ADThreadu
                intensities.Add(ADPrevodnik.Intensity);
                cisloKroku++;
            }
            intensities.Clear();
            cisloKroku = 0;

        }
        Thread ADThread;
        private void merajEnergyScanCyklus()
        {
            cisloKroku = 0;
            double krok = (Parameters.EnergyScan.StartPoint); //ziskame zaciatocny krok = start point pre TEM
            //teplomer a tlakomery chceme citat iba kazdych n sekund;
            ADPrevodnik.setAnalogOutput(krok);
            voltmeter.read();
            ampermeter.read();
            Thread.Sleep(500);
            voltmeter.read();
            ampermeter.read();
            Thread.Sleep(50);

            tlak256.read();
            tlak256.startReading();
            teplomer.read();
            teplomer.startReading();
            
            while (cisloKroku <= Parameters.NumberOfSteps)
            {
                if (abortStatus)
                {
                    break;
                }
                KrokMerania = new KrokMerania();
                ADPrevodnik.setAnalogOutput(krok);//.setPoint(krok);   //posle na TEM vypocitany bod
                
                ADThread = new Thread(ADPrevodnik.CounterStart); //novy thread ad prevodnika
                ADThread.IsBackground = true;
                ADPrevodnik.setAnalogOutput(krok);
                ADThread.Start();  //nastartovanie prevodnika
                //precitaj zatial vsetky ostatne pristroje
                
                voltmeter.read();
                ampermeter.read(); 

                ADThread.Join();   //cakas na skoncenie ADThreadu
                //vieme, ze AD prevodnik uz zapisal novu hodnotu intenzity
                KrokMerania.Intensity = ADPrevodnik.Intensity;
                KrokMerania.Current = ampermeter.LastValue;
                KrokMerania.X = voltmeter.LastValue;
                KrokMerania.Y = Parameters.EnergyScan.Constant;
                KrokMerania.Temperature = teplomer.readNext();
                KrokMerania.Capillar = tlak256.readNext();
                KrokMerania.Chamber = 0;
                KrokMerania.StepNumber = cisloKroku+1;

                //zaznamenat 
                aktualnyCyklus.KrokyMerania.Add(KrokMerania);
                lock (Graf)
                {
                    if (showCurrent)
                    {
                        Graf.addDataPoint(KrokMerania.X, KrokMerania.Y, KrokMerania.Intensity, currentCycleNum - 1);
                        
                    }
                }
                mainForm.setCurrentStep((cisloKroku+1).ToString() + "/" + (Parameters.NumberOfSteps + 1).ToString());
                cisloKroku++;
                krok = (Parameters.EnergyScan.StartPoint)+cisloKroku*Parameters.EnergyScan.KrokNapatia;
            }
        }

        private void meraj2DScanCyklus()
        {

        }

        internal void showCurrentMeasurement()
        {
            showCurrent =true;
            Graf.clear();
            Graf.setParameters(Parameters.EnergyScan.StartPoint, Parameters.EnergyScan.EndPoint, Parameters.NumberOfSteps + 1, Parameters.NumberOfCycles);
            
            for (int i = 0; i < CurrentMeasurement.cykly.Count; i++)
            {
                for (int j = 0; j < CurrentMeasurement.cykly[i].KrokyMerania.Count; j++)
                {
                    
                    Graf.addDataPoint(CurrentMeasurement.cykly[i].KrokyMerania[j].X,
                       CurrentMeasurement.cykly[i].KrokyMerania[j].Y,
                       CurrentMeasurement.cykly[i].KrokyMerania[j].Intensity,
                       i);

                }
            }
            mainForm.MinimumSize = new System.Drawing.Size(CurrentMeasurement.Parameters.NumberOfSteps + Graf.LeftMargin + Graf.RightMargin + mainForm.sidebarWidth, 0);
        }

        internal void showOldMeasurement()
        {
            showCurrent = false;
            Graf.clear();
            Graf.setParameters(OldMeasurement.Parameters.EnergyScan.StartPoint, OldMeasurement.Parameters.EnergyScan.EndPoint, OldMeasurement.Parameters.NumberOfSteps + 1, OldMeasurement.Parameters.NumberOfCycles);

            for (int i = 0; i < OldMeasurement.cykly.Count; i++)
            {
                for (int j = 0; j < OldMeasurement.cykly[i].KrokyMerania.Count; j++)
                {
                    Graf.addDataPoint(OldMeasurement.cykly[i].KrokyMerania[j].X,
                       OldMeasurement.cykly[i].KrokyMerania[j].Y,
                       OldMeasurement.cykly[i].KrokyMerania[j].Intensity,
                       i);

                }
            }
            mainForm.MinimumSize = new System.Drawing.Size(OldMeasurement.Parameters.NumberOfSteps + Graf.LeftMargin + Graf.RightMargin + mainForm.sidebarWidth, 0);

            //estTimeLabel.Text = DateTime.Now.AddSeconds(noveMeranieWindow.parametreMerania.StepTime * noveMeranieWindow.parametreMerania.NumberOfCycles * noveMeranieWindow.parametreMerania.NumberOfSteps).ToString("hh:mm tt");
           // energyScanStepTimeLabel.Text = noveMeranieWindow.parametreMerania.EnergyScan.StepTime.ToString();
            //resolutionLabel.Text = noveMeranieWindow.parametreMerania.Resolution.ToString();
        }

        public bool showCurrent { get; set; }


        internal void setMainForm(Main main)
        {
            mainForm = main;
        }

        public bool abortStatus { get; set; }
    }

}
