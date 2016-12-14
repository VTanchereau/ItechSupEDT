using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class ConnexionBase
    {
        private static ConnexionBase instance;
        private SqlConnection conn;

        public SqlConnection Conn
        {
            get { return conn; }
            set { conn = value; }
        }


        /*rendre public l'instance mais empecher la création de nouvelle connexion*/
        public static ConnexionBase GetInstance()
        {
            if(instance == null)
            {
                instance = new ConnexionBase();
            }
            return instance;
        }
        private ConnexionBase()
        {
            this.Conn = new SqlConnection();
            Conn.ConnectionString = "Data Source=DESKTOP-7DO6T7D\COURS_SQL;Integrated Security=SSPI;Initial Catalog=gestionemploidutemps";
            Conn.Open();
        }
    }
}
