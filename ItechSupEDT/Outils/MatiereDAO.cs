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
            insertMatiere.CommandText = "INSERT INTO Matiere(nom) VALUES(@nom)";
            insertMatiere.CommandType = CommandType.Text;


            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;

           insertMatiere.Parameters.Add(nomParam);
           insertMatiere.ExecuteReader();

            Matiere nouvelleMatiere = new Matiere(nom);
            return nouvelleMatiere;
        }
    }

}
