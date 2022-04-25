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
    /// Logique d'interaction pour ajoutFamilleWindow.xaml
    /// </summary>
    public partial class ajoutFamilleWindow : Window
    {
        private Secretaire laSecretaire;
        private WebClient wb;
        private string site;
        public ajoutFamilleWindow(Secretaire laSecretaire, WebClient wb, string site)
        {
            InitializeComponent();
            this.laSecretaire = laSecretaire;
            this.wb = wb;
            this.site = site;
        }

        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string url = this.site + "familles";
                NameValueCollection n = new NameValueCollection();
                n.Add("ticket", this.laSecretaire.getHashTicketMdp());
                n.Add("idFamille", txtId.Text);
                n.Add("libelle", txtLibelle.Text.ToString());
                byte[] tabByte = wb.UploadValues(url, n);
                string ticket = UnicodeEncoding.UTF8.GetString(tabByte);
                this.laSecretaire.ticket = ticket.Substring(2);
                MessageBox.Show("Vous avez bien ajouté une famille");
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
