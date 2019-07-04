namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personne")]
    public partial class Personne
    {
        [Key]
        [StringLength(254)]
        public string iDPerso { get; set; }

        [StringLength(254)]
        public string iDCatSocioPro { get; set; }

        [Required]
        [StringLength(254)]
        public string iDEntreprise { get; set; }

        [StringLength(254)]
        public string nomPers { get; set; }

        [StringLength(254)]
        public string prenomPers { get; set; }

        [StringLength(254)]
        public string situationFamPers { get; set; }

        public DateTime? dateNaissPers { get; set; }

        public CategorieSocioPro CategorieSocioPro { get; set; }

        public EntrepriseMere EntrepriseMere { get; set; }
    }
}
