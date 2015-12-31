using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
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
            Application.Run(new Main());

            //MeasurementParameters mp = new MeasurementParameters();
            //mp.constant = 4;
            //mp.endPoint = 5;
            //mp.startPoint = 1;
            //mp.name = "meraniaaaaaaa";
            //mp.pocetCyklov = 5;
            //mp.stepTime = 10;
            //mp.note = "ide to?";
            //mp.typ = "Energy Scan";

            //DbConnectionSettings ss = new DbConnectionSettings();
            //ss.database = "aparatura";
            //ss.userName = "aparatura";
            //ss.password = "JDLMaparatura";
            //ss.port = 3306;
            //ss.serverName = "kempelen.ii.fmph.uniba.sk";

            //DbCommunication db = new DbCommunication(ss);
            //db.open();
            //db.noveMeranie(mp);
            //KrokMerania k = new KrokMerania(1, 4, 100, 3.4, 6.4, 7.5, 4.3);
            //db.addKrok(k);
            //k.x = 2;
            //k.sig = 400;
            //db.addKrok(k);
            //k.x =3;
            //k.sig = 1400;
            //db.addKrok(k);
            //k.x = 4;
            //k.sig = 140;
            //db.addKrok(k);
            //k.x = 5;
            //k.sig = 10;
            //db.addKrok(k);
            //k.x = 1;
            //k.sig = 403;
            //k.cyklus = 2;
            //db.addKrok(k);

            //mp.constant = 7;
            //mp.startPoint = 2;
            //mp.endPoint = 10;
            //mp.name = "dalsie meranie";
            //mp.note = "poznamka k druhehmu meraniu";
            //db.noveMeranie(mp);
            //k = new KrokMerania(2,7, 30, 3, 4, 7, 3);
            //db.addKrok(k);
            //k.x = 2;
            //k.sig = 2400;
            //db.addKrok(k);
            //k.x = 3;
            //k.sig = 21400;
            //db.addKrok(k);
            //k.x = 4;
            //k.sig = 2140;
            //db.addKrok(k);
            //k.x = 5;
            //k.sig = 210;
            //db.addKrok(k);
            //k.x = 5;
            //k.sig = 2403;
            //k.cyklus = 2;
            //db.addKrok(k);

            //k.x = 8;
            //k.sig = 2403;
            //k.cyklus = 2;
            //db.addKrok(k);
            //db.close();
            //meranie m = new meranie(mp);
            //m.addkrok(0, new krokmerania(1, 2, 4, 7, 8, 9, 10));
            //m.addkrok(0, new krokmerania(2, 4, 4, 7, 8, 9, 10));
            //m.addkrok(0, new krokmerania(3, 5, 4, 7, 8, 9, 10));
            //m.addkrok(0, new krokmerania(4, 8, 4, 7, 8, 9, 10));
            //m.addkrok(0, new krokmerania(5, 9, 4, 7, 3, 2, 1));
            //foreach (krokmerania k in m.getcyklus(0).getkroky())
            //{
            //    console.writeline(k.tostring());
            //}
            //list<string> s = new list<string>();
            //s[0] = "dd";
        }
        
    }
}
