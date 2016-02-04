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
    class NITaskTimerClass : System.Windows.Forms.Timer
    {
        public Task UlohaCounter;
        private NIDriver f;
       //nieco

        public NITaskTimerClass(NIDriver formular)
        {                         //konstruktor
            UlohaCounter = new Task("Counter");
            this.Tick += TaskTimerClass_Tick;
            f = formular;
            n = 0;
           

        }
        int n;
        private void TaskTimerClass_Tick(object sender, EventArgs e)
        {
            try
            {
                if (n < 1)
                {
                    MessageBox.Show("som tu"); 
                    int hodnota = f.Counter.ReadSingleSampleInt32();
                    UlohaCounter.Stop();
                    UlohaCounter.Start();
                    f.Intensity.Add(hodnota);
                    n++;
                }
                else
                {
                    Enabled = false;
                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
