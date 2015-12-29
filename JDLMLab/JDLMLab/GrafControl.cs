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
        string typ;// pameta si typ zobrazovaneho merania ak je iny tym vymaze body z grafu
        int r;
        int g;
        int b;
        Dictionary<int, int> hodnoty = new Dictionary<int, int>();//budu sa uchovavat x a y hdnoty pre zobrazenie suny a priemeru
        DataSet suradnicemerani = new DataSet();
        Chart grafmerani;
        //System.Windows.Forms.MouseEventArgs mys;
        public GrafControl(Chart chart)
        {
            grafmerani = chart;
            grafmerani.ChartAreas[0].AxisX.ScaleView.Zoomable = true;//zapni zoomovanie
            r = 0;
            g = 0;
            b = 0;
            typ = "";

            chart.ChartAreas[0].CursorX.AutoScroll = true;
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;

            chart.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 100;


            chart.ChartAreas[0].AxisY.LogarithmBase = 10;
            chart.ChartAreas[0].AxisY.IsLogarithmic = false;




        }
        public void addvaluestotable(int x, int y, string cyklus)
        {
            if (suradnicemerani.Tables.Contains(cyklus))
            {
                DataRow dr = suradnicemerani.Tables[cyklus].NewRow();

                dr["X"] = x;
                dr["Y"] = y;
                suradnicemerani.Tables[cyklus].Rows.Add(dr);

            }
            else
            {
                DataTable table = new DataTable();
                table.Columns.Add("X", typeof(int));
                table.Columns.Add("y", typeof(int));
                DataRow dr = table.NewRow();

                dr["X"] = x;
                dr["Y"] = y;
                table.Rows.Add(dr);
                table.TableName = cyklus;
                suradnicemerani.Tables.Add(table);
            }




        }

        internal void addMeranie(int meranie)
        {
            DbCommunication db = new DbCommunication();
            DataSet dataset = db.meranie(meranie);

        }
        void addMeranie(DataTable d)
        {

        }

        public void addxy(int x, int y, string cyklus)
        {
            if (typ != cyklus)
            {
                grafmerani.Series["Series1"].Points.Clear();
            }
            addvaluestotable(x, y, cyklus);
            typ = cyklus;
            foreach (DataRow row in suradnicemerani.Tables[cyklus].Rows)
            {
                grafmerani.Series["Series1"].Points.AddXY(int.Parse(row[0].ToString()), int.Parse(row[0].ToString()));

            }


        }
        public void dravchartfromdict()
        {
            grafmerani.Series["Series1"].Points.Clear();
            foreach (KeyValuePair<int, int> xy in hodnoty)
            {
                grafmerani.Series["Series1"].Points.AddXY(xy.Key, xy.Value);
            }
        }

        public void prepnizobrazenie()
        {
            if (this.grafmerani.ChartAreas[0].AxisX.IsLogarithmic == true)//jezapnute logaritmicke zobrazenie vypni ho
            {
                this.grafmerani.ChartAreas[0].AxisX.IsLogarithmic = false;
                this.grafmerani.ChartAreas[0].AxisY.IsLogarithmic = false;
            }
            else
            {
                this.grafmerani.ChartAreas[0].AxisX.IsLogarithmic = true;
                this.grafmerani.ChartAreas[0].AxisY.IsLogarithmic = true;
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
            double pos = grafmerani.ChartAreas[0].CursorX.Position;     //pozicia cervenej ciary zlava
            double max = grafmerani.ChartAreas[0].AxisX.ScaleView.ViewMaximum;  //aktualny najlavejsi zobrazeny bod
            double min = grafmerani.ChartAreas[0].AxisX.ScaleView.ViewMinimum;  //aktualny najpravejsi zobrazeny bod
            double d = (max - min) * f;
            grafmerani.ChartAreas[0].AxisX.ScaleView.Zoom(pos - d, pos + d);        
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


        
        public void suma()
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

        public void priemer()
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
            var keys = new List<int>(hodnoty.Keys);
            foreach (int key in keys)
            {
                hodnoty[key] = hodnoty[key] / pocetcyklov;
            }
        }
    }
}
