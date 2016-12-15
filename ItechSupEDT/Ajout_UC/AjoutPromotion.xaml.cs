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
        public AjoutPromotion(List<Formation> _lstFormations, List<Nameable> _lstEleve)
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
            MutliSelectPickList multiSelect = new MutliSelectPickList(_lstEleve);
            this.MultiSelect.Content = multiSelect;
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

        private List<Eleve> ChargerEleves()
        {
            List<Eleve> listeMatieres = new List<Eleve>();
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

                   // listeMatieres.Add(new (nom));
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return listeMatieres;
        }
    }
}
