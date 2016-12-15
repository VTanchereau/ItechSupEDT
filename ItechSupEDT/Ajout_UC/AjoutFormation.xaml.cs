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
using System.Text.RegularExpressions;

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
            this.sp_valider.Visibility = Visibility.Collapsed;
        }

        public AjoutFormation(Formation _formation)
        {
            InitializeComponent();
            tb_nomFormation.Text = _formation.Nom;
            tb_dureeFormation.Text = _formation.NbHeuresTotal.ToString();
        }

        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {
           string nom = tb_nomFormation.Text;
           string nbHeuresStr = tb_dureeFormation.Text;
           float nbHeures;
           string message_informations = "";
           bool erreurSaisie = false;
           


            if (nom == "")
            {
                message_informations += "Veuillez renseigner le nom de la formation\n";
                erreurSaisie = true;

            }
       
            if (nbHeuresStr == "")
            {
                
                message_informations += "Veuillez renseigner le nombre d'heures\n";
                erreurSaisie = true;

            }
            else if(!float.TryParse(nbHeuresStr,out nbHeures))
            {
                message_informations += "Format heure incorrect, veuillez-saisir un nombre";
                erreurSaisie = true;
            }
     

            if (erreurSaisie)
            {
                tbk_errorMessage.Text = message_informations;
            }
            else
            {
                try
                {
                    FormationDAO.creerFormation(nom, float.Parse(nbHeuresStr));
                    this.tbk_retourMessage.Text = "Formation Ajoutée";
                    this.sp_Ajout.Visibility = Visibility.Collapsed;
                    this.sp_valider.Visibility = Visibility.Visible;
                }
                catch (Exception)
                {
                    tbk_errorMessage.Text = "Désolé, une erreur est survenue lors de l'ajout de la formation, veuillez vérifier les informations renseignées et recommencer.";
                }
            } 



        }
        private void btn_nouveau_Click(object sender, RoutedEventArgs e)
        {
            this.sp_valider.Visibility = Visibility.Collapsed;
            this.sp_Ajout.Visibility = Visibility.Visible;
        }
    }
}

