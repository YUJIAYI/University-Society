namespace XiaoTuan.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("enroll")]
    public partial class enroll
    {
        [Key]
        [StringLength(50)]
        public string org_form_id { get; set; }

        [Required]
        [StringLength(50)]
        public string activity_id { get; set; }

        [Required]
        [StringLength(50)]
        public string user_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? sign_time { get; set; }

        public int? to_org_evaluate { get; set; }

        public int? to_activity_evalute { get; set; }

        [StringLength(500)]
        public string evaluate_content { get; set; }

        public int? state { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? evalute_time { get; set; }

        public virtual activity activity { get; set; }

        public virtual student student { get; set; }
    }
}
