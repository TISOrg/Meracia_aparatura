using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace JDLMLab
{
    /// <summary>
    /// trieda s metodami pre nastavenie intervalu citania, zasabnika na ukladanie nacitanych merani. atd...
    /// </summary>
    class SerialPortDeviceController
    {
        private SerialPortDriver driver;
        public SerialPortDeviceController(SerialPortDriver driver)
        {
            this.driver = driver;
            Queue = new Queue<double>();

            
        }

        /// <summary>
        /// interval citania hodnoty v milisekunach
        /// </summary>
        public int IntervalCitania { get; set; }

        /// <summary>
        /// rad do ktoreho trieda vklada nacitane hodnoty zo zariadenia v stanovenych intervaloch
        /// </summary>
        public Queue<double> Queue { get; set; }

        
        
        public void startReading()
        {
            driver.open();
           
        }
        public bool Running { get; set; }

        public void stopReading()
        {
        
            Running = false;
            driver.close();
        }


        public void readAndSave(object state)
        {
            Queue.Enqueue(driver.r());
        }
        
        /// <summary>
        /// jednorazove precitanie hodnoty z pristroja
        /// </summary>
        /// <returns></returns>
        public double read()
        {
            return driver.read();
        }
        
}
}
