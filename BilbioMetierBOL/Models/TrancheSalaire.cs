namespace MutBiblioMetierBOLIn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TrancheSalaire")]
    public partial class TrancheSalaire
    {
        [Key]
        [StringLength(50)]
        public string IDTrancheSal { get; set; }

        public int? MontantTrancheSal { get; set; }
    }
}
