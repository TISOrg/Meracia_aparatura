using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    class TlakomerPR4000Driver 
    {
        public  void close()
        {
            throw new NotImplementedException();
        }

        public  void open()
        {
            
        }


        System.Timers.Timer timer;

        public int IntervalMerania { get; private set; }

        public void setTimer(int delay)
        {
            //IntervalMerania = delay;
            //timer = new System.Timers.Timer(delay);
            //timer.Elapsed += Timer_Elapsed;
            //blockingCollection = new BlockingCollection<double>();
            //timer.AutoReset = true;
            //// blockingCollection.Add(6);
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
        //private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        //{
        //    readRequest();
        //}



    }
}
