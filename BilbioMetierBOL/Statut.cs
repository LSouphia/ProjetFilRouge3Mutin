namespace BiblioMetierDLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Statut")]
    public partial class Statut
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Statut()
        {
            Contrats = new HashSet<Contrat>();
        }

        [Key]
        [StringLength(254)]
        public string IDStatut { get; set; }

        [StringLength(254)]
        public string LibelleStatut { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrat> Contrats { get; set; }
    }
}
