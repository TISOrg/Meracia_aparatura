using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments;
using NationalInstruments.DAQmx;
using System.Windows.Forms;

namespace JDLMLab
{
    class NIDriver
    {

        public NIDriver()
        {

        }



        // ---------------ZAPIS ANALOG-----------
        public void setAnalogOutput(double value)
        {
            Task analogOutTask = new Task();

            AOChannel myAOChannel;

            myAOChannel = analogOutTask.AOChannels.CreateVoltageChannel(
                "dev1/ao1",
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
            return 0;
        }















        string analogReadData()
        {
            Task analogInTask = new Task();
            AIChannel myAIChannel;


            myAIChannel = analogInTask.AIChannels.CreateVoltageChannel(
                "dev1/ai1",
                "myAIChannel",
                AITerminalConfiguration.Differential,
                0,
                5,
                AIVoltageUnits.Volts
                );

            AnalogSingleChannelReader reader = new AnalogSingleChannelReader(analogInTask.Stream);

            double analogDataIn = reader.ReadSingleSample();

            return analogDataIn.ToString();
        }




        void analogWriteData(string vstup)
        {
            Task analogOutTask = new Task();

            AOChannel myAOChannel;

            myAOChannel = analogOutTask.AOChannels.CreateVoltageChannel(
                "dev1/ao1",
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