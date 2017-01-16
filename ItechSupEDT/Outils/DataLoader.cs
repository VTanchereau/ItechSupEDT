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
    class DataLoader
    {
        private static SqlConnection cnx = null;

        public static List<Matiere> ChargerMatieres()
        {
            List<Matiere> listeMatieres = new List<Matiere>();
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = "SELECT id, nom FROM dbo.Matiere";
                SqlDataReader lecteur = cmd.ExecuteReader();
                while (lecteur.Read())
                {
                    int id = 0;
                    String nom = null;

                    if (!lecteur.IsDBNull(0))
                        id = lecteur.GetInt32(0);
                    if (!lecteur.IsDBNull(1))
                        nom = lecteur.GetString(1);

                    listeMatieres.Add(new Matiere(nom));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listeMatieres;
        }

        public static List<Formation> ChargerFormations()
        {
            List<Formation> listeFormations = new List<Formation>();
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = cnx.CreateCommand();

                cmd.CommandText = "SELECT id, nom, nbHeures FROM dbo.Formation";

                SqlDataReader lecteur = cmd.ExecuteReader();
                while (lecteur.Read())
                {
                    int id = 0;
                    String nom = "";
                    float nbHeures = 0;

                    if (!lecteur.IsDBNull(0))
                        id = lecteur.GetInt32(0);
                    if (!lecteur.IsDBNull(1))
                        nom = lecteur.GetString(1);
                    if (!lecteur.IsDBNull(2))
                        nbHeures = (float)lecteur.GetDouble(2);
                    
                    listeFormations.Add(new Formation(nom, nbHeures, id));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listeFormations;
        }

      /*  public static List<Eleve> ChargerEleves()
        {

            List<Eleve> listeEleves = new List<Eleve>();
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = cnx.CreateCommand();

                cmd.CommandText = "SELECT id, nom FROM dbo.Eleve";

                SqlDataReader lecteur = cmd.ExecuteReader();
                while (lecteur.Read())
                {
                    int id = 0;
                    String nom = null;

                    if (!lecteur.IsDBNull(0))
                        id = lecteur.GetInt32(0);
                    if (!lecteur.IsDBNull(1))
                        nom = lecteur.GetString(1);

                    // listeEleves.Add(new Eleve(nom));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listeEleves;
        }*/

        public static List<Promotion> ChargerPromotions()
        {
            List<Promotion> listePromotions = new List<Promotion>();
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = cnx.CreateCommand();

                cmd.CommandText = "SELECT id, nom, dateDebut, dateFin, id_formation FROM dbo.Promotion";

                SqlDataReader lecteur = cmd.ExecuteReader();
                while (lecteur.Read())
                {
                    int id = 0;
                    String nom = null;
                    DateTime dateDebut = DateTime.Now;
                    DateTime dateFin = DateTime.Now;
                    int id_formation = 0;

                    if (!lecteur.IsDBNull(0))
                        id = lecteur.GetInt32(0);
                    if (!lecteur.IsDBNull(1))
                        nom = lecteur.GetString(1);
                    if (!lecteur.IsDBNull(2))
                        dateDebut = lecteur.GetDateTime(2);
                    if (!lecteur.IsDBNull(3))
                        dateFin = lecteur.GetDateTime(3);
                    if (!lecteur.IsDBNull(4))
                        id_formation = lecteur.GetInt32(4);

                    listePromotions.Add(new Promotion(nom, dateDebut, dateFin, id_formation, id));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listePromotions;
        }

        public static List<Formateur> ChargerFormateurs()
        {
            List<Formateur> listeFormateurs = new List<Formateur>();
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = cnx.CreateCommand();

                cmd.CommandText = "SELECT id, nom, prenom, tel, mail FROM dbo.Formateur";

                SqlDataReader lecteur = cmd.ExecuteReader();
                while (lecteur.Read())
                {
                    int id = 0;
                    String nom = null;
                    String prenom = null;
                    String tel = null;
                    String mail = null;

                    if (!lecteur.IsDBNull(0))
                        id = lecteur.GetInt32(0);
                    if (!lecteur.IsDBNull(1))
                        nom = lecteur.GetString(1);
                    if (!lecteur.IsDBNull(2))
                        prenom = lecteur.GetString(2);
                    if (!lecteur.IsDBNull(3))
                        tel = lecteur.GetString(3);
                    if (!lecteur.IsDBNull(4))
                        mail = lecteur.GetString(4);

                    listeFormateurs.Add(new Formateur(nom, prenom, mail, tel, null, id));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listeFormateurs;
        }

        public static List<Salle> ChargerSalle()
        {
            List<Salle> listeSalles = new List<Salle>();
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = cnx.CreateCommand();

                cmd.CommandText = "SELECT id, nom, capacite FROM dbo.Salle";

                SqlDataReader lecteur = cmd.ExecuteReader();
                while (lecteur.Read())
                {
                    int id = 0;
                    String nom = null;
                    int capacite = 0;

                    if (!lecteur.IsDBNull(0))
                        id = lecteur.GetInt32(0);
                    if (!lecteur.IsDBNull(1))
                        nom = lecteur.GetString(1);
                    if (!lecteur.IsDBNull(2))
                        capacite = lecteur.GetInt32(2);

                    listeSalles.Add(new Salle(nom, capacite, id));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listeSalles;
        }

    }
}
