using System;
using System.Collections.Generic;
using System.Data;
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
            _SQLcnx.Open();
        }

      
        internal static void AjouterParametre(SqlCommand cmd, string nom, object valeur, DbType type, int size = 0)
        {
            /*IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = nom;
            param.Value = valeur ?? DBNull.Value;
            if (size != 0)
                param.Size = size;
            param.DbType = type;
            cmd.Parameters.Add(param);*/

           
        }




    }
}
