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
using System.Data.SqlClient;
using ItechSupEDT.Outils;
using System.Data;

namespace ItechSupEDT.Ajout_UC
{
    /// <summary>
    /// Interaction logic for AjoutMatiere.xaml
    /// </summary>
    public partial class AjoutMatiere : UserControl
    {

        private List<Matiere> lstMatiere;
        public List<Matiere> LstMatiere
        {
            get { return this.lstMatiere; }
            set { this.lstMatiere = value; }
        }

        public AjoutMatiere()
        {
            InitializeComponent();
            this.LstMatiere = new List<Matiere>();
            this.sp_valider.Visibility = Visibility.Collapsed;
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            GestionErreurs();
            this.LstMatiere.Add(new Matiere(this.tb_nomMatiere.Text));
            Matiere matiere = new Matiere(tb_nomMatiere.Text);

            try
            {
                AjouterMatiere(matiere);
            }
            catch (Formation.FormationException error)
            {
                tbk_error.Text = error.Message;
            }

            this.tb_nomMatiere.Text = "";
            this.tbk_retourMessage.Text = "Matière Ajoutée";
            this.sp_Ajout.Visibility = Visibility.Collapsed;
            this.sp_valider.Visibility = Visibility.Visible;

        }
        private void btn_nouveau_Click(object sender, RoutedEventArgs e)
        {
            this.sp_valider.Visibility = Visibility.Collapsed;
            this.sp_Ajout.Visibility = Visibility.Visible;
        }

        public void AjouterMatiere(Matiere matiere)
        {

            SqlConnection cnx = null;

            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                //IDbCommand cmd = cnx.SQL_CNX.CreateCommand();
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = " INSERT INTO dbo.Matiere(nom) VALUES ('" + matiere.Nom + "');";
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                tbk_error.Text = error.Message;
            }
            finally
            {
                if (cnx != null && cnx.State != ConnectionState.Closed && cnx.State != ConnectionState.Broken)
                    cnx.Close();
            }
        }

        private void GestionErreurs()
        {
            if (this.tb_nomMatiere.Text == "")
            {
                this.tbk_error.Text = "Le nom de la matière est vide.";
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }
            if (tbk_error.Text != "")
            {
                this.tbk_error.Text = "";
                this.tbk_error.Visibility = Visibility.Collapsed;
            }
        }
    }
}
