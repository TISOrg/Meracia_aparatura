using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Globalization;

namespace JDLMLab
{
    static class Program
    {
        private static SerialPort serialPort;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            CultureInfo ci = new CultureInfo("en-US");
           
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            CultureInfo.DefaultThreadCurrentCulture = ci;
            CultureInfo.DefaultThreadCurrentUICulture = ci;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 
            Application.Run(new Main());

            //serialPort = new SerialPort(Properties.Devices.Default.ampermeterPort, 9600, Parity.None, 8, StopBits.One);   //zakladne nastavenia, najma COM sa bude menit, zmeni sa v gui


            //serialPort.DataReceived += dataRecieved;
            //serialPort.ReceivedBytesThreshold = 10;  //velmi uzitocna vec... zavola recieved handler iba pri urcenom pocte bytov na vstupe. napr. pre teplomer
            //                                         //sp.NewLine ="\n";   //urci sa new line. vacsniou \n

            //serialPort.Open();


            //serialPort.Write(":System:Preset");
            //serialPort.Write("\r\n");
            //serialPort.Write("*RST");
            //serialPort.Write("\r\n");
            //serialPort.Write("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
            //serialPort.Write("\r\n");


            //serialPort.Write(":READ?");
            //serialPort.Write("\r\n");


        }
    }
}
