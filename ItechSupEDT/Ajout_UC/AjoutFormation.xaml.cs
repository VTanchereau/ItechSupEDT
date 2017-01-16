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
using System.Data;
using System.Data.SqlClient;

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
            if(!String.IsNullOrEmpty(tb_nomFormation.Text)&&
               !String.IsNullOrEmpty(tb_dureeFormation.Text))
            {
                float duree = float.Parse(tb_dureeFormation.Text);
                DataInsert.AjouterFormation(tb_nomFormation.Text, duree);
            }else
            {
                throw new Exception("veuillez renseigner correctement les champs !");
            }
           

        }







    }
}
