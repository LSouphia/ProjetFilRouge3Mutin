namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactEntreprise")]
    public partial class ContactEntreprise
    {
        [Key]
        [StringLength(254)]
        public string IDContact { get; set; }

        [Required]
        [StringLength(254)]
        public string IDEntreprise { get; set; }

        [StringLength(254)]
        public string NomContact { get; set; }

        [StringLength(254)]
        public string PrenomContact { get; set; }

        [StringLength(254)]
        public string FonctionContact { get; set; }

        [StringLength(50)]
        public string TelContact { get; set; }

        public EntrepriseMere EntrepriseMere { get; set; }
    }
}
