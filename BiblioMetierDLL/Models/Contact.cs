using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetMutuelle.Models
{
    public class Contact
    {
        [Required]
        [StringLength(8, ErrorMessage = "Code contact invalide", MinimumLength = 1)]
        [Display(Name = "Code contact:")]
        public string IDContact { get; set; }
        [Display(Name = "ID entreprise")]
        public string IDEntreprise { get; set; }
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

