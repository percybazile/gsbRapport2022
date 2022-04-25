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
using System.IO;
using System.Xml.Serialization;
namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour rapportMedecins.xaml
    /// </summary>
    public partial class rapportMedecins : Window
    {
        private Secretaire laSecretaire;
        private WebClient wb;
        private string site;
        public rapportMedecins(Secretaire laSecretaire, WebClient wb, string site)
        {
            InitializeComponent();
            this.laSecretaire = laSecretaire;
            this.wb = wb;
            this.site = site;
            string url = this.site + "medecins?ticket=" + this.laSecretaire.getHashTicketMdp() + "&nom=";
            string reponse = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(reponse);
            string medecins = d.medecins.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket;
            List<Medecin> l = JsonConvert.DeserializeObject<List<Medecin>>(medecins);
            this.dtgmedecins.ItemsSource = l;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string url = this.site + "rapports?ticket=" + this.laSecretaire.getHashTicketMdp() + "&idMedecin=" + txtid.Text;
            string reponse = this.wb.DownloadString(url);
            dynamic d = JsonConvert.DeserializeObject(reponse);
            string rapports = d.rapports.ToString();
            string ticket = d.ticket;
            this.laSecretaire.ticket = ticket;
            List<Rapport> r = JsonConvert.DeserializeObject<List<Rapport>>(rapports);
            this.dtgrapports.ItemsSource = r;
            
            
        }
       
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FileStream f = new FileStream("output" + DateTime.Now.ToString("yyyyMMddTHHmmss") + ".xml", FileMode.Create);
            foreach ( Rapport r in this.dtgrapports.ItemsSource)
            {
            
                XmlSerializer x = new XmlSerializer(r.GetType());
                x.Serialize(f, r);

            }
            MessageBox.Show("Exportation réussi!");
            this.Close();
        }
    }
}
