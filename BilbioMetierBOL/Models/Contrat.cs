namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contrat")]
    public partial class Contrat
    {
        [Key]
        [StringLength(254)]
        public string IDContrat { get; set; }

        [StringLength(254)]
        public string IDOrganisme { get; set; }

        [StringLength(254)]
        public string IDUtilisateur { get; set; }

        [StringLength(254)]
        public string IDFiliale { get; set; }

        [Required]
        [StringLength(254)]
        public string IDEntreprise { get; set; }

        [Required]
        [StringLength(254)]
        public string IDCatSocioPro { get; set; }

        [Required]
        [StringLength(254)]
        public string IDStatut { get; set; }

        [StringLength(254)]
        public string TypeContrat { get; set; }

        public int? EffectifCatSocio { get; set; }

        public int? AgeMoyenCatSocio { get; set; }

        public DateTime? DateSignContrat { get; set; }

        public DateTime? DateEffetContrat { get; set; }

        public DateTime? DateFinContrat { get; set; }

        public CategorieSocioPro CategorieSocioPro { get; set; }

        public EntrepriseMere EntrepriseMere { get; set; }

        public Filiale Filiale { get; set; }

        public Organisme Organisme { get; set; }

        public Statut Statut { get; set; }

        public Utilisateur Utilisateur { get; set; }
    }
}
