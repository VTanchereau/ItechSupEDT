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
        public AjoutPromotion(List<Formation> _lstFormations)
        {
            InitializeComponent();
            this.LstFormations = new Dictionary<string, Formation>();
            if (_lstFormations.Count > 0)
            {
                foreach (Formation formation in _lstFormations)
                {
                    this.LstFormations.Add(formation.Nom, formation);
                }
                this.cb_lstFormations.ItemsSource = this.LstFormations.Keys;
                this.cb_lstFormations.SelectedIndex = 0;
            }
        }

        private void btn_ajout_Click(object sender, RoutedEventArgs e)
        {
            Formation formation = lstFormations[cb_lstFormations.SelectedItem.ToString()];
            DataInsert.AjouterPromotion(tb_nom.Text, dp_dateDebut.SelectedDate.Value, dp_dateFin.SelectedDate.Value, formation.Id);
        }

      
        /* private void GestionErreurs()
         {
             if ( String.IsNullOrEmpty(tb_nom.Text) ||
                  String.IsNullOrEmpty(dp_dateDebut.Text) ||
                  String.IsNullOrEmpty(dp_dateFin.Text) ||
                  String.IsNullOrEmpty(cb_lstFormations.Text))
             {
                 tbk_errorMessage.Text = " veuillez renseigner correctement les champs !";
                 tbk_errorMessage.Visibility = Visibility.Visible;
                 return;
             }
             if (tbk_errorMessage.Text != "")
             {
                 tbk_errorMessage.Text = "";
                 tbk_errorMessage.Visibility = Visibility.Collapsed;
             }
         }*/


    }
}
