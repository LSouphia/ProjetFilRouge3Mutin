namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Table("CategorieSocioPro")]
    public partial class CategorieSocioPro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategorieSocioPro()
        {
            Contrats = new HashSet<Contrat>();
            Personnes = new HashSet<Personne>();
        }

        [Key]
        [StringLength(254)]
        public string IDCatSocioPro { get; set; }

        [StringLength(254)]
        public string TypeCatSocioPro { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Contrat> Contrats { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Personne> Personnes { get; set; }
    }
}
