using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.ICT.JSON
{
    public class JSONPlacebo2015
    {
        public bool isInitialized;
        public JSONPlacebo2015()
        {
            isInitialized = true;
        }
        public string Yield()
        {
            //TODO hae opettajan kertomasta palvelusta JSONia
            return "Hello JSON!";
        }

        public static DataTable GetTestCustomers()
        {
            //create
            DataTable dt = new DataTable();
            //columns
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("LastName", typeof(string));
            dt.Columns.Add("FirstName", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("ZIP", typeof(string));
            dt.Columns.Add("City", typeof(string));
            //rows
            dt.Rows.Add("A3581", "Waltari", "Mika", "Piippukatu 2", "42052", "Jyväskylä");
            dt.Rows.Add("B3553", "King", "Stephen", "Piippukatu 2", "42052", "Jyväskylä");
            dt.Rows.Add("C1238", "Neruda", "Pablo", "Piippukatu 2", "42052", "Jyväskylä");
            dt.Rows.Add("D9876", "Oksanen", "Sofi", "Piippukatu 2", "42052", "Jyväskylä");
            return dt;
        }

        public static DataTable GetAllCustomersFromSQLServer(string city, string connectionStr, string taulu, out string viesti)
        {
            // basic principle: connect - execute query - disconnect
            try
            {
                SqlConnection myConn = new SqlConnection(connectionStr);
                myConn.Open();
                SqlCommand cmd;
                if (city == "")
                {
                    cmd = new SqlCommand("SELECT * FROM " + taulu, myConn);
                } else
                {
                    cmd = new SqlCommand("SELECT * FROM " + taulu + " WHERE city='" + city +"'", myConn);
                }
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, taulu);
                viesti = "Tiedot haettu onnistuneesti tietokannasta " + myConn.DataSource;
                return ds.Tables[taulu];
            }
            catch (Exception ex)
            {
                viesti = ex.Message;
                throw;
            }
        }


    }
}
