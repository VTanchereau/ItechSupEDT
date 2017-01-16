using ItechSupEDT.Modele;
using ItechSupEDT.Outils;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Logique d'interaction pour AjoutCours.xaml
    /// </summary>
    public partial class AjoutCours : UserControl
    {
        private Dictionary<String, Formateur> _listeNomFormateurs;
        public Dictionary<String, Formateur> ListeNomFormateurs
        {
            get { return _listeNomFormateurs; }
            set { _listeNomFormateurs = value; }
        }

        private Dictionary<String, Promotion> _listeNomPromotions;
        public Dictionary<String, Promotion> ListeNomPromotions
        {
            get { return _listeNomPromotions; }
            set { _listeNomPromotions = value; }
        }

        private Dictionary<String, Salle> _listeNomSalles;
        public Dictionary<String, Salle> ListeNomSalles
        {
            get { return _listeNomSalles; }
            set { _listeNomSalles = value; }
        }

        private Dictionary<String, Matiere> _listeNomMatieres;
        public Dictionary<String, Matiere> ListeNomMatieres
        {
            get { return _listeNomMatieres; }
            set { _listeNomMatieres = value; }
        }

        // constructeur, initialisation et valorisation des listes 
        public AjoutCours(List<Matiere> lstMatieres, List<Formateur> lstFormateurs, List<Promotion> lstPromotions, List<Salle> lstSalles)
        {
            InitializeComponent();

            _listeNomPromotions = new Dictionary<String, Promotion>();
            _listeNomSalles = new Dictionary<String, Salle>();
            _listeNomMatieres = new Dictionary<String, Matiere>();
            _listeNomFormateurs = new Dictionary<String, Formateur>();

            Recuperer_InfosListes(lstMatieres, lstFormateurs, lstPromotions, lstSalles);
        }

        //Evenement qui recupere les informations saisies par l'utilisateur et qui les transmet à la Classe chargée d'inserer les données dans la base
        private void btn_ajout_Click(object sender, RoutedEventArgs e)
        {
            //creation des objets 
            Promotion promotion = _listeNomPromotions[cb_listePromotions.SelectedItem.ToString()];
            Matiere matiere = _listeNomMatieres[cb_listeMatieres.SelectedItem.ToString()];
            Formateur formateur = _listeNomFormateurs[cb_listeFormateurs.SelectedItem.ToString()];
            Salle salle = _listeNomSalles[cb_listeSalles.SelectedItem.ToString()];

            //verification dans informations puis Insertion dans la base
            if (!String.IsNullOrEmpty(dp_dateDebut.Text) &&
               !String.IsNullOrEmpty(dp_dateFin.Text) &&
               promotion != null && matiere != null && salle != null)
            {
                DataInsert.AjouterCours(dp_dateDebut.SelectedDate.Value, dp_dateFin.SelectedDate.Value, promotion, matiere, salle, formateur);
            }
            else
            {
                tbk_errorMessage.Text ="veuillez renseigner les champs correctement ! ";
            }
        }

        //Recupere les valeurs des listes obtenues à partir de la base de dponnées (dataLoader)
        private void Recuperer_InfosListes(List<Matiere> listeMatieres, List<Formateur> listeFormateurs, List<Promotion> listePromotions, List<Salle> listeSalles)
        {
            if (listePromotions.Count > 0 && listeMatieres.Count > 0 && listeSalles.Count > 0 && listeFormateurs.Count > 0)
            {
                //valorise la comboBox des promotions
                foreach (Promotion promotion in listePromotions)
                {
                    _listeNomPromotions.Add(promotion.Nom, promotion);
                }
                cb_listePromotions.ItemsSource = _listeNomPromotions.Keys;
                cb_listePromotions.SelectedIndex = 0;

                //valorise la comboBox des Matieres
                foreach (Matiere matiere in listeMatieres)
                {
                    _listeNomMatieres.Add(matiere.Nom, matiere);
                }
                cb_listeMatieres.ItemsSource = _listeNomMatieres.Keys;
                cb_listeMatieres.SelectedIndex = 0; 

                //valorise la comboBox des Salles
                foreach (Salle salle in listeSalles)
                {
                    _listeNomSalles.Add(salle.Nom, salle);
                }
                cb_listeSalles.ItemsSource = _listeNomSalles.Keys;
                cb_listeSalles.SelectedIndex = 0;

                //valorise la comboBox des Formateurs
                foreach (Formateur formateur in listeFormateurs)
                {
                    _listeNomFormateurs.Add(formateur.Nom, formateur);
                }
                cb_listeFormateurs.ItemsSource = _listeNomFormateurs.Keys;
                cb_listeFormateurs.SelectedIndex = 0;
            }
        }
    }
}
