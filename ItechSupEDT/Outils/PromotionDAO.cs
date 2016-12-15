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
        public static PromotionDAO(string nom, DateTime dateDebut, DateTime dateFin, int formation_id)
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

            SqlParameter formationIdParam = new SqlParameter("formation_id", SqlDbType.Int);
            formationIdParam.Value = formation_id;
;


        insertPromotion.Parameters.Add(nomParam);
            insertPromotion.Parameters.Add(dateDebutParam);
            insertPromotion.Parameters.Add(dateFinParam);
            insertPromotion.Parameters.Add(formationIdParam);

            insertPromotion.ExecuteReader();
        }
    }
}
