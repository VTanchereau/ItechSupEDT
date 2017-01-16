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
using ItechSupEDT.Ajout_UC;
using ItechSupEDT.Modele;
using ItechSupEDT.Outils;

namespace ItechSupEDT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.WindowState = WindowState.Maximized;
            InitializeComponent();
        }
		
        private void mi_ajout_formation_Click(object sender, RoutedEventArgs e)
        {
            Ajout_UC.AjoutFormation ajoutFormation = new Ajout_UC.AjoutFormation();
            this.Ajout.Content = ajoutFormation;
		}
		
        private void mi_ajout_matiere_Click(object sender, RoutedEventArgs e)
        {
            AjoutMatiere ajoutMatiere = new AjoutMatiere();
            this.Ajout.Content = ajoutMatiere;
        }

        private void mi_ajout_promotion_Click(object sender, RoutedEventArgs e)
        {
            //List<Nameable> lstEleves = new List<Nameable>();
            List<Formation> lstFormations = DataLoader.ChargerFormations();
            AjoutPromotion ajoutPromotion = new AjoutPromotion(lstFormations);
            this.Ajout.Content = ajoutPromotion;
        }

        private void mi_ajout_formateur_Click(object sender, RoutedEventArgs e)
        {
           // List<Matiere> lstMatieres = ;
            List<Nameable> Nameable_lstMatiere = new List<Nameable>();
            foreach (Matiere mat in DataLoader.ChargerMatieres())
            {
                Nameable_lstMatiere.Add((Nameable)mat);
            }
            
            AjoutFormateur ajoutFormateur = new AjoutFormateur(Nameable_lstMatiere);
            this.Ajout.Content = ajoutFormateur;
        }

        private void mi_afficher_formation_Click(object sender, RoutedEventArgs e)
        {
            // Récuperer la formation depuis la base de donnée (id = 1 par exemple)
            Formation formation = new Modele.Formation("NomFormation", 150);
            Ajout_UC.AjoutFormation ajoutFormation = new Ajout_UC.AjoutFormation(formation);
            this.Ajout.Content = ajoutFormation;
        }

        private void mi_afficher_matiere_Click(object sender, RoutedEventArgs e)
        {
            // Récuperer la matière depuis la base de donnée (id = 1 par exemple)
            Matiere matiere = new Modele.Matiere("NomMatiere");
            Ajout_UC.AjoutMatiere ajoutMatiere = new Ajout_UC.AjoutMatiere(matiere);
            this.Ajout.Content = ajoutMatiere;
        }

        private void mi_ajout_eleve_Click(object sender, RoutedEventArgs e)
        {
            List<Promotion> lstPromotions = DataLoader.ChargerPromotions();
            AjoutEleve ajoutPromotion = new AjoutEleve(lstPromotions);
            this.Ajout.Content = ajoutPromotion;
        }

        private void mi_ajout_salle_Click(object sender, RoutedEventArgs e)
        {
            AjoutSalle ajoutFormation = new AjoutSalle();
            this.Ajout.Content = ajoutFormation;
        }

        private void mi_ajout_cours_Click(object sender, RoutedEventArgs e)
        {
            /* List<Nameable> Nameable_lstMatiere = new List<Nameable>();
             foreach (Matiere mat in DataLoader.ChargerMatieres())
             {
                 Nameable_lstMatiere.Add((Nameable)mat);
             }*/


            List<Matiere> listeMatieres = DataLoader.ChargerMatieres();
            List<Promotion> listePromotions = DataLoader.ChargerPromotions();
            List<Formateur> listeFormateurs = DataLoader.ChargerFormateurs();
            List<Salle> listeSalles = DataLoader.ChargerSalle();

            AjoutCours ajoutCours = new AjoutCours(listeMatieres, listeFormateurs, listePromotions, listeSalles);
            this.Ajout.Content = ajoutCours;

            
            
        }
    }
}
