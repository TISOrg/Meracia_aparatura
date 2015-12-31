using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JDLMLab
{
    /// <summary>
    /// prerobit, aby fungovalo
    /// </summary>
    class TlakomerTG256ADriver : SerialPortDriver
    {
        public override void close()
        {
            throw new NotImplementedException();
        }

        public override void open()
        {
            throw new NotImplementedException();
        }

        private char[] znaky = new char[3];
        public override double read()
        {
            //serialPort2.Write("\r");
            //tlakomerBox.AppendText(serialPort2.ReadLine());
            //serialPort2.Write("@sts1");
            //serialPort2.Write("\r");
            int i = 1;
            Thread.Sleep(3000);
            serialPort.Write("PR" + "1" + "\r\n");
            Thread.Sleep(100);
            serialPort.ReadLine();
            serialPort.Write(znaky, 2, 1);
            i++;
            Thread.Sleep(100);
            data = serialPort.ReadLine();
            spracujStatusTlak(data);

            return 0.0;
        }

        public Thread zistovacTlakov;



        private void button3_Click(object sender, EventArgs e)
        {


            serialPort.NewLine = "\r\n";
            serialPort.Open();

            znaky[0] = '\x02';
            znaky[1] = '\x03';
            znaky[2] = '\x05';

            //for (int i = 0; i <= 5; i++)
            //{
            //    Senzory.Add(new Senzor());
            //}

            

        }
        private void spracujStatusTlak(string prijate)
        {
            char[] sep = new char[1];
            sep[0] = ',';

            string[] temp = prijate.Split(sep, 2);

            //hodnota = temp[0] + "\t" + temp[1] + "\n";

        }
    }
}
