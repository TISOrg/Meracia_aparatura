using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        double last { get; set; }
        protected void dataRecieved(object sender,SerialDataReceivedEventArgs e)
        {
            last = convertToDouble(serialPort.ReadLine());
            blockingCollection.Add(last);
            blockingCollection.Take();
            c++;
        }
        public abstract void open();

        abstract protected void readRequest();


        System.Timers.Timer timer;
        public void setTimer(int delay)
        {
            IntervalMerania = delay;
            timer = new System.Timers.Timer(delay);
            timer.Elapsed += Timer_Elapsed;
            blockingCollection = new BlockingCollection<double>();
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

        public double read()
        {
            return last;
        }
        public void readNext(out double value)
        {
            
            if (!blockingCollection.TryTake(out value))
            {
                value = last;
                c--;
                return;
            }
            throw new Exception("neni na bafri nic");
            return;
            
            //uvidime ci bude treba task alebo vlakno...mozno vobec -> tak potom odstranit nasledujuce
            using (Task t2 = Task.Factory.StartNew(() =>
            {
                // Consume consume the BlockingCollection
                double s;
                if (blockingCollection.TryTake(out s))
                    ;
                else
                {
                    s = -1;
                }


            }))
                ;

        }

        public int IntervalMerania { get; set; }

        protected BlockingCollection<double> blockingCollection;
        protected Queue<string> q;

        /// <summary>
        /// testovacie veci, odstranit potom
        /// </summary>
        protected BlockingCollection<string> testbc;
        protected Queue<string> testq;

    }
}
