using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class Connexion
    {
        static private Connexion instance;

        private SqlConnection _SQLcnx;

        public SqlConnection SQL_CNX
        {
            get { return _SQLcnx; }
            set { _SQLcnx = value; }
        }

        public static Connexion getInstance()
        {
            if(instance == null)
            {
                instance = new Connexion();
            }
            return instance;
        }

        private Connexion()
        {
            this._SQLcnx = new SqlConnection();
            _SQLcnx.ConnectionString="Data Source=DESKTOP-VJ22J29\\SQLEXPRESS;Initial Catalog=GestionEDT;Integrated Security=True";
        }


        
           
    }
}
