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
using System.Collections.Specialized;
using Newtonsoft.Json;

namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour ajoutMedecin.xaml
    /// </summary>
    public partial class ajoutMedecin : Window
    {
        private Secretaire laSecretaire;
        private WebClient wb;
        private string site;
        public ajoutMedecin(Secretaire laSecretaire, WebClient wb, string site)
        {
            InitializeComponent();
            this.laSecretaire = laSecretaire;
            this.wb = wb;
            this.site = site;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string prenom = txtprenom.Text;
                string nom = txtnom.Text;
                string adresse = txtadr.Text;
                string departement = txtdep.Text;
                string tel = txttel.Text;
                string specialite = txtspc.Text;
                bool ok = true;
                if(prenom == "")
                {
                    MessageBox.Show("Ce champ ne doit pas être vide !");
                    ok = false;
                }
                if (nom == "")
                {
                    MessageBox.Show("Ce champ ne doit pas être vide !");
                    ok = false;
                }
                if (adresse == "")
                {
                    MessageBox.Show("Ce champ ne doit pas être vide !");
                    ok = false;
                }
                if(departement != "" && departement.All(char.IsDigit))
                {
                }
                else
                {
                    txtdep.Background = Brushes.Red;
                    erreurDep.Text ="Ce champ n'est pas valide !";
                    ok = false;
                }
                if (tel.Length == 10 && tel !="")
                {
                    int n;
                    if (Int32.TryParse(tel,out n))
                    {
                        
                    }
                    else
                    {
                        MessageBox.Show("Le numéro de téléphone n'est pas valide !");
                        ok = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ce champ n'est pas valide !");
                    ok =false;

                }
                if (specialite == "")
                {
                    MessageBox.Show("Ce champ ne doit pas être vide !");
                    ok = false;
                }
                if (ok)
                {
                    string url = this.site + "medecins";
                    NameValueCollection n = new NameValueCollection();
                    n.Add("ticket", this.laSecretaire.getHashTicketMdp());
                    n.Add("nom", txtnom.Text.ToString());
                    n.Add("prenom", txtprenom.Text.ToString());
                    n.Add("adresse", txtadr.Text.ToString());
                    n.Add("departement", txtdep.Text.ToString());
                    n.Add("tel", txttel.Text.ToString());
                    n.Add("specialite", txtspc.Text.ToString());
                    byte[] tabByte = wb.UploadValues(url, n);
                    string ticket = UnicodeEncoding.UTF8.GetString(tabByte);
                    this.laSecretaire.ticket = ticket.Substring(2);
                    MessageBox.Show("Vous avez bien ajouté un médecin");
                    this.Close();
                }
                
            }
            catch (WebException ex)
            {
                if (ex.Response is HttpWebResponse)
                    MessageBox.Show(((HttpWebResponse)ex.Response).StatusCode.ToString());
            }
        }
    }
}
