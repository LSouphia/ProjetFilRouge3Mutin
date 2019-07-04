namespace BiblioMetierBOL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Table("Contrat")]
    public partial class Contrat
    {
        [Key]
        [StringLength(254)]
        [Display(Name = "Contrat")]
        public string IDContrat { get; set; }

        [StringLength(254)]
        [Display(Name = "Organisme")]
        public string IDOrganisme { get; set; }

        [StringLength(254)]
        [Display(Name = "Utilisateur")]
        public string IDUtilisateur { get; set; }

        [StringLength(254)]
        public string IDFiliale { get; set; }

        [Required]
        [StringLength(254)]
        [Display(Name = "Entreprise")]
        public string IDEntreprise { get; set; }

        [Required]
        [StringLength(254)]
        [Display(Name = "catégories")]
        public string IDCatSocioPro { get; set; }

        [Required]
        [StringLength(254)]
        [Display(Name = "Statut")]
        public string IDStatut { get; set; }

        [StringLength(254)]
        [Display(Name = "Type")]
        public string TypeContrat { get; set; }
        [Display(Name = "Effictif")]
        public int? EffectifCatSocio { get; set; }
        [Display(Name = "Age")]

        public int? AgeMoyenCatSocio { get; set; }
        [Display(Name = "Date signature Contrat")]

        public DateTime? DateSignContrat { get; set; }
        [Display(Name = "Date Effet Contrat")]

        public DateTime? DateEffetContrat { get; set; }
        [Display(Name = "Date Fin Contrat")]
        public DateTime? DateFinContrat { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public  EntrepriseMere EntrepriseMere { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public  Statut Statut { get; set; }
        //public string LibelleStatut { get; set; }
    }
}
