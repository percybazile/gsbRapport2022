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
using System.Windows.Shapes;
using dllRapportVisites;
using Newtonsoft.Json;
using System.Net;
using System.Collections.Specialized;

namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour majFamilleWindow.xaml
    /// </summary>
    public partial class majFamilleWindow : Window
    {
        private Secretaire laSecretaire;
        private WebClient wb;
        private string site;
        public majFamilleWindow(Secretaire s, WebClient w, string site)
        {
            InitializeComponent();
            this.laSecretaire = s;
            this.wb = w;
            this.site = site;

            string url = this.site + "familles?ticket=" + this.laSecretaire.getHashTicketMdp();
            string reponse = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(reponse);

            string familles = d.familles.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket;
            List<Famille> l = JsonConvert.DeserializeObject<List<Famille>>(familles);
            this.cmbFamille.ItemsSource = l;
            this.cmbFamille.DisplayMemberPath = "idlibelle";
        }
        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = this.site + "famille";
                string ticket = this.laSecretaire.getHashTicketMdp();


                NameValueCollection parametres = new NameValueCollection();
                parametres.Add("ticket", ticket);
                parametres.Add("idFamille", ((Famille)this.cmbFamille.SelectedItem).id);
                parametres.Add("libelle", this.txtLibFamille.Text);
                byte[] tabByte = wb.UploadValues(url, parametres);
                string ticketS = UnicodeEncoding.UTF8.GetString(tabByte);
                MessageBox.Show("Modification apportée");
                this.Close();
                this.laSecretaire.ticket = ticketS;
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusCode.ToString());

            }
        }
    }


}
