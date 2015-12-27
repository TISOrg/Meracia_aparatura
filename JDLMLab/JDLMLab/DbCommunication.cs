using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace JDLMLab
{
    class DbCommunication
    {
        private string connectionString;
        private MySqlConnection conn;
        public DbCommunication(DbConnectionSettings settings)
        {
            connectionString =
                "Server=" + settings.serverName +
                ";Port=" + settings.port.ToString() +
                ";Database=" + settings.database +
                ";Uid=" + settings.userName +
                ";Password=" + settings.password;
            conn = new MySqlConnection(connectionString);

            bool tabulkyExistuju = false; ;
            MySqlCommand c = new MySqlCommand("show tables like 'headersx'", conn);
            conn.Open();
            MySqlDataReader r = c.ExecuteReader();
            while (r.Read())
            {
                //tabulka existuje
                tabulkyExistuju = true;
            }
            r.Close();
            if(!tabulkyExistuju) vytvorTabulky();
            conn.Close();
        }

        private void vytvorTabulky()
        {
            string sql = "CREATE TABLE `headersx` (  `id` int(100) NOT NULL,  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_mysql500_ci DEFAULT NULL," +
                   "`type_name` varchar(200) NOT NULL,  `datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,  `start_point` double NOT NULL," +
                   "`end_point` double NOT NULL,  `constant` double NOT NULL,  `resolution` double NOT NULL,  `steptime` double NOT NULL," +
                  "`cycles` int(254) NOT NULL,  `note` varchar(500) NOT NULL) ENGINE = InnoDB DEFAULT CHARSET = latin1;";
            sql += "CREATE TABLE `meraniax` (" +
                  "`id` int(11) NOT NULL,  `x` double NOT NULL,  `y_id` int(11) NOT NULL,  `sig` int(11) NOT NULL," +
                  "`current` double NOT NULL,  `kapillar` double NOT NULL,  `chamber` double NOT NULL,  `temperature` double NOT NULL" +
                ") ENGINE = InnoDB DEFAULT CHARSET = latin1;";
            sql += "CREATE TABLE `rowsx` (  `id` int(11) NOT NULL,  `y` double NOT NULL,  `cycle_num` int(254) NOT NULL," +
                "`header_id` int(11) NOT NULL) ENGINE = InnoDB DEFAULT CHARSET = latin1;";

            MySqlCommand c = new MySqlCommand(sql, conn);
            c.ExecuteNonQuery();
            sql = "ALTER TABLE `meraniax`  ADD PRIMARY KEY(`id`);";
            sql += "ALTER TABLE `headersx`  ADD PRIMARY KEY(`id`);";
            sql += "ALTER TABLE `rowsx` ADD PRIMARY KEY(`id`);";
            c = new MySqlCommand(sql, conn);
            c.ExecuteNonQuery();

            sql = "ALTER TABLE `rowsx` ADD CONSTRAINT `header_id` FOREIGN KEY (`header_id`) REFERENCES `headersx` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;";
            sql += "ALTER TABLE `meraniax` ADD CONSTRAINT `y_id` FOREIGN KEY (`y_id`) REFERENCES `rowsx` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;";
            c = new MySqlCommand(sql, conn);
            c.ExecuteNonQuery();
        }
        public Boolean open()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
        /// <summary>
        /// metoda close sa zaroven stara o to, aby do hlavicky merania ulozeny skutocny pocet cyklov, ak uzivatel zadal meranie bez prestania
        /// </summary>
        /// <returns>ci bol pokus o uzavretie spojenia uspesny</returns>
        public Boolean close()
        {
            try
            {
                if (conn != null)
                {
                    string sql = "update headers set cycles=(select max(r.cycle_num) from rows r where r.id=@akt) where id=@akt";
                    MySqlCommand c = new MySqlCommand(sql, conn);
                    c.Parameters.AddWithValue("@akt", aktualneMeranie);
                    c.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
        

        //=================================CITANIE=============================================

        private DataSet getDataSet(string sql)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// vrati tabulku krokov merani pre cyklus cislo cycleNum a pre meranie s id=headerId 
        /// </summary>
        /// <param name="headerId"></param>
        /// <param name="cycleNum">ak sa nezada, vrati vsetky cykly</param>
        /// <returns></returns>
        public DataSet meranie(int headerId, int cycleNum = 0)
        {
            string sql = "select m.x,r.y,m.sig,m.current,m.kapillar,m.chamber,m.temperature,r.cycle_num from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;
            if (cycleNum > 0)
            {
                sql += " and r.cycle_num= " + cycleNum;
            }
            return getDataSet(sql);
        }


        //metoda na vratenie zoznamu existujucich rokov kedy boli robene merania
        public DataSet roky()
        {
            string sql = "select distinct(extract(year from datetime)) as rok from headers order by rok asc";
            return getDataSet(sql);
        }

        /// <summary>
        /// vrati nazvy merani podla rokov
        /// </summary>
        /// <param name="rok">rok vo formate YYYY</param>
        /// <returns></returns>
        public DataSet nazvyMerani(string rok)
        {
            string sql = "select distinct(name) as nazov from headers where extract(year from datetime)="+rok+ " order by nazov asc";
            return getDataSet(sql);
        }
        /// <summary>
        /// vrati datumy podla roku a nazvu merani
        /// </summary>
        /// <param name="rok">rok vo formate YYYY</param>
        /// <param name="name">nazov merania</param>
        /// <returns>Vracia DataSet datumov merani</returns>
        public DataSet datumyMerani(string rok,string name)
        {
            string sql = "select distinct(date_format(datetime,'%d.%b')) as datum from headers where extract(year from datetime)=" + rok +" and name like '"+name+ "' order by datum asc";
            return getDataSet(sql);
        }

        /// <summary>
        /// vracia typy merani, ktore boli uskutocnene v zadanom datume a ktore maju nazov name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date">datum vo formate dd.MON,YYYY</param>
        /// <returns></returns>
        public DataSet typyMerani(string name,string date)
        {
            string sql = "select distinct(type_name) as typ from headers where name like '" + name+ "' and date_format(datetime,'%Y-%m-%d') like str_to_date('"+date+"','%d.%b,%Y') order by typ asc";
            return getDataSet(sql);
        }

        /// <summary>
        /// vrati id merani, ktore maju zadany nazov, boli merane v danom datume a maju dany typ
        /// </summary>
        /// <param name="name"></param>
        /// <param name="date">datum vo formate dd.MON,YYYY</param>
        /// <param name="typ"></param>
        /// <returns></returns>
        public DataSet merania(string name, string date,string typ)
        {
            string sql = "select id as cislo_merania from headers where name like '" + name + "' and date_format(datetime,'%Y-%m-%d') like str_to_date('" + date + "','%d.%b,%Y') and type_name like '" + typ+ "' order by cislo_merania asc";
            return getDataSet(sql);
        }

        public DataSet header(int headerId)
        {
            string sql =
                "select h.name,h.type_name,h.datetime,h.start_point,h.end_point,h.constant,h.resolution,h.steptime,h.cycles,h.note from headers h where id=" + headerId;

            return getDataSet(sql);
        }


        //==========================ZAPIS=============================

        long aktualneMeranie { get; set; }


        public void noveMeranie(MeasurementParameters mp)
        {

            MySqlCommand c = new MySqlCommand("insert into headers (name,type_name,start_point,end_point,constant,resolution,steptime,cycles,note) values(@name,@type_name,@start_point,@end_point,@constant,@resolution,@steptime,@cycles,@note)", conn);
            c.Parameters.AddWithValue("@name", mp.name);
            c.Parameters.AddWithValue("@type_name", mp.typ);
            c.Parameters.AddWithValue("@start_point", mp.startPoint);
            c.Parameters.AddWithValue("@end_point", mp.endPoint);
            c.Parameters.AddWithValue("@constant", mp.constant);
            c.Parameters.AddWithValue("@resolution", mp.resolution);
            c.Parameters.AddWithValue("@steptime", mp.stepTime);
            c.Parameters.AddWithValue("@cycles", mp.pocetCyklov);
            c.Parameters.AddWithValue("@note", mp.note);
            c.ExecuteNonQuery();
            aktualneMeranie = c.LastInsertedId;

        }

        private long getYID(double y, int cycle, long header)
        {
            string stm = "select id as m from rows where y=" + y + " and cycle_num=" + cycle + " and header_id=" + header;
            MySqlCommand cmd = new MySqlCommand(stm, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            long id;
            while (rdr.Read())
            {
                id = rdr.GetInt32(0);
                rdr.Close();
                return id;
            }
            rdr.Close();
            return novyRow(y, cycle, header);

        }


        long aktualnyRow;
        private long novyRow(double y, int cycle, long header)
        {
            MySqlCommand c = new MySqlCommand("insert into rows (y,cycle_num,header_id) values(@y,@cycle,@header)", conn);
            c.Parameters.AddWithValue("@y", y);
            c.Parameters.AddWithValue("@cycle", cycle);
            c.Parameters.AddWithValue("@header", header);

            c.ExecuteNonQuery();
            aktualnyRow = c.LastInsertedId;
            return c.LastInsertedId;
        }
        public void addKroky(List<KrokMerania> ks)
        {
            foreach (KrokMerania k in ks)
            {
                addKrok(k);
            }
        }
        public void addKrok(KrokMerania k)
        {
            long y_id = getYID(k.y, k.cyklus, aktualneMeranie); //ak neexistuje taky zaznam, vytvori novy a vrati id

            MySqlCommand c = new MySqlCommand("insert into merania (x,y_id,sig,current,kapillar,chamber,temperature) values(@x,@y_id,@sig,@current,@kapillar,@chamber,@temperature)", conn);
            c.Parameters.AddWithValue("@x", k.x);
            c.Parameters.AddWithValue("@y_id", y_id);
            c.Parameters.AddWithValue("@sig", k.sig);
            c.Parameters.AddWithValue("@current", k.current);
            c.Parameters.AddWithValue("@kapillar", k.kapillar);
            c.Parameters.AddWithValue("@chamber", k.chamber);
            c.Parameters.AddWithValue("@temperature", k.temperature);
            c.ExecuteNonQuery();
        }

      
    }
}