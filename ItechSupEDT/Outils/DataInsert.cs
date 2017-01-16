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
    class DataInsert
    {
        private static SqlConnection cnx = null;

        public static void AjouterPromotion(String nom, DateTime dateDebut, DateTime dateFin, int idformation)
        {
            Promotion promotion = new Promotion(nom, dateDebut, dateFin, idformation);
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " INSERT INTO dbo.Promotion(nom,dateDebut,dateFin,id_formation)"+
                                  " VALUES (@nom,@dateDebut,@dateFin,@id_formation); ";
                
                AjouterParametres(cmd, "nom", SqlDbType.VarChar, promotion.Nom);
                AjouterParametres(cmd, "dateDebut", SqlDbType.DateTime, promotion.DateDebut);
                AjouterParametres(cmd, "dateFin", SqlDbType.DateTime, promotion.DateFin);
                AjouterParametres(cmd, "id_formation", SqlDbType.Int, promotion.Id_Formation);

                cmd.Connection = cnx;
                promotion.Id = (int)cmd.ExecuteScalar();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
        }

        public static void AjouterMatiere(String nom)
        {
            Matiere matiere = new Matiere(nom);
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " INSERT INTO dbo.Matiere(nom) "+
                                  " VALUES (@nom);";

                AjouterParametres(cmd,"nom", SqlDbType.VarChar, matiere.Nom);
                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
           
        }

        public static void AjouterFormateur(String nom, String prenom, String tel, String mail, List<Matiere> listeMatieres)
        {
            Formateur formateur = new Formateur(nom, prenom, mail, tel, listeMatieres);
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " INSERT INTO dbo.Formateur(nom,prenom,tel,mail)"+
                                  " VALUES (@nom,@prenom,@tel,@mail);";

                AjouterParametres(cmd, "nom", SqlDbType.VarChar, formateur.Nom);
                AjouterParametres(cmd, "prenom", SqlDbType.VarChar, formateur.Prenom);
                AjouterParametres(cmd, "tel", SqlDbType.VarChar, formateur.Telephone);
                AjouterParametres(cmd, "mail", SqlDbType.VarChar, formateur.Mail);

                cmd.Connection = cnx;
                formateur.Id = (int)cmd.ExecuteScalar();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

        }

        public static void AjouterFormation(String nom, float duree)
        {
            Formation formation = new Formation(nom, duree);
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " INSERT INTO dbo.Formation(nom,nbHeures) VALUES (@nom,@duree);";
                
                AjouterParametres(cmd, "nom", SqlDbType.VarChar, formation.Nom);
                AjouterParametres(cmd, "nbHeures", SqlDbType.Float, formation.NbHeuresTotal);

                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
           
        }

        public static void AjouterEleve(String nom, String prenom, String mail, Promotion promotion)
        {
            Eleve eleve = new Eleve(nom, prenom, mail, promotion);
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                //IDbCommand cmd = cnx.SQL_CNX.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " INSERT INTO dbo.Eleve(nom,prenom,mail,id_promotion) VALUES (@nom,@prenom,@mail,@id_promotion);";
                
                AjouterParametres(cmd, "nom", SqlDbType.VarChar, eleve.Nom);
                AjouterParametres(cmd, "prenom", SqlDbType.VarChar, eleve.Prenom);
                AjouterParametres(cmd, "mail", SqlDbType.VarChar, eleve.Mail);
                AjouterParametres(cmd, "id_promotion", SqlDbType.Int, eleve.Promotion.Id);

                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

        }

        public static void AjouterSalle(String nom, int capacite)
        {
            Salle formation = new Salle(nom, capacite);
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = " INSERT INTO dbo.Salle(nom,capacite) VALUES (@nom,@capacite);";

                AjouterParametres(cmd, "nom", SqlDbType.VarChar, formation.Nom);
                AjouterParametres(cmd, "capacite", SqlDbType.Int, formation.Capacite);

                cmd.Connection = cnx;
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }

        }

        private static void AjouterParametres(SqlCommand cmd, String column, SqlDbType type, Object value)
        {
            cmd.CommandType = CommandType.Text;
            SqlParameter nomParam = new SqlParameter(column, type);
            nomParam.Value = value;
            cmd.Parameters.Add(nomParam);
        }
    }
}
