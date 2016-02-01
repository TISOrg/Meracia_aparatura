using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using NationalInstruments;
using NationalInstruments.DAQmx;
using System.Windows.Forms;

namespace JDLMLab
{
    class NIDriver
    {
        NITaskTimerClass mojaUlohaCounter;
        string prevodnik = "Dev2";  
        private CIChannel CICh;
        public CounterReader Counter;
        public int[] ttlSignal;

        public int aktualnyKrok;
        public int last;

        public NIDriver()
        {

        }



        // ---------------ZAPIS ANALOG-----------
        public void setAnalogOutput(double value)
        {
            Task analogOutTask = new Task();

            AOChannel myAOChannel;

            myAOChannel = analogOutTask.AOChannels.CreateVoltageChannel(
                prevodnik + "/ao1",
                "myAOChannel",
                0,
                5,
                AOVoltageUnits.Volts
                );

            AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(analogOutTask.Stream);

            writer.WriteSingleSample(true, value);
        }


        // --------------DIGITAL ZAPIS--------------
        public void triggerInit()
        {
            last = 0;
            mojaUlohaCounter = new NITaskTimerClass(this);

            ttlSignal = new int[20];

            CICh = mojaUlohaCounter.UlohaCounter.CIChannels.CreateCountEdgesChannel(
                prevodnik + "/ctr0",
                prevodnik + "ctr0",
                CICountEdgesActiveEdge.Falling,
                0,
                CICountEdgesCountDirection.Up
            );

            mojaUlohaCounter.UlohaCounter.Control(TaskAction.Verify);

            Counter = new CounterReader(mojaUlohaCounter.UlohaCounter.Stream);
            mojaUlohaCounter.UlohaCounter.Start();

            aktualnyKrok = 0;
            mojaUlohaCounter.Enabled = true;
        }

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


        //-------CITANIE ANALOG------

        public double readTlakomerPR4000()
        {
            return analogReadData();
        }















        double analogReadData()
        {
            Task analogInTask = new Task();
            AIChannel myAIChannel;
            myAIChannel = analogInTask.AIChannels.CreateVoltageChannel(
                prevodnik + "/ai1",
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




        void analogWriteData(string vstup)
        {
            Task analogOutTask = new Task();
            AOChannel myAOChannel;
            myAOChannel = analogOutTask.AOChannels.CreateVoltageChannel(
                prevodnik + "/ao1",
                "myAOChannel",
                0,
                5,
                AOVoltageUnits.Volts
                );

            AnalogSingleChannelWriter writer = new AnalogSingleChannelWriter(analogOutTask.Stream);
            double analogDataOut = 0;
            if (vstup != "")
            {
                try
                {
                    analogDataOut = Convert.ToDouble(vstup);
                }
                catch (System.FormatException e)
                {
                    MessageBox.Show("Vstup " + Convert.ToString(vstup) + " nie je v spravnom tvare.");
                }
            }
            else
            {
                vstup = "0";
                analogDataOut = Convert.ToDouble(vstup);
            }
            writer.WriteSingleSample(true, analogDataOut);
        }
    }




}