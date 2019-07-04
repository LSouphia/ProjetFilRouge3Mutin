namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Table("Organisme")]
    public partial class Organisme
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organisme()
        {
            Contrats = new HashSet<Contrat>();
            Services = new HashSet<Service>();
        }

        [Key]
        [StringLength(254)]
        public string IDOrganisme { get; set; }

        [StringLength(254)]
        public string NomOrga { get; set; }

        [StringLength(254)]
        public string Adresse { get; set; }

        public int? CodePostal { get; set; }

        [StringLength(254)]
        public string Ville { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        [StringLength(254)]
        public string Mail { get; set; }

        public int? Ca { get; set; }

        public bool? Siege { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Contrat> Contrats { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Service> Services { get; set; }
    }
}
