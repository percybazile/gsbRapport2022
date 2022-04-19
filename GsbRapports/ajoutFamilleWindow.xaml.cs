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
using System.Net;
using dllRapportVisites;
using Newtonsoft.Json;
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
            // paramétrage de base
            try
            {
                InitializeComponent();
                this.laSecretaire = laSecretaire;
                this.wb = wb;
                this.site = site;
            }
            // gestion des erreurs
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnValider_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /* Ici on va travailler sur la méthode POST */
                string url = this.site + "familles";

                NameValueCollection n = new NameValueCollection();
                n.Add("ticket", this.laSecretaire.getHashTicketMdp());
                n.Add("idFamille", txtId.Text.ToString());
                n.Add("libelle", this.txtLibelle.Text.ToString());



                byte[] tabByte = wb.UploadValues(url, n);
                string ticket = UnicodeEncoding.UTF8.GetString(tabByte);
                this.laSecretaire.ticket = ticket.Substring(2);

                MessageBox.Show("Vous avez bien ajouté la famille");

            }
            catch (WebException exc)
            {

                if (exc.Response is HttpWebResponse)
                    MessageBox.Show(((HttpWebResponse)exc.Response).StatusCode.ToString());
            }
        }
    }
}