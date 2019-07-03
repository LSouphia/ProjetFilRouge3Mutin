namespace BiblioMetierDLL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EntrepriseMere")]
    public partial class EntrepriseMere
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EntrepriseMere()
        {
            ContactEntreprises = new HashSet<ContactEntreprise>();
            Contrats = new HashSet<Contrat>();
        }

        [Key]
        [StringLength(254)]
        [Display(Name = "ID de l'entreprise")]
        public string IDEntreprise { get; set; }

        [StringLength(254)]
        public string IDApe { get; set; }

        [StringLength(254)]
        public string DesignationEntreprise { get; set; }

        [StringLength(254)]
        public string AdresseEntreprise { get; set; }

        public int? CodePostalEntreprise { get; set; }

        [StringLength(254)]
        public string VilleEntreprise { get; set; }

        [StringLength(50)]
        public string TelEntreprise { get; set; }

        public int? EffectifTotal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactEntreprise> ContactEntreprises { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrat> Contrats { get; set; }
    }
}
