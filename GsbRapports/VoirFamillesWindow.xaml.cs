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
using Newtonsoft.Json;
using dllRapportVisites;
using System.Net;

namespace GsbRapports
{
    /// <summary>
    /// Logique d'interaction pour VoirFamillesWindow.xaml
    /// </summary>
    public partial class VoirFamillesWindow : Window
    {
        private Secretaire laSecretaire;
        private WebClient wb;
        private string site;
        public VoirFamillesWindow(Secretaire laSecretaire, WebClient wb, string site)
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
            this.dtgfamilles.ItemsSource = l;

        }



    }
}
