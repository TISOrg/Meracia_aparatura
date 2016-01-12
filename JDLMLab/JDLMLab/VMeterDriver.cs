﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Ports;
namespace JDLMLab
{
    /// <summary>
    /// autor: Jano
    /// </summary>
    class VMeterDriver : SerialPortDriver
    {     
        
        public override void open()
        {
            serialPort = new SerialPort(Properties.Devices.Default.voltmeterPort, 4800, Parity.None, 8, StopBits.One);   //zakladne nastavenia, najma COM sa bude menit, zmeni sa v gui
            

            serialPort.DataReceived += dataRecieved;
            serialPort.ReceivedBytesThreshold = 1;  //velmi uzitocna vec... zavola recieved handler iba pri urcenom pocte bytov na vstupe. napr. pre teplomer
            //sp.NewLine ="\n";   //urci sa new line. vacsniou \n
            
            serialPort.Open();

            serialPort.Write(":System:Preset");
            serialPort.Write("\r\n");
            serialPort.Write("*RST");
            serialPort.Write("\r\n");
            serialPort.Write("*CLS"); //PRINT #1, “:INIT:CONT OFF;:ABORT” ‘ Init off
            serialPort.Write("\r\n");
            
        }

        public override void close()
        {
            serialPort.Write(":INITiate:CONTinuous ON");
            serialPort.Write("\r\n");
            serialPort.Close();
        }

        protected override void readRequest()
        {
            serialPort.Write(":READ?");
            serialPort.Write("\r\n");
        }
    }
}
