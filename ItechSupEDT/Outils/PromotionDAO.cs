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
    class PromotionDAO
    {
        public static Promotion creerPromotion(string nom, DateTime dateDebut, DateTime dateFin, Formation formation)
        {
            SqlCommand insertPromotion = new SqlCommand();
            insertPromotion.CommandText = "INSERT INTO Promotion (nom,dateDebut,dateFin,formation_id) VALUES (@nom,@dateDebut, @dateFin,@formationId)";
            insertPromotion.CommandType = CommandType.Text;
            insertPromotion.Connection = ConnexionBase.GetInstance().Conn;

            SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
            nomParam.Value = nom;

            SqlParameter dateDebutParam = new SqlParameter("dateDebut", SqlDbType.DateTime);
            dateDebutParam.Value = dateDebut;

            SqlParameter dateFinParam = new SqlParameter("dateFin", SqlDbType.DateTime);
            dateFinParam.Value = dateFin;

            SqlParameter formationIdParam = new SqlParameter("formationId", SqlDbType.Int); // même nom entre values et le SqlParameter
            formationIdParam.Value = formation.Id;



            insertPromotion.Parameters.Add(nomParam);
            insertPromotion.Parameters.Add(dateDebutParam);
            insertPromotion.Parameters.Add(dateFinParam);
            insertPromotion.Parameters.Add(formationIdParam);

      

            SqlDataReader reader = insertPromotion.ExecuteReader();
            reader.Read();
            int id = (int)reader.GetDecimal(0);


            Promotion nouvellePromotion = new Promotion(id, nom, dateDebut, dateFin, formation);
            return nouvellePromotion;
        }
    }
}
