using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FPVProjekt
{


    //nutné změnit v app.config přihlašovací údaje do databáze

    internal class Pripojeni
    {

        private static SqlConnection conn = null;

        /// <summary>
        /// Metoda, která vrací instanci připojení a připojuje se k databázi
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetInstance()
        {

            if (conn == null)
            {
                conn = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"]);
                conn.Open();
            }
            return conn;
        }

        /// <summary>
        /// Metoda na odpojení z databáze
        /// </summary>
        public static void Odpojit()
        {
            conn.Close();
        }





    }
}
