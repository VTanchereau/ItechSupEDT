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
using System.Data.SqlClient;
using System.Data;

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
            try
            {
                float duree = Single.Parse(nbHeures);
                try
                {
                    //Formation formation = new Formation(nom, duree, lstMatiere);
                }
                catch (Formation.FormationException error)
                {
                    tbk_errorMessage.Text = error.Message;
                }
            }
            catch (Exception)
            {
                tbk_errorMessage.Text = "Désolé, une erreur est survenu lors de l'ajout de la formation, veuillez vérifier les informations renseignées et recommencer.";
            }


            SqlCommand cmd = new SqlCommand();
            /*SqlConnection conn = ConnexionBase.GetInstance().Conn;
              cmd.Connection = conn;*/
            cmd.Connection = ConnexionBase.GetInstance().Conn;
            string requete = "INSERT INTO Formation(nom,nbHeureTotale) VALUES('"+ nom+"'," + nbHeures + ")";
            Console.WriteLine(requete);
            cmd.CommandText = requete;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteReader();
        }
    }
}
