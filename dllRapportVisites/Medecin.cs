using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dllRapportVisites
{
    public class Medecin
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string adresse { get; set; }
        public string tel { get; set; }
        public string specialiteComplementaire { get; set; }
        
        public string departement { get; set; }
        public Medecin(int id, string nom, string prenom, string adresse, string telephone, string specialite,string departement)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.adresse = adresse;
            this.tel = telephone;
            this.specialiteComplementaire = specialite;
            this.departement = departement;

        }
    }
}
