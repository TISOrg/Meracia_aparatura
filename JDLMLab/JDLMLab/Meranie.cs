using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JDLMLab
{
    /// <summary>
    ///  Trieda pre jedno meranie
    /// Autor - Jano
    /// </summary>
    class Meranie
    {
        public MeasurementParameters Parameters { get; private set; }

        public Meranie(MeasurementParameters parameters)
        {
            this.Parameters = parameters;
            cykly = new List<CyklusMerania>(parameters.PocetCyklov);

        }
        public List<CyklusMerania> cykly {get; set; }

        public void pridajCyklus(CyklusMerania c)
        {
            cykly.Add(c);
        }
        public CyklusMerania getCyklus(int i) { return cykly[i-1]; }
        
        /// <summary>
        /// DataTAble so stlpcami x,y,sig,current,chamber,kapillar,temperature a cycle_num
        /// </summary>
        public DataTable DataTable{
            get
            {
                DataTable t = new DataTable();
                foreach(CyklusMerania c in cykly)
                {
                    t.Merge(c.Table);
                }
                return t;
            }
        }
        /// <summary>
        /// Dataset obsahujuci tabulky s nazvom "i" kde i je cislo cyklu. V kazdej DataTable su stplce x,y.
        /// </summary>
        public DataSet DataSetForGraf
        {
            get
            {
                DataSet set = new DataSet();
                foreach (CyklusMerania c in cykly)
                {
                    set.Tables.Add(c.TableForGraf.Copy());
                }
                return set;
            }
        }
        public void addKrok(int cyklus,KrokMerania k) 
        {
            try {
                cykly[cyklus-1].pridajKrok(k);
            }
            catch (NullReferenceException e)
            {
                
            }
            catch(ArgumentOutOfRangeException e)
            {
                pridajCyklus(new CyklusMerania(cyklus));
                cykly.Last().pridajKrok(k);
            }
        }
    }
}
