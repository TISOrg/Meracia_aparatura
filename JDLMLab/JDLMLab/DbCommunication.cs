﻿using System;
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
            "`note` varchar(500) NOT NULL,PRIMARY KEY(`id`),KEY `id(PK)` (`id`)) ENGINE = InnoDB AUTO_INCREMENT = 29 DEFAULT CHARSET = latin1;";
            sql += "CREATE TABLE `rows` (`id` int(11) NOT NULL AUTO_INCREMENT,`y` double NOT NULL,`cycle_num` int(254) NOT NULL,`header_id` int(11) NOT NULL,PRIMARY KEY(`id`),KEY `header_id(PK)` (`header_id`),KEY `id` (`id`),CONSTRAINT `obmedzenie` FOREIGN KEY (`header_id`) REFERENCES `headers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE) ENGINE = InnoDB AUTO_INCREMENT = 28 DEFAULT CHARSET = latin1 ;";
            sql += "CREATE TABLE `merania` (`id` int(11) NOT NULL AUTO_INCREMENT,`x` double NOT NULL,`y_id` int(11) NOT NULL,`sig` int(11) NOT NULL,`current` double NOT NULL,`kapillar` double NOT NULL,`chamber` double NOT NULL,`temperature` double NOT NULL,PRIMARY KEY(`id`),KEY `id_y` (`y_id`),CONSTRAINT `obmedzenie2` FOREIGN KEY (`y_id`) REFERENCES `rows` (`id`) ON DELETE CASCADE ON UPDATE CASCADE) ENGINE = InnoDB AUTO_INCREMENT = 90 DEFAULT CHARSET = latin1;";

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
            string sql = "select m.x,r.y,m.sig,m.current,m.kapillar,m.chamber,m.temperature,r.cycle_num from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;
            if (cycleNum > 0)
            {
                sql += " and r.cycle_num= " + cycleNum;
            }
            sql += " order by r.cycle_num asc,r.y asc,m.x asc";
            return getDataSet(sql);
        }
        public DataSet meraniePreGraf(int headerId)
        {
            string sql = "select m.x as x,m.sig as y,r.cycle_num as cyklus from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;
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
            string sql = "select m.x,r.y,avg(m.sig) as sum,m.current,m.kapillar,m.chamber,m.temperature from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;
            sql += " group by m.x order m.x asc";
            return getDataSet(sql);
        }
        /// <summary>
        /// vrati dataset ako v pripade meranie, ale bez stplca cyklus, a namiesto hodnoty Signal, obsahuje sucet vsetkych hodnot signal pre kazdy cyklus pre dane x. Ostatne hodnoty zobrazi take ake boli pre prvy cyklus
        /// </summary>
        /// <param name="headerId"></param>
        /// <returns></returns>
        public DataSet meranieSum(int headerId)
        {
            string sql = "select m.x,r.y,sum(m.sig) as sum,m.current,m.kapillar,m.chamber,m.temperature from merania m left join rows r on r.id = m.y_id where header_id = " + headerId;
            sql += " group by m.x order m.x asc";
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

            MySqlCommand c = new MySqlCommand("select type_name from headers where id=@header_id", conn);
            c.Parameters.AddWithValue("@header_id", headerId);
            conn.Open();
            MySqlDataReader rdr = c.ExecuteReader();
            string typ="";
            while (rdr.Read())
            {
                typ = rdr.GetString(0);
            }
            rdr.Close();
            conn.Close();

            string sql="";
            if(typ.Equals("Energy Scan"))
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


        //==========================ZAPIS=============================

        long aktualneMeranie { get; set; }


        public void vytvoritNoveMeranie(MeasurementParameters mp)
        {
            
            MySqlCommand c = new MySqlCommand("insert into headers (name,type_name,resolution,cycles,note) values(@name,@type_name,@resolution,@cycles,@note)", conn);

            c.Parameters.AddWithValue("@name", mp.Name);
            c.Parameters.AddWithValue("@type_name", mp.Typ);
            c.Parameters.AddWithValue("@resolution", mp.Resolution);
            c.Parameters.AddWithValue("@cycles", mp.PocetCyklov);
            c.Parameters.AddWithValue("@note", mp.Note);
            c.ExecuteNonQuery();
            aktualneMeranie = c.LastInsertedId;

            if (mp.Typ.Equals("Energy Scan"))
            {
                c = new MySqlCommand("insert into energy_scan_header (header_id,start_point,end_point,constant,steptime,pocet_krokov) values(@header_id,@start_point,@end_point,@constant,@steptime,@pocet_krokov)", conn);
                c.Parameters.AddWithValue("@header_id",aktualneMeranie);
                c.Parameters.AddWithValue("@steptime", ((EnergyScanParameters)mp).StepTime);
                c.Parameters.AddWithValue("@start_point", ((EnergyScanParameters)mp).StartPoint);
                c.Parameters.AddWithValue("@end_point", ((EnergyScanParameters)mp).EndPoint);
                c.Parameters.AddWithValue("@constant", ((EnergyScanParameters)mp).Constant);
                c.Parameters.AddWithValue("@pocet_krokov", ((EnergyScanParameters)mp).PocetKrokov);
            }
            else if (mp.Typ.Equals("Mass Scan"))
            {
                c = new MySqlCommand("insert into mass_scan_header (header_id,start_point,end_point,constant,steptime) values(@header_id,@start_point,@end_point,@constant,@steptime)", conn);
                c.Parameters.AddWithValue("@header_id", aktualneMeranie);
                c.Parameters.AddWithValue("@steptime", ((MassScanParameters)mp).StepTime);
                c.Parameters.AddWithValue("@start_point", ((MassScanParameters)mp).StartPoint);
                c.Parameters.AddWithValue("@end_point", ((MassScanParameters)mp).EndPoint);
                c.Parameters.AddWithValue("@constant", ((MassScanParameters)mp).Constant);
                
            }
            else if (mp.Typ.Equals("2D Scan"))
            {
                c = new MySqlCommand("insert into scan2d_header(header_id,e_start_point,e_end_point,e_steptime,pocet_krokov,m_start_point,m_end_point,m_steptime) values (@header_id,@e_start_point,@e_end_point,@e_steptime,@pocet_krokov,@m_start_point,@m_end_point,@m_steptime)", conn);
                c.Parameters.AddWithValue("@header_id", aktualneMeranie);
                c.Parameters.AddWithValue("@e_steptime", ((Scan2DParameters)mp).EnergyScanParameters.StepTime);
                c.Parameters.AddWithValue("@e_start_point", ((Scan2DParameters)mp).EnergyScanParameters.StartPoint);
                c.Parameters.AddWithValue("@e_end_point", ((Scan2DParameters)mp).EnergyScanParameters.EndPoint);
                c.Parameters.AddWithValue("@pocet_krokov", ((Scan2DParameters)mp).EnergyScanParameters.PocetKrokov);
                c.Parameters.AddWithValue("@m_steptime", ((Scan2DParameters)mp).MassScanParameters.StepTime);
                c.Parameters.AddWithValue("@m_start_point", ((Scan2DParameters)mp).MassScanParameters.StartPoint);
                c.Parameters.AddWithValue("@m_end_point", ((Scan2DParameters)mp).MassScanParameters.EndPoint);

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
            long y_id = getYID(k.y, cyklus, aktualneMeranie); //ak neexistuje taky zaznam, vytvori novy a vrati id

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
        public void addCyklus(CyklusMerania c)
        {
            addKroky(c.getKroky(),c.cisloCyklu);
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