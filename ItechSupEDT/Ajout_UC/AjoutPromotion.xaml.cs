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
using ItechSupEDT.Ajout_UC;
using System.Data.SqlClient;
using ItechSupEDT.Outils;
using System.Data;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutPromotion.xaml
    /// </summary>
    public partial class AjoutPromotion : UserControl
    {
        private Dictionary<String, Formation> lstFormations;
        public Dictionary<String, Formation> LstFormations
        {
            get { return this.lstFormations; }
            set { this.lstFormations = value; }
        }
        public AjoutPromotion()
        {
            InitializeComponent();

            this.cb_lstFormations.ItemsSource = FormationDAO.ListerFormation();
            
       
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            /* tb_nom
             dp_dateDebut
             dp_dateFin
             cb_lstFormations*/
         

            if (!(tb_nom.Text == "" || dp_dateDebut.Text =="" ||dp_dateFin.Text =="" || cb_lstFormations.Text ==""))
            {
                string nom = tb_nom.Text;
                DateTime dateDebut = (DateTime) dp_dateDebut.SelectedDate;
                DateTime dateFin = (DateTime)dp_dateFin.SelectedDate;
                Formation formation = (Formation)cb_lstFormations.SelectedItem;



                try
                {
                    PromotionDAO.creerPromotion(nom,dateDebut,dateFin,formation);
                }
                catch (Exception ex)
                {
                    tbk_errorMessage.Text = "Désolé, une erreur est survenue lors de l'ajout de la promotion, veuillez vérifier les informations renseignées et recommencer.";
                }
            }
            else
            {
                tbk_errorMessage.Text = "Veuillez remplir le ou les champs manquant(s) ";
            }
           

        }
    }
}
