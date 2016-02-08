using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using NationalInstruments;
using NationalInstruments.DAQmx;
using System.Windows.Forms;
using System.Threading;


namespace JDLMLab
{

    class NIDriver
    {

        public NIDriver(int pocetBodov)         //KONSTRUKTOR
        {
            
            UlohaCounter = new Task("Counter");
            Intensity = 0;
        }
        public Task UlohaCounter;     
        private CIChannel CICh;
        public CounterReader Counter;
        string prevodnikId = "Dev2";

        public ulong Intensity { get; set; }
        public double Steptime {
            get;set;
        }
        

//---------------------------------------------------------------------------------------------------------------------------------------------

        internal void triggerInit(double casoKrok)
        {
            //     ttlSignal = new int[NumOfSteps];
            Steptime = casoKrok;
            CICh = UlohaCounter.CIChannels.CreateCountEdgesChannel(
                prevodnikId + "/ctr0",
                prevodnikId + "ctr0",
                CICountEdgesActiveEdge.Falling,
                0,
                CICountEdgesCountDirection.Up
            );
            UlohaCounter.Control(TaskAction.Verify);
            Counter = new CounterReader(UlohaCounter.Stream);
        //    UlohaCounter.Start();
        }

        public void CounterStart()
        {
            try
            {
                UlohaCounter.Start();
                Thread.Sleep((int)(Steptime * 1000));
                ulong hodnota = Counter.ReadSingleSampleUInt32();
                UlohaCounter.Stop();
                      
                Intensity=hodnota;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }




//--------------------------------------------------------------------------------------------------------------------------------

 
        public void triggerSetTime()
        {

        }

        public void triggerReadData()
        {

        }

        //-----------DIGITAL CITANIE------------------
        /// <summary>
        /// Zistuje sa, ci je uz trigger pripraveny
        /// </summary>
        /// <returns></returns>
        public bool readTrigger()
        {
            return true;
        }

        /// <summary>
        /// iba pre Mass Scan
        /// </summary>
        /// <returns></returns>
        public bool startSignal()
        {
            return true;
        }

        // ---------------ZAPIS ANALOG-----------
        /// <summary>
        /// Metoda nastavuje/zapisuje cez AD prevodnik hodnotu value.
        /// </summary>
        /// <param name="value"></param>
        public void setAnalogOutput(double value)
        {
            Task analogOutTask = new Task();
            AOChannel myAOChannel;
            myAOChannel = analogOutTask.AOChannels.CreateVoltageChannel(
                prevodnikId + "/ao1",
                "myAOChannel",
                0,
                5,
                AOVoltageUnits.Volts
                );
            AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(analogOutTask.Stream);
            writer.WriteSingleSample(true, value);
        }

        //-------CITANIE ANALOG------
        /// <summary>
        /// cita hodnotu z Tlakomeru pomocou analogoveho vstupu.
        /// </summary>
        /// <returns></returns>
        public double readTlakomerPR4000()
        {
            Task analogInTask = new Task();
            AIChannel myAIChannel;
            myAIChannel = analogInTask.AIChannels.CreateVoltageChannel(
                prevodnikId + "/ai1",
                "myAIChannel",
                AITerminalConfiguration.Differential,
                0,
                5,
                AIVoltageUnits.Volts
                );
            AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);
            double analogDataIn = reader.ReadSingleSample();
            return analogDataIn;
        }

        
    }
}