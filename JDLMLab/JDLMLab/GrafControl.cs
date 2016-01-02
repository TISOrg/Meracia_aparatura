using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using System.Drawing;

namespace JDLMLab
{
    class GrafControl
    {
        enum RezimZobrazenia {
            Sum = 3,
            Avg = 2,
            Akt = 1,
        }
        int typ;// pameta si typ zobrazovaneho merania ak je iny tym vymaze body z grafu
        int r;
        int g;
        int b;
        Dictionary<double, double> hodnoty = new Dictionary<double,double>();//budu sa uchovavat x a y hdnoty pre zobrazenie suny a priemeru

        Dictionary<double, double> sumHodnoty = new Dictionary<double, double>();//budu sa uchovavat x a y hdnoty pre zobrazenie suny a priemeru
        Dictionary<double, double> avgHodnoty = new Dictionary<double, double>();//budu sa uchovavat x a y hdnoty pre zobrazenie suny a priemeru

        DataSet suradnicemerani = new DataSet();
        Chart graf;
        //System.Windows.Forms.MouseEventArgs mys;
        public GrafControl(Chart chart)
        {
            graf = chart;
            graf.ChartAreas[0].AxisX.ScaleView.Zoomable = true;   //zapni zoomovanie
            r = 0;
            g = 0;
            b = 0;
            nastavitParametreGrafu();
            Rezim = RezimZobrazenia.Akt;
            init();
        }

        private void init()
        {
            //grafmerani.ChartAreas[0].BackColor = Color.Blue;
        }
        RezimZobrazenia rezimZobrazenia;
        RezimZobrazenia Rezim {
            get {
                return rezimZobrazenia;
            }
            set {
                rezimZobrazenia= value;
                //repaintGraf();
            }
        }

        private void nastavitParametreGrafu()
        {
            graf.ChartAreas[0].CursorX.AutoScroll = true;
            graf.ChartAreas[0].CursorX.IsUserEnabled = true;
            graf.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            graf.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            graf.ChartAreas[0].AxisY.LogarithmBase = 10;
            graf.ChartAreas[0].AxisY.IsLogarithmic = false;
        }

     
        public void clearGraf()
        {
            graf.Series[0].Points.Clear();
        }
        internal void addMeranie(int meranie)   
        {

            DbCommunication db = new DbCommunication();
            DataSet h = db.header(meranie);
            graf.ChartAreas[0].AxisX.Minimum = (double)(h.Tables[0].Rows[0]["start_point"]);
            graf.ChartAreas[0].AxisX.Maximum =(double)(h.Tables[0].Rows[0]["end_point"]);
            graf.ChartAreas[0].AxisY.Maximum = 500;
            DataSet dataset = new DataSet();
            dataset = db.meraniePreGraf(meranie);
            
            addMeranie(dataset);    // v datasete je ulozena tabulka s tromi stlpcami: x,y,cyklus. Teda je tam vsetko dokopy

        }
        public void addMeranie(DataSet d)   //funckia prijme taublku s tromi stlpcami: x,y,cyklus a dalej vola funckiu addxyTograf
        {
            foreach(DataRow r in d.Tables[0].Rows)
            {
                addxyToGraf(Convert.ToDouble(r[0]),Convert.ToDouble(r[1]), (int)r[2]);
            }
        
        
        }

        public double MinValue { get { return MinValue; } set { graf.ChartAreas[0].AxisX.Minimum = value; MinValue = value; } }
        public double MaxValue { get { return MaxValue; } set { graf.ChartAreas[0].AxisX.Maximum = value; MaxValue = value; } }

        private double X,Y;
        public void addxyToGraf(double x, double y, int cyklus) //pridavam do grafu hodnotu x,y ktore patria cyklu
        {
            if (Cyklus != cyklus)
            {
                //grafmerani.Series["Series1"].Points.Clear();
            }
            addvaluestotable(x, y, cyklus);
            Cyklus = cyklus;
            foreach (DataRow row in suradnicemerani.Tables[cyklus.ToString()].Rows)
            {
                graf.Series["Series1"].Points.AddXY(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()));
            }
        }
        public void addvaluestotable(double x, double y, int cyklus)
        {
            if (suradnicemerani.Tables.Contains((cyklus.ToString())))
            {
                DataRow dr = suradnicemerani.Tables[cyklus.ToString()].NewRow();
                dr["X"] = x;
                dr["Y"] = y;
                suradnicemerani.Tables[cyklus.ToString()].Rows.Add(dr);
            }
            else
            {
                DataTable table = new DataTable();
                table.Columns.Add("X", typeof(int));
                table.Columns.Add("Y", typeof(int));
                DataRow dr = table.NewRow();

                dr["X"] = x;
                dr["Y"] = y;
                table.Rows.Add(dr);
                table.TableName = cyklus.ToString();
                suradnicemerani.Tables.Add(table);
            }
        }

        public void repaintGraf()
        {
            graf.Series["Series1"].Points.Clear();
            switch (Rezim)
            {
                case RezimZobrazenia.Avg:
                    vypocitajXYRezimAvg();
                    drawChartFromDict();
                    break;
                case RezimZobrazenia.Sum:
                    vypocitajXYRezimSuma();
                    drawChartFromDict();
                    break;
                case RezimZobrazenia.Akt:
                    zobrazitAktualnyCyklus();
                    break;
                default:
                    break;
            }
            
        }

        

        public int Cyklus{get;set;}

        private void zobrazitAktualnyCyklus()
        {
            foreach (DataRow row in suradnicemerani.Tables[Cyklus.ToString()].Rows)
            {
                graf.Series["Series1"].Points.AddXY(int.Parse(row[0].ToString()), int.Parse(row[1].ToString()));
            }
        }

        public void drawChartFromDict()
        {
            
            foreach (KeyValuePair<double, double> xy in hodnoty)
            {
                graf.Series["Series1"].Points.AddXY(xy.Key, xy.Value);
            }
        }


        public void prepnizobrazenie()
        {
            if (this.graf.ChartAreas[0].AxisX.IsLogarithmic == true)//jezapnute logaritmicke zobrazenie vypni ho
            {
                this.graf.ChartAreas[0].AxisX.IsLogarithmic = false;
                this.graf.ChartAreas[0].AxisY.IsLogarithmic = false;
            }
            else
            {
                this.graf.ChartAreas[0].AxisX.IsLogarithmic = true;
                this.graf.ChartAreas[0].AxisY.IsLogarithmic = true;
            }
        }
   
        public void grafKeyPressed(KeyEventArgs e)
        {
         
            if (e.KeyCode == Keys.PageUp)
            {
                zoom(0.5);
            }

            if (e.KeyCode == Keys.PageDown)
            {
                zoom(2);
            }
        }

        private void zoom(double f)
        {
            double pos = graf.ChartAreas[0].CursorX.Position;     //pozicia cervenej ciary zlava
            double max = graf.ChartAreas[0].AxisX.ScaleView.ViewMaximum;  //aktualny najlavejsi zobrazeny bod
            double min = graf.ChartAreas[0].AxisX.ScaleView.ViewMinimum;  //aktualny najpravejsi zobrazeny bod
            double d = (max - min) * f;
            graf.ChartAreas[0].AxisX.ScaleView.Zoom(pos - d / 2, pos + d / 2);
            
           
        }

        public void rgb(int minimum, int maximum, int value)
        {
            float min = Convert.ToSingle(minimum);
            float max = Convert.ToSingle(maximum);
            int ratio = 0;
            ratio = 2 * (value - minimum) / (maximum - minimum);

            b = 255 * (1 - ratio);
            r = 255 * (ratio - 1);
            g = 255 - b - r;
        }


        private void vypocitajXYRezimAkt()
        {
            int x = 0;
            int y = 0;
            hodnoty.Clear();
            foreach (DataRow row in suradnicemerani.Tables[Cyklus].Rows)
            {
                x = int.Parse(row[0].ToString());
                y = int.Parse(row[1].ToString());
                if (hodnoty.ContainsKey(x))
                {
                    hodnoty[x] += y;
                }
                else
                {
                    hodnoty.Add(x, y);
                }
            }
        }

        public void vypocitajXYRezimSuma()
        {// x su rownake pocet riadkov stetkych tabuliek je rovnaky
            int x = 0;
            int y = 0;
            hodnoty.Clear();
            foreach (DataTable table in suradnicemerani.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    x = int.Parse(row[0].ToString());
                    y = int.Parse(row[1].ToString());
                    if (hodnoty.ContainsKey(x))
                    {
                        hodnoty[x] += y;
                    }
                    else
                    {
                        hodnoty.Add(x, y);
                    }
                }
            }
        }

        public void vypocitajXYRezimAvg()
        {// x su rownake pocet riadkov stetkych tabuliek je rovnaky
            int x = 0;
            int y = 0;
            hodnoty.Clear();
            int pocetcyklov = 0;

            foreach (DataTable table in suradnicemerani.Tables)
            {
                pocetcyklov += 1;
                foreach (DataRow row in table.Rows)
                {
                    x = int.Parse(row[0].ToString());
                    y = int.Parse(row[1].ToString());
                    if (hodnoty.ContainsKey(x))
                    {
                        hodnoty[x] += y;
                    }
                    else
                    {
                        hodnoty.Add(x, y);
                    }
                }
            }
            var keys = new List<double>(hodnoty.Keys);
            foreach (double key in keys)
            {
                hodnoty[key] = hodnoty[key] / pocetcyklov;
            }
        }
    }
}
