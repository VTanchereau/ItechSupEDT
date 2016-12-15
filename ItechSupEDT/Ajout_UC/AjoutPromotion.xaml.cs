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
        public AjoutPromotion(List<Formation> _lstFormations, List<MultiSelectedObject> _lstEleve)
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

        private void btn_valider_Click(object sender, RoutedEventArgs e)
        {
            /* tb_nom
             dp_dateDebut
             dp_dateFin
             cb_lstFormations*/

            if (!(tb_nom.Text == "" || dp_dateDebut.Text =="" ||dp_dateFin.Text =="" || cb_lstFormations.Text ==""))
            {
                try
                {
                    SqlCommand insertPromotion = new SqlCommand();
                    insertPromotion.CommandText = "INSERT INTO Promotion (nom,dateDebut,dateFin,formation_id) VALUES (@nom,@dateDebut, @dateFin,@formationId)";
                    insertPromotion.CommandType = CommandType.Text;
                    insertPromotion.Connection = ConnexionBase.GetInstance().Conn;

                    SqlParameter nomParam = new SqlParameter("nom", SqlDbType.VarChar);
                    nomParam.Value = tb_nom;

                    SqlParameter dateDebutParam = new SqlParameter("dateDebut", SqlDbType.DateTime);
                    dateDebutParam.Value = dp_dateDebut;

                    SqlParameter dateFinParam = new SqlParameter("dateFin", SqlDbType.DateTime);
                    dateFinParam.Value = dp_dateFin;

                    SqlParameter formationIdParam = new SqlParameter("formation ID", SqlDbType.Int);
                    formationIdParam.Value = cb_lstFormations;


                    insertPromotion.Parameters.Add(nomParam);
                    insertPromotion.Parameters.Add(dateDebutParam);
                    insertPromotion.Parameters.Add(dateFinParam);
                    insertPromotion.Parameters.Add(formationIdParam);

                    insertPromotion.ExecuteReader();
                }
                catch (Exception)
                {
                    tbk_errorMessage.Text = "Désolé, une erreur est survenue lors de l'ajout de la promotion, veuillez vérifier les informations renseignées et recommencer.";
                }
            }
            else
            {
                tbk_errorMessage.Text = "Veuillez remplir le ou les champs manquant(s) ";
            }
           

        }
    }
}
