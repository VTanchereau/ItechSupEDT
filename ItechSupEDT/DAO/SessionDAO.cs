using ItechSupEDT.Modele;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.DAO
{
    class SessionDAO
    {
        public Session creeerSession(Promotion promotion, Formateur formateur, Matiere matiere, Salle salle, DateTime dateDebut, DateTime dateFin)
        {
            if (promotion == null)
                throw new SessionDAOException("La promotion n'est pas renseignée.");

            if (matiere == null)
                throw new SessionDAOException("La matière n'est pas renseignée.");

            if (salle == null)
                throw new SessionDAOException("La salle n'est pas renseignée.");

            if (dateDebut == null)
                throw new SessionDAOException("La date du début de la session n'est pas renseignée.");

            if (dateFin == null)
                throw new SessionDAOException("La date du fin de la session n'est pas renseignée.");

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Session_edt (Promotion_id,";
            if (formateur != null)
            {
                cmd.CommandText += " Formateur_id,";
            }
            cmd.CommandText += " Matiere_id, Salle_id, DateDebut, DateFin) output INSERTED.Id VALUES (@Promotion_id,";
            if (formateur != null)
            {
                cmd.CommandText += " @Formateur_id,";
            }
            cmd.CommandText += " @Matiere_id, @Salle_id, @DateDebut, @DateFin);";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Outils.ConnexionBase.GetInstance().Conn;

            SqlParameter paramPromotionId = new SqlParameter("Promotion_id", SqlDbType.VarChar);
            paramPromotionId.Value = promotion.Id;
            cmd.Parameters.Add(paramPromotionId);

            SqlParameter paramMatiereId = new SqlParameter("Matiere_id", SqlDbType.VarChar);
            paramMatiereId.Value = matiere.Id;
            cmd.Parameters.Add(paramMatiereId);

            SqlParameter paramSalleId = new SqlParameter("Salle_id", SqlDbType.VarChar);
            paramSalleId.Value = salle.Id;
            cmd.Parameters.Add(paramSalleId);

            SqlParameter paramDateDebut = new SqlParameter("DateDebut", SqlDbType.Int);
            paramDateDebut.Value = dateDebut;
            cmd.Parameters.Add(paramDateDebut);

            SqlParameter paramDateFin = new SqlParameter("DateFin", SqlDbType.Int);
            paramDateFin.Value = dateFin;
            cmd.Parameters.Add(paramDateFin);

            if (formateur != null)
            {
                SqlParameter paramFormateurId = new SqlParameter("Formateur_id", SqlDbType.Int);
                paramFormateurId.Value = formateur.Id;
                cmd.Parameters.Add(paramFormateurId);
            }

            int idEleve = (int)cmd.ExecuteScalar();

            return new Session(dateDebut, dateFin, promotion, matiere, salle, formateur);
        }
        public class SessionDAOException : Exception
        {
            public SessionDAOException(string message) : base(message)
            {
            }
            public SessionDAOException(string message, Exception innerException) : base(message, innerException)
            {
            }
        }
    }

}
