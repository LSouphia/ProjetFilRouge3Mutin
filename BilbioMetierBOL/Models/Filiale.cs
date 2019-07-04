namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Table("Filiale")]
    public partial class Filiale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Filiale()
        {
            Contrats = new HashSet<Contrat>();
        }

        [Key]
        [StringLength(254)]
        public string IDFiliale { get; set; }

        [Required]
        [StringLength(254)]
        public string IDEntreprise { get; set; }

        [StringLength(254)]
        public string NomFil { get; set; }

        [StringLength(254)]
        public string AdresseFil { get; set; }

        [StringLength(10)]
        public string CodePostalFil { get; set; }

        [StringLength(254)]
        public string VilleFil { get; set; }

        [StringLength(10)]
        public string TelFil { get; set; }

        public int? EffectifFil { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Contrat> Contrats { get; set; }

        public EntrepriseMere EntrepriseMere { get; set; }
    }
}
