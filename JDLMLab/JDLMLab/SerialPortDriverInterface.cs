using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
namespace JDLMLab
{
    interface SerialPortDriverInterface
    {
        /// <summary>
        /// otvori port a nastavi BlockingCollection
        /// </summary>
        void open();
        /// <summary>
        /// zatvori port a uzamkne BlockingCollection
        /// </summary>
        void close();
        /// <summary>
        /// jednorazove precitanie. metoda vrati poslednu hodnotu nacitanu pri vykonani dataRecieved handlera
        /// </summary>
        /// <returns>vracia poslednu hodnotu z dataRecieved handlera</returns>
        void read();
        /// <summary>
        /// zastavi Timer pre citanie z input buffera
        /// </summary>
        void stopReading();
        /// <summary>
        /// zapne timer pre citanie input buffera
        /// </summary>
        void startReading();
        /// <summary>
        /// vyrobi timer
        /// </summary>
        void setTimer();
        /// <summary>
        /// precita dalsiu hodnotu z kolekcie
        /// </summary>
        /// <param name="value">hodnota do ktrorej ma ulozit dalsi precitanu hodnotu</param>
        double readNext();
    }
}
