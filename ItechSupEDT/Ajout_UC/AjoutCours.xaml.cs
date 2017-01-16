using ItechSupEDT.Modele;
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

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Logique d'interaction pour AjoutCours.xaml
    /// </summary>
    public partial class AjoutCours : UserControl
    {
        private List<Formateur> lstFormateurs;
        public List<String, Formateur> LstFormateurs
        {
            get { return this.lstFormateurs; }
            set { this.lstFormateurs = value; }
        }

        private List<String, Promotion> lstPromotions;
        public List<String, Promotion> LstPromotions
        {
            get { return this.lstPromotions; }
            set { this.lstPromotions = value; }
        }

        private List<String, Salle> lstSalles;
        public List<Salle> LstSalles
        {
            get { return this.lstSalles; }
            set { this.lstSalles = value; }
        }

        private List<Salle> lstMatieres;
        public List<Salle> LstMatieres
        {
            get { return this.lstMatieres; }
            set { this.lstMatieres = value; }
        }
        
        public AjoutCours(List<Matiere> lstMatieres, List<Formateur> lstFormateurs, List<Promotion> lstPromotion, List<Salle> lstSalle)
        {
            InitializeComponent();
            this.lstFormateurs = lstFormateurs;
            this.lstPromotions = new Dictionary<string, Promotion>();
            this.lstSalles = new Dictionary<string, Salle>();
            this.l
        }

        private void btn_ajout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RecupInfosListe()
        {

        }
    }
}
