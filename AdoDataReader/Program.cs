using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Sovellus hakee SQL serveriltä DemoxOy-tietokannasta lanaolt-taulusta kaikki tietueet.

namespace AdoDataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetData_DataReader();
            GetData_DataTable();
            Console.Read();
        }

        static void GetData_DataTable()
        {
            // UI-kerros datan esittämistä varten
            try
            {
                // Haetaan data DataTablen avulla
                //DataTable dt = GetDataSimple();
                DataTable dt = GetDataReal();
                string rivi = "";
                // Loopitetaan DataTablen rivit läpi
                foreach (DataRow dr in dt.Rows)
                {
                    rivi = "";
                    foreach (DataColumn dc in dt.Columns)
                    {
                        rivi += dr[dc].ToString() + " ";
                    }
                    Console.WriteLine(rivi);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
        }

        static DataTable GetDataSimple()
        {
            // Taulu
            DataTable dt = new DataTable();
            // Sarakkeet
            dt.Columns.Add("Firstname", typeof(string));
            dt.Columns.Add("Lastname", typeof(string));
            // Tietueet eli rivit
            dt.Rows.Add("Kalle", "Isokallio");
            dt.Rows.Add("Matt", "Nickerson");

            return dt;
        }

        static DataTable GetDataReal()
        {
            // DB-kerros, haetaan DemoxOy-tietokannasta taulun lasnaolot tietueet
            string sql;
            sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
            string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Avataan yhteys
                    conn.Open();
                    // Luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "lasnaolot");
                        return ds.Tables["lasnaolot"];
                    }
                }
            }
            catch (Exception error)
            {
                throw error;
                //Console.WriteLine(error);
                //return null;
            }
        }

        static void GetData_DataReader()
        {
            try
            {
                string sql;
                //sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot WHERE asioid='G7934'";
                sql = "SELECT asioid, lastname, firstname, date FROM lasnaolot";
                string connStr = @"Data source=eight.labranet.jamk.fi;initial catalog=DemoxOy;user=koodari;password=koodari13";
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Avataan yhteys
                    conn.Open();
                    // Luodaan komento = command-olio
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Luodaan reader
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            // Käydään reader läpi
                            if (rdr.HasRows)
                            {
                                while (rdr.Read())
                                {
                                    Console.WriteLine("{0}\t{1} {2}\t{3}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2), rdr.GetDateTime(3));
                                }                                
                            }
                            else
                            {
                                Console.WriteLine("Tietueita ei ole olemassa.");
                            }
                            // Suljetaan reader
                            rdr.Close();
                        }
                    }
                    // Suljetaan tietokantayhteys
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys suljettu onnistuneesti.");
                    Console.Read();
                } 
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.Read();
            }
        }
    }
}
