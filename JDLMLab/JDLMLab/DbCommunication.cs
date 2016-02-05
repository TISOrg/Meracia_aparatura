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
        
        private MySqlConnection conn;

        private static string setConnectionString()
        {
            string c=
                "Server=" + Database.Default.host +
                ";Port=" + Database.Default.port.ToString() +
                ";Database=" + Database.Default.database +
                ";Uid=" + Database.Default.user +
                ";Password=" + Database.Default.password;

            return c;
        }
        public static void testConnection()
        {
            MySqlConnection test = new MySqlConnection(setConnectionString());
            test.Open();
            test.Close();
        }

        public DbCommunication()
        {
            conn = new MySqlConnection(setConnectionString());

            bool tabulkyExistuju = false; 
            MySqlCommand c = new MySqlCommand("show tables like 'headers'", conn);
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
            string sql="CREATE TABLE `headers` (`id` int(100) NOT NULL AUTO_INCREMENT,`name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_mysql500_ci DEFAULT NULL,"+
            "`type_name` varchar(200) NOT NULL,`datetime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,`start_point` double NOT NULL,"+
            "`end_point` double NOT NULL,`constant` double NOT NULL,`resolution` double NOT NULL,`steptime` double NOT NULL,`cycles` int(254) NOT NULL,"+
            "`note` varchar(500) NOT NULL,`ion_type` tinyint(1) NOT NULL,PRIMARY KEY(`id`),KEY `id(PK)` (`id`)) ENGINE = InnoDB AUTO_INCREMENT = 29 DEFAULT CHARSET = latin1;";
            sql += "CREATE TABLE `rows` (`id` int(11) NOT NULL AUTO_INCREMENT,`y` double NOT NULL,`cycle_num` int(254) NOT NULL,`header_id` int(11) NOT NULL,PRIMARY KEY(`id`),KEY `header_id(PK)` (`header_id`),KEY `id` (`id`),CONSTRAINT `obmedzenie` FOREIGN KEY (`header_id`) REFERENCES `headers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE) ENGINE = InnoDB AUTO_INCREMENT = 28 DEFAULT CHARSET = latin1 ;";
            sql += "CREATE TABLE `merania` (`id` int(11) NOT NULL AUTO_INCREMENT,`x` double NOT NULL,`y_id` int(11) NOT NULL,`Intensity` bigint(11) unsigned NOT NULL,`Current` double NOT NULL,`Capillar_pressure` double NOT NULL,`Chamber_pressure` double NOT NULL,`Temperature` double NOT NULL,PRIMARY KEY(`id`),KEY `id_y` (`y_id`),CONSTRAINT `obmedzenie2` FOREIGN KEY (`y_id`) REFERENCES `rows` (`id`) ON DELETE CASCADE ON UPDATE CASCADE) ENGINE = InnoDB AUTO_INCREMENT = 90 DEFAULT CHARSET = latin1;";

            sql+="CREATE TABLE `energy_scan_header` ("+
	            "`id` INT(11) NOT NULL AUTO_INCREMENT,"+
	            "`header_id` INT(11) NOT NULL,"+
	            "`start_point` DOUBLE NOT NULL,"+
	            "`end_point` DOUBLE NOT NULL,"+
	            "`constant` DOUBLE NOT NULL,"+
	            "`steptime` DOUBLE NOT NULL,"+
	            "`pocet_krokov` INT(11) NOT NULL,"+
                "PRIMARY KEY(`id`),"+
                "INDEX `header_id` (`header_id`),"+
                "CONSTRAINT `es_header_contraint` FOREIGN KEY (`header_id`) REFERENCES `headers` (`id`) ON UPDATE CASCADE ON DELETE CASCADE)" +
                "COLLATE = 'utf8_slovak_ci'"+
                "ENGINE = InnoDB; ";
            sql += "CREATE TABLE `mass_scan_header` (" +
                "`id` INT(11) NOT NULL AUTO_INCREMENT," +
                "`header_id` INT(11) NOT NULL," +
                "`start_point` DOUBLE NOT NULL," +
                "`end_point` DOUBLE NOT NULL," +
                "`constant` DOUBLE NOT NULL," +
                "`time_for_amu` double NOT NULL," +
                "`density` int(11) NOT NULL," +
                "PRIMARY KEY(`id`)," +
                "INDEX `header_id` (`header_id`)," +
                "CONSTRAINT `ms_header_contraint` FOREIGN KEY (`header_id`) REFERENCES `headers` (`id`) ON UPDATE CASCADE ON DELETE CASCADE)" +
                "COLLATE = 'utf8_slovak_ci'" +
                "ENGINE = InnoDB; ";

            sql+="CREATE TABLE `scan2d_header` ("+
                "`id` INT(11) NOT NULL AUTO_INCREMENT," +
                "`header_id` INT(11) NOT NULL," +
                "`e_start_point` DOUBLE NOT NULL," +
                "`e_end_point` DOUBLE NOT NULL," +
                "`e_steptime` DOUBLE NOT NULL," +
                "`pocet_krokov` INT(11) NOT NULL," +
                "`m_start_point` DOUBLE NOT NULL," +
                "`m_end_point` DOUBLE NOT NULL," +
                "`time_for_amu` double NOT NULL,"+
                "`density` int(11) NOT NULL,"+
                "PRIMARY KEY (`id`)," +
                "INDEX `header_id` (`header_id`)," +
                "CONSTRAINT `s2_header_contraint` FOREIGN KEY (`header_id`) REFERENCES `headers` (`id`) ON UPDATE CASCADE ON DELETE CASCADE)" +
                "COLLATE = 'utf8_slovak_ci'" +
                "ENGINE = InnoDB;";


            MySqlCommand c = new MySqlCommand(sql, conn);
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
                    string sql = "update headers set cycles=(select max(r.cycle_num) from rows r where r.header_id=@akt) where id=@akt";
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
            string typ = typeOf(headerId);
            
            string xAlias="x";
            string yAlias = "y";
            if (typ.Equals("Energy Scan")) 
            {
                xAlias = "'Electron energy'";
                yAlias = "'m/z'";
            }
            if (typ.Equals("Mass Scan"))
            {
                xAlias = "'m/z'";
                yAlias = "'Electron energy'";
            }
            
            if (typ.Equals("2D Scan"))
            {
                xAlias = "'m/z'";
                yAlias = "'Electron energy'";
            }
            string sql = "select m.x as "+xAlias+",r.y as "+yAlias+ ",m.Intensity,m.Current,m.Capillar_pressure as 'Capillar pressure',m.Chamber_pressure as 'Chamber pressure',m.Temperature,r.cycle_num from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;

            if (cycleNum > 0)
            {
                sql += " and r.cycle_num= " + cycleNum;
            }
            sql += " order by r.y asc,m.x asc,r.cycle_num asc ";
            
            return getDataSet(sql);
        }
        public DataSet meraniePreGraf(int headerId)
        {
            string sql = "select m.x as x,m.Intensity as y,r.cycle_num as cyklus from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;
            sql += " order by cyklus asc,x asc";
            return getDataSet(sql);
        }

        /// <summary>
        /// vrati dataset ako v pripade meranie, ale bez stplca cyklus, a namiesto hodnoty Signal, obsahuje priemer hodnot signal pre kazdy cyklus pre dane x. Ostatne hodnoty zobrazi take ake boli pre prvy cyklus
        /// </summary>
        /// <param name="headerId"></param>
        /// <returns></returns>
        public DataSet meranieAvg(int headerId)
        {
            string typ = typeOf(headerId);

            string xAlias = "x";
            string yAlias = "y";
            if (typ.Equals("Energy Scan"))
            {
                xAlias = "'Electron energy'";
                yAlias = "'m/z'";
            }
            if (typ.Equals("Mass Scan"))
            {
                xAlias = "'m/z'";
                yAlias = "'Electron energy'";
            }

            if (typ.Equals("2D Scan"))
            {
                xAlias = "'m/z'";
                yAlias = "'Electron energy'";
            }

            string sql = "select m.x as "+xAlias+",r.y as "+yAlias+ ",avg(m.Intensity) as Intensity,m.Current,m.Capillar_pressure as 'Capillar pressure',m.Chamber_pressure as 'Chamber pressure',m.Temperature from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;
            sql += " group by m.x order by r.y asc,m.x asc";

            return getDataSet(sql);
        }
        /// <summary>
        /// vrati dataset ako v pripade meranie, ale bez stplca cyklus, a namiesto hodnoty Signal, obsahuje sucet vsetkych hodnot signal pre kazdy cyklus pre dane x. Ostatne hodnoty zobrazi take ake boli pre prvy cyklus
        /// </summary>
        /// <param name="headerId"></param>
        /// <returns></returns>
        public DataSet meranieSum(int headerId)
        {
            string typ = typeOf(headerId);

            string xAlias = "x";
            string yAlias = "y";
            if (typ.Equals("Energy Scan"))
            {
                xAlias = "'Electron energy'";
                yAlias = "'m/z'";
            }
            if (typ.Equals("Mass Scan"))
            {
                xAlias = "'m/z'";
                yAlias = "'Electron energy'";
            }

            if (typ.Equals("2D Scan"))
            {
                xAlias = "'m/z'";
                yAlias = "'Electron energy'";
            }

            string sql = "select m.x as "+ xAlias + ",r.y as " + yAlias + ",sum(m.Intensity) as Intensity,m.Current,m.Capillar_pressure as 'Capillar pressure',m.Chamber_pressure as 'Chamber pressure',m.Temperature from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;
            sql += " group by m.x order by r.y asc,m.x asc";
            return getDataSet(sql);
        }

        //metoda na vratenie zoznamu existujucich rokov kedy boli robene merania
        public DataSet roky()
        {
            string sql = "select distinct(extract(year from datetime)) as rok from headers order by rok desc";
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
            string sql = "select distinct(date_format(datetime,'%d.%b')) as datum from headers where extract(year from datetime)=" + rok +" and name like '"+name+ "' order by datum desc";
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
            string typ = typeOf(headerId);

            string sql = "";
            if (typ.Equals("Energy Scan"))
            {
                sql =
                "select * from headers h left join energy_scan_header e on e.header_id=h.id where h.id=" + headerId;
            }
            if (typ.Equals("Mass Scan"))
            {
                sql =
                "select * from headers h left join mass_scan_header e on e.header_id=h.id where h.id=" + headerId;
            }
            if (typ.Equals("2D Scan"))
            {
                sql =
                "select * from headers h left join scan2d_header e on e.header_id=h.id where h.id=" + headerId;
            }


            return getDataSet(sql);
        }

        public string typeOf(int headerId)
        {
            MySqlCommand c = new MySqlCommand("select type_name from headers where id=@header_id", conn);
            c.Parameters.AddWithValue("@header_id", headerId);
            conn.Open();
            MySqlDataReader rdr = c.ExecuteReader();
            string typ = "";
            while (rdr.Read())
            {
                typ = rdr.GetString(0);
            }
            rdr.Close();
            conn.Close();
            return typ;
        }


        //==========================ZAPIS=============================

        long aktualneMeranie { get; set; }


        public void vytvoritNoveMeranie(MeasurementParameters mp)
        {
            
            MySqlCommand c = new MySqlCommand("insert into headers (name,type_name,resolution,cycles,note,ion_type) values(@name,@type_name,@resolution,@cycles,@note,@ion_type)", conn);

            c.Parameters.AddWithValue("@name", mp.Name);
            c.Parameters.AddWithValue("@type_name", mp.Typ);
            c.Parameters.AddWithValue("@resolution", mp.Resolution);
            c.Parameters.AddWithValue("@cycles", mp.NumberOfCycles);
            c.Parameters.AddWithValue("@note", mp.Note);
            c.Parameters.AddWithValue("@ion_type", mp.IonType);
            c.ExecuteNonQuery();
            aktualneMeranie = c.LastInsertedId;

            if (mp.Typ.Equals("Energy Scan"))
            {
                c = new MySqlCommand("insert into energy_scan_header (header_id,start_point,end_point,constant,steptime,pocet_krokov) values(@header_id,@start_point,@end_point,@constant,@steptime,@pocet_krokov)", conn);
                c.Parameters.AddWithValue("@header_id",aktualneMeranie);
                c.Parameters.AddWithValue("@steptime", (mp.StepTime));
                c.Parameters.AddWithValue("@start_point", (mp.EnergyScan.StartPoint));
                c.Parameters.AddWithValue("@end_point", (mp.EnergyScan.EndPoint));
                c.Parameters.AddWithValue("@constant", (mp.EnergyScan.Constant));
                c.Parameters.AddWithValue("@pocet_krokov", (mp.NumberOfSteps));
            }
            else if (mp.Typ.Equals("Mass Scan"))
            {
                c = new MySqlCommand("insert into mass_scan_header (header_id,start_point,end_point,constant,time_for_amu,density) values(@header_id,@start_point,@end_point,@constant,@time_for_amu,@density)", conn);
                c.Parameters.AddWithValue("@header_id", aktualneMeranie);
                c.Parameters.AddWithValue("@time_for_amu", (mp.MassScan.TimePerAmu));
                c.Parameters.AddWithValue("@density", (mp.MassScan.Density));
                c.Parameters.AddWithValue("@start_point", (mp.MassScan.StartPoint));
                c.Parameters.AddWithValue("@end_point", (mp.MassScan.EndPoint));
                c.Parameters.AddWithValue("@constant", (mp.MassScan.Constant));
                
            }
            else if (mp.Typ.Equals("2D Scan"))
            {
                c = new MySqlCommand("insert into scan2d_header(header_id,e_start_point,e_end_point,e_steptime,pocet_krokov,m_start_point,m_end_point,time_for_amu,density) values (@header_id,@e_start_point,@e_end_point,@e_steptime,@pocet_krokov,@m_start_point,@m_end_point,@time_for_amu,@density)", conn);
                c.Parameters.AddWithValue("@header_id", aktualneMeranie);
                c.Parameters.AddWithValue("@e_steptime", (mp.EnergyScan.StepTime));
                c.Parameters.AddWithValue("@e_start_point", (mp.EnergyScan.StartPoint));
                c.Parameters.AddWithValue("@e_end_point", (mp.EnergyScan.EndPoint));
                c.Parameters.AddWithValue("@pocet_krokov", (mp.EnergyScan.NumberOfSteps));
                c.Parameters.AddWithValue("@time_for_amu", (mp.MassScan.TimePerAmu));
                c.Parameters.AddWithValue("@density", (mp.MassScan.Density));
                c.Parameters.AddWithValue("@m_start_point", (mp.MassScan.StartPoint));
                c.Parameters.AddWithValue("@m_end_point", (mp.MassScan.EndPoint));

            }
            c.ExecuteNonQuery();
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


        
        private long novyRow(double y, int cycle, long header)
        {
            MySqlCommand c = new MySqlCommand("insert into rows (y,cycle_num,header_id) values(@y,@cycle,@header)", conn);
            c.Parameters.AddWithValue("@y", y);
            c.Parameters.AddWithValue("@cycle", cycle);
            c.Parameters.AddWithValue("@header", header);

            c.ExecuteNonQuery();
            return c.LastInsertedId;
        }
        public void addKroky(List<KrokMerania> ks,int cyklus=1)
        {
            foreach (KrokMerania k in ks)
            {
                addKrok(k,cyklus);
            }
        }
        public void addKrok(KrokMerania k,int cyklus=1)
        {
            long y_id = getYID(k.Y, cyklus, aktualneMeranie); //ak neexistuje taky zaznam, vytvori novy a vrati id

            MySqlCommand c = new MySqlCommand("insert into merania (x,y_id,Intensity,Current,Capillar_pressure,Chamber_pressure,Temperature) "+
                "values(@x,@y_id,@sig,@current,@kapillar,@chamber,@temperature)", conn);
            
            c.Parameters.AddWithValue("@x", k.X);
            c.Parameters.AddWithValue("@y_id", y_id);
            c.Parameters.AddWithValue("@sig", k.Intensity);
            c.Parameters.AddWithValue("@current", k.Current);
            c.Parameters.AddWithValue("@kapillar", k.Capillar);
            c.Parameters.AddWithValue("@chamber", k.Chamber);
            c.Parameters.AddWithValue("@temperature", k.Temperature);
           
            c.ExecuteNonQuery();
        }
        public void addCyklus(CyklusMerania c)
        {
            addKroky(c.KrokyMerania,c.cisloCyklu);
        }
        internal void addMeranie(Meranie meranie)
        {
            foreach(CyklusMerania c in meranie.cykly)
            {
                addCyklus(c);
            }
        }


    }
}