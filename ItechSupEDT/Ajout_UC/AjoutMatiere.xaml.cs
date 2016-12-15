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

        public AjoutMatiere()
        {
            InitializeComponent();
        
            this.sp_valider.Visibility = Visibility.Collapsed;
        }

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            String nom = tb_nomMatiere.Text;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConnexionBase.GetInstance().Conn;

            if (this.tb_nomMatiere.Text == "")
            {
                this.tbk_error.Text = "Le nom de la matière est vide.";
                this.tbk_error.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                this.tbk_error.Text = "";
                this.tbk_error.Visibility = Visibility.Collapsed;


                string requete = "INSERT INTO Matiere(nom) VALUES('" + nom + "')";
                Console.WriteLine(requete);
                cmd.CommandText = requete;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteReader();
                this.tb_nomMatiere.Text = "";
                this.tbk_retourMessage.Text = "Matière Ajoutée";
                this.sp_Ajout.Visibility = Visibility.Collapsed;
                this.sp_valider.Visibility = Visibility.Visible;
            }



        }
        private void btn_nouveau_Click(object sender, RoutedEventArgs e)
        {
            this.sp_valider.Visibility = Visibility.Collapsed;
            this.sp_Ajout.Visibility = Visibility.Visible;
        }
    }
}
