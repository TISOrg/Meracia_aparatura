using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JDLMLab
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //MeasurementParameters mp = new MeasurementParameters();
            //mp.constant = 4;
            //mp.endPoint = 5;
            //mp.startPoint = 1;
            //mp.name = "nazov";
            //mp.pocetCyklov = 5;
            //mp.stepTime = 10;
            //mp.note = "poznamka ...";

            //Meranie m = new Meranie(mp);
            //m.addKrok(0, new KrokMerania(1, 2, 4, 7, 8, 9, 10));
            //m.addKrok(0, new KrokMerania(2, 4, 4, 7, 8, 9, 10));
            //m.addKrok(0, new KrokMerania(3, 5, 4, 7, 8, 9, 10));
            //m.addKrok(0, new KrokMerania(4, 8, 4, 7, 8, 9, 10));
            //m.addKrok(0, new KrokMerania(5, 9, 4, 7, 3, 2, 1));
            //foreach (KrokMerania k in m.getCyklus(0).getKroky())
            //{
            //    Console.WriteLine(k.toString());
            //}
            //List<String> s = new List<string>();
            //s[0] = "dd";



        }
    }
}
