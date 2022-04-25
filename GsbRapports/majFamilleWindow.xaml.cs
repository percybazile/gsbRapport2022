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
using System.Net;
using Newtonsoft.Json;
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
        public majFamilleWindow(Secretaire laSecretaire,WebClient wb,string site)
        {
            
            InitializeComponent();
            this.laSecretaire = laSecretaire;
            this.wb = wb;
            this.site = site;
            string url = this.site + "familles?ticket=" + this.laSecretaire.getHashTicketMdp();
            string reponse = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(reponse);
            string familles = d.familles.ToString(); 
            string ticket = d.ticket; 
            this.laSecretaire.ticket = ticket;
            List<Famille> l = JsonConvert.DeserializeObject<List<Famille>>(familles);
            this.cmbFamille.ItemsSource = l;
            this.cmbFamille.DisplayMemberPath = "libelle";

        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = this.site + "famille";
                NameValueCollection n = new NameValueCollection();
                n.Add("ticket",this.laSecretaire.getHashTicketMdp());
                n.Add("libelle", txtLibFamille.Text);
                string id = ((Famille)this.cmbFamille.SelectedItem).id;
                n.Add("idFamille",txtLibFamille.Tag.ToString());
                byte[] tabByte = wb.UploadValues(url, n);
                string ticket = UnicodeEncoding.UTF8.GetString(tabByte);
                this.laSecretaire.ticket = ticket.Substring(2);
                MessageBox.Show("Vous avez bien modifié la famille");
                this.Close();

            }
            catch (WebException ex)
            {

                if (ex.Response is HttpWebResponse)
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusCode.ToString());
            }
        }
    }
}
