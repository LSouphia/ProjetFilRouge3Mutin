namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [Table("Utilisateur")]
    public partial class Utilisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Utilisateur()
        {
            Contrats = new HashSet<Contrat>();
            Droits = new HashSet<Droit>();
        }

        [Key]
        [StringLength(254)]
        public string IDUtilisateur { get; set; }

        [Required]
        [StringLength(254)]
        public string IDService { get; set; }

        [StringLength(254)]
        public string NomUtilisateur { get; set; }

        [StringLength(254)]
        public string PrenomUtilisateur { get; set; }

        [StringLength(254)]
        public string MotDePasseUtilisateur { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Contrat> Contrats { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Droit> Droits { get; set; }

        public Service Service { get; set; }
    }
}
