namespace XiaoTuan.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("activityCollection")]
    public partial class activityCollection
    {
        [Key]
        [StringLength(50)]
        public string collection_id { get; set; }

        [StringLength(50)]
        public string userid { get; set; }

        [StringLength(50)]
        public string activity_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? time { get; set; }

        public virtual activity activity { get; set; }

        public virtual student student { get; set; }
    }
}
