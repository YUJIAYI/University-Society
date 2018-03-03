namespace XiaoTuan.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("task")]
    public partial class task
    {
        [Key]
        [StringLength(50)]
        public string task_id { get; set; }

        [StringLength(50)]
        public string title { get; set; }

        [StringLength(50)]
        public string Initiator_id { get; set; }

        [StringLength(50)]
        public string allocator_id { get; set; }

        [StringLength(500)]
        public string task_detail { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? end_time { get; set; }

        [StringLength(500)]
        public string task_enclosure { get; set; }

        public int? task_state { get; set; }

        [StringLength(50)]
        public string return_reason { get; set; }

        public int? task_evaluate { get; set; }

        [StringLength(500)]
        public string evaluate_content { get; set; }

        public virtual orgMember orgMember { get; set; }

        public virtual orgMember orgMember1 { get; set; }
    }
}
