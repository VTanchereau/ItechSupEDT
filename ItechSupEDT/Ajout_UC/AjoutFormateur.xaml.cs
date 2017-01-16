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
       private List<Matiere> _lstMatieres;
        public List<Matiere> ListMatieres
        {
            get { return _lstMatieres; }
            set { _lstMatieres = value; }
        }


        public AjoutFormateur(List<Nameable> lstMatieres)
        {
            InitializeComponent();

          //  this._lstMatieres = lstMatieres;
            MutliSelectPickList multiSelect = new MutliSelectPickList(lstMatieres);
            this.MultiSelect.Content = multiSelect;
        }

        private void btn_ajoutFormateur_Click(object sender, RoutedEventArgs e)
        {
            GestionErreurs();
            List<Nameable> listMatieres = new List<Nameable>(((MutliSelectPickList)MultiSelect.Content).GetSelectedObjects());
            foreach(Nameable name in listMatieres)
            {
                _lstMatieres.Add((Matiere)name);
            }

            if(!String.IsNullOrEmpty(tb_nom.Text)&&
               !String.IsNullOrEmpty(tb_prenom.Text)&&
               !String.IsNullOrEmpty(tb_telephone.Text)&&
               !String.IsNullOrEmpty(tb_mail.Text))
            {
                DataInsert.AjouterFormateur(tb_nom.Text, tb_prenom.Text, tb_telephone.Text, tb_mail.Text, _lstMatieres);
                
            }else
            {
                throw new Exception("veuillez renseigner correctement les champs !");
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

       



    }
}
