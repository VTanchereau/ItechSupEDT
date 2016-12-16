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
    class MatiereDAO
    {
       public static Matiere creerMatiere(string nom)
        {
            SqlCommand insertMatiere = new SqlCommand();
            insertMatiere.Connection = ConnexionBase.GetInstance().Conn;
            insertMatiere.CommandText = "INSERT INTO Matiere(nom) VALUES(@nom);SELECT SCOPE_IDENTITY();";
            insertMatiere.CommandType = CommandType.Text;


            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;

            insertMatiere.Parameters.Add(nomParam);

            SqlDataReader reader = insertMatiere.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);
        

            Matiere nouvelleMatiere = new Matiere(id,nom);
            return nouvelleMatiere;
        }
    }

}
