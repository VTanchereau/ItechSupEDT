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
    /// Interaction logic for AjoutFormateur.xaml
    /// </summary>
    public partial class AjoutFormateur : UserControl
    {

        public AjoutFormateur(List<Nameable> _lstMatiere)
        {
            InitializeComponent();
          
            foreach (Matiere mat in ChargerMatieres())
            {
                _lstMatiere.Add((Nameable)mat);
            }
                
            MutliSelectPickList multiSelect = new MutliSelectPickList(_lstMatiere);
            this.MultiSelect.Content = multiSelect;
        }

        private void btn_ajoutFormation_Click(object sender, RoutedEventArgs e)
        {
            GestionErreurs();
            Formateur formateur = new Formateur(tb_nom.Text, tb_prenom.Text, tb_mail.Text, tb_telephone.Text, null );
            AjouterFormateur(formateur);
        }

        public void AjouterFormateur(Formateur formateur)
        {
            SqlConnection cnx = null;

            try
            {
                cnx = Connexion.getInstance().SQL_CNX;
                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = " INSERT INTO dbo.Formateur(nom,prenom,tel,mail) VALUES ('" + formateur.Nom + "','"
                                                                                              + formateur.Prenom+"','"
                                                                                              + formateur.Telephone+"','"
                                                                                              + formateur.Mail+"'); ";
                cnx.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                tbk_errorMessage.Text = error.Message;
            }
            finally
            {
                if (cnx != null && cnx.State != ConnectionState.Closed && cnx.State != ConnectionState.Broken)
                    cnx.Close();
            }
        }

        private void GestionErreurs()
        {
            if ( String.IsNullOrEmpty(tb_nom.Text)||
                 String.IsNullOrEmpty(tb_prenom.Text) || 
                 String.IsNullOrEmpty(tb_mail.Text) ||
                 String.IsNullOrEmpty(tb_telephone.Text))
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
        }

        private List<Matiere> ChargerMatieres()
        {
            List<Matiere> listeMatieres = new List<Matiere>();
            SqlConnection cnx = null;
            try
            {
                cnx = Connexion.getInstance().SQL_CNX;

                SqlCommand cmd = cnx.CreateCommand();
                cmd.CommandText = "SELECT id, nom FROM dbo.Matiere";
                IDataReader lecteur = cmd.ExecuteReader();
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
            }catch(Exception e)
            {
                throw new Exception(e.Message);
            }
           
            return listeMatieres;
        }



    }
}
