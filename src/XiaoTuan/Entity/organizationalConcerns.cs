namespace XiaoTuan.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class organizationalConcerns
    {
        [Key]
        [StringLength(50)]
        public string concerns_id { get; set; }

        [StringLength(50)]
        public string userid { get; set; }

        [StringLength(50)]
        public string org_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? time { get; set; }

        public virtual organization organization { get; set; }

        public virtual student student { get; set; }
    }
}
