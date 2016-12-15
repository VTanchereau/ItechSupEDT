using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ItechSupEDT.Modele;
using ItechSupEDT.Outils;
using System.Data;
using System.Data.SqlClient;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutFormation.xaml
    /// </summary>
    public partial class AjoutFormation : UserControl
    {
        public AjoutFormation()
        {
            InitializeComponent();
        }

        public AjoutFormation(Formation _formation)
        {
            InitializeComponent();
            tb_nomFormation.Text = _formation.Nom;
            tb_dureeFormation.Text = _formation.NbHeuresTotal.ToString();
        }

        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {

            String nom = tb_nomFormation.Text;
            String nbHeures = tb_dureeFormation.Text;
                float duree = float.Parse(nbHeures);
                Formation formation = new Formation(nom, duree);
                try
                {
                    AjouterFormation(formation);
                }
                catch(Formation.FormationException error)
                {
                    tbk_errorMessage.Text = error.Message;
                }       
        }

        public void AjouterFormation( Formation formation)
        {
            //Guid code, string nom, char sexe, string couleur, string race, string espece, Guid codeCli,
            //           string tatoo, string texte, byte arch

            SqlConnection cnx = null;

            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                //IDbCommand cmd = cnx.SQL_CNX.CreateCommand();
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = " INSERT INTO dbo.Formation(nom, nbHeures) VALUES ('"+formation.Nom+"','"+formation.NbHeuresTotal+"');";
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch(Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
            finally
            {
                if (cnx != null && cnx.State != ConnectionState.Closed && cnx.State != ConnectionState.Broken)
                    cnx.Close();
            }
        }
        


       

    }
}
