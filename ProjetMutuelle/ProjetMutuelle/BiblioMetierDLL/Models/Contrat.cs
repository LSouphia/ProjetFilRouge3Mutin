using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetMutuelle.Models
{
    public class Contrat : Object
    {
        [Display(Name = "Contrat")]
        public string IDContrat { get; set; }
        [Display(Name = "Organisme")]
        public string IDOrganisme { get; set; }
        [Display(Name = "Utilisateur")]
        public string IDUtilisateur { get; set; }
        [Display(Name = "Entreprise")]
        public string IDEntreprise { get; set; }
        [Display(Name = "catégories")]
        public string IDCatSocioPro { get; set; }
        [Display(Name = "Statut")]
        public string IDStatut { get; set; }
        [Display(Name = "Type")]
        public string TypeContrat { get; set; }
        [Display(Name = "Effictif")]
        public int EffectifCatSocio { get; set; }
        [Display(Name = "Age")]
        public int AgeMoyenCatSocio { get; set; }
        [Display(Name = "Date signature Contrat")]
        public DateTime DateSignContrat { get; set; }
        [Display(Name = "Date Effet Contrat")]
        public DateTime DateEffetContrat { get; set; }
        [Display(Name = "Date Fin Contrat")]
        public DateTime DateFinContrat { get; set; }
        [Display(Name = "Filiale")]
        public string IDFiliale { get; set; }
    }
}