using ItechSupEDT.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Outils
{
    class FormationDAO
    {
        public static Formation creerFormation(string nom, float nbHeureTotales)
        {
            SqlCommand insertFormation = new SqlCommand();
            insertFormation.Connection = ConnexionBase.GetInstance().Conn;
     
            insertFormation.CommandText = "INSERT INTO formation (nom, duree) VALUES (@nom,@nbHeureTotales)";
            insertFormation.CommandType = CommandType.Text;
            insertFormation.Connection = ConnexionBase.GetInstance().Conn;

            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = AjoutFormation.nom;

            SqlParameter nbHeureTotaleParam = new SqlParameter("nbHeureTotale", SqlDbType.Float);
            nbHeureTotaleParam.Value = AjoutFormation.nbHeures;

            insertFormation.Parameters.Add(nomParam);
            insertFormation.Parameters.Add(nbHeureTotaleParam);

            insertFormation.ExecuteReader();
        }

    }
}
