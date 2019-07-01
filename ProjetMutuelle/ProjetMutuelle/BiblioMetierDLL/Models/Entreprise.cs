using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetMutuelle.Models
{
    public class Entreprise
    {

        [Required]
        [StringLength(8, ErrorMessage = "Code entreprise invalide", MinimumLength = 1)]
        [Display(Name = "Code entreprise:")]
        public string IDEntreprise { get; set; }
        [Display(Name = "Code Ape")]
        public string IDApe { get; set; }
        [Display(Name = "Nom de l'entreprise:")]
        public string DesignationEntreprise { get; set; }
        [Display(Name = "Adresse de l'entreprise:")]
        public string AdresseEntreprise { get; set; }
        [StringLength(5, ErrorMessage = "Code postal invalide", MinimumLength = 5)]
        [Display(Name = "Code postal:")]
        public string CodePostalEntreprise { get; set; }
        [Display(Name = "Ville de l'entreprise:")]
        public string VilleEntreprise { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numéro de téléphone:")]
        public String TelEntreprise { get; set; }
        [Display(Name = "Effectif total:")]
        public int EffectifTotal { get; set; }
        [Display(Name = "ID Contact:")]
        public string IDContact { get; set; }
        [Display(Name = "Nom du contact:")]
        public string NomContact { get; set; }
        [Display(Name = "Prénom du contact:")]
        public string PrenomContact { get; set; }
        [Display(Name = "Fonction du contact:")]
        public string FonctionContact { get; set; }
        [Display(Name = "Tel du contact:")]
        public string TelContact { get; set; }
    }
}
