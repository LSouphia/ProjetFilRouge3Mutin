namespace BiblioMetierBOL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Droit")]
    public partial class Droit
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(254)]
        public string IDUtilisateur { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(254)]
        public string IDCasUtilisation { get; set; }

        public bool? Ecriture { get; set; }

        public bool? Lecture { get; set; }

        public Casd_utilisation Casd_utilisation { get; set; }

        public Utilisateur Utilisateur { get; set; }
    }
}
