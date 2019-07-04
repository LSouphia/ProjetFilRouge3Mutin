namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    public partial class Casd_utilisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Casd_utilisation()
        {
            Droits = new HashSet<Droit>();
        }

        [Key]
        [StringLength(254)]
        public string IDCasUtilisation { get; set; }

        [StringLength(254)]
        public string LibelleCasUtil { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Droit> Droits { get; set; }
    }
}
