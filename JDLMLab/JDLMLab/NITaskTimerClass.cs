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
       

        public NITaskTimerClass(NIDriver formular)
        {                         //konstruktor
            UlohaCounter = new Task("Counter");
            this.Tick += TaskTimerClass_Tick;
            f = formular;
           

        }

        private void TaskTimerClass_Tick(object sender, EventArgs e)
        {
            try
            {
                if (f.aktualnyKrok < 20)
                {
                    int hodnota = f.Counter.ReadSingleSampleInt32();
                    f.ttlSignal[f.aktualnyKrok++] = hodnota;
                    UlohaCounter.Stop();
                    UlohaCounter.Start();
                }
                else
                {
                    Enabled = false;
                    string s = "";
                    foreach (int i in f.ttlSignal)
                    {
                        s += i.ToString() + "\n";
                    }
                    MessageBox.Show(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
