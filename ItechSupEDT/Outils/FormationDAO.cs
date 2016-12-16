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

            insertFormation.CommandText = "INSERT INTO Formation (nom, nbHeureTotale) VALUES (@nom,@nbHeureTotales); SELECT SCOPE_IDENTITY();";
            insertFormation.CommandType = CommandType.Text;
            insertFormation.Connection = ConnexionBase.GetInstance().Conn;

            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;

            SqlParameter nbHeureTotaleParam = new SqlParameter("nbHeureTotales", SqlDbType.Float);
            nbHeureTotaleParam.Value = nbHeureTotales;

            insertFormation.Parameters.Add(nomParam);
            insertFormation.Parameters.Add(nbHeureTotaleParam);

            SqlDataReader reader = insertFormation.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);
            reader.Read();
            Formation nouvelleFormation = new Formation(id,nom,nbHeureTotales);
            return nouvelleFormation;
        }

        public static List<Formation> ListerFormation()
        {
            SqlCommand listerFormation = new SqlCommand();
            listerFormation.Connection = ConnexionBase.GetInstance().Conn;
            listerFormation.CommandText = "SELECT id, nom, nbHeureTotale FROM Formation";
            SqlDataReader reader = listerFormation.ExecuteReader();

            List<Formation> listeFormation = new List<Formation>();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id;
                    string nom;
                    float nbHeureTotale;
                    
                     
                    id = reader.GetInt32(0);
                    nom = reader.GetString(1);
                    if (!reader.IsDBNull(2))
                    {
                        nbHeureTotale = reader.GetFloat(2);
                    }
                    else
                    {
                        nbHeureTotale = 0;
                    }

                


                    Formation formation = new Formation(id, nom, (float) nbHeureTotale);
                    listeFormation.Add(formation);
                      
                }
            }

            return listeFormation;

        }

    }
}
