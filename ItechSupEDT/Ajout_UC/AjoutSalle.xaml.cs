using ItechSupEDT.Outils;
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
    /// Logique d'interaction pour AjoutSalle.xaml
    /// </summary>
    public partial class AjoutSalle : UserControl
    {
        public AjoutSalle()
        {
            InitializeComponent();
        }

        private void btn_ajoutSalle_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_nom.Text) &&
               !String.IsNullOrEmpty(tb_capacite.Text))
            {
                int capacite = Int32.Parse(tb_capacite.Text);
                DataInsert.AjouterSalle(tb_nom.Text, capacite);
            }
            else
            {
                tbk_errorMessage.Text= "veuillez renseigner correctement les champs !";
            }
        }
    }
}
