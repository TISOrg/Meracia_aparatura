using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;

namespace JDLMLab
{
    /// <summary>
    /// abstraktna trieda pre serial port zariadenie. poskytuje jednorazove precitanie hodnoty, alebo citanie zo zasobnika BlockingCollection do ktoreho ulozi precitany vstup
    /// </summary>
    abstract class SerialPortDriver : SerialPortDriverInterface
    {
        protected SerialPort serialPort;
        public abstract void close();

        /// <summary>
        /// vseobecna virtualna funckia na vratenie double typu pre ziskany text zo zariadenia. Pre ine zariadenie moze byt konverzia menej trivialna, a tak sa iba overriduje  tato funckia
        /// </summary>
        /// <returns>textovy retazec zo vstupu premeneny na double</returns>
        virtual protected double convertToDouble(string data)
        {
            return Convert.ToDouble(data);
        }
        static int c=0;
        public double LastValue { get; set; }


        protected void dataRecievedHandler(object sender,SerialDataReceivedEventArgs e)
        {
            string x = serialPort.ReadLine();
            LastValue = convertToDouble(x);
            if(blockingCollection!=null)blockingCollection.Add(LastValue);
        }
     
        public virtual void open()
        {
            LastValue = 0;
            
        }

        abstract protected void readRequest();


        System.Timers.Timer timer;
        public void setTimer()
        {
            blockingCollection = new BlockingCollection<double>();
            timer = new System.Timers.Timer(IntervalMerania);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
        }
        public void startReading()
        {
            timer.Enabled = true;
        }

        /// <summary>
        /// zastavi timer
        /// </summary>
        public void stopReading()
        {
            timer.Enabled = false;
        }

        /// <summary>
        /// toto bude volat funckiu readrequest
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            readRequest();
        }

        public bool isOpen() {
            try {
                return serialPort.IsOpen;
            }
            catch (Exception) {
                return false;
            }
            
        }
        
        Thread readingThread;
        public void read()
        {
            readRequest();   
        }

        public double  readNext()
        {   
            double x;
            if(blockingCollection.TryTake(out x)){
                return x;
            }
            else {
                return LastValue;
            }
        }

        public int IntervalMerania { get; set; }

        protected BlockingCollection<double> blockingCollection;



    }
}
