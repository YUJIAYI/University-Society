namespace XiaoTuan.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("activity")]
    public partial class activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public activity()
        {
            activityCollection = new HashSet<activityCollection>();
            photo = new HashSet<photo>();
            enroll = new HashSet<enroll>();
        }

        [Key]
        [StringLength(50)]
        public string activity_id { get; set; }

        [StringLength(50)]
        public string org_id { get; set; }

        [StringLength(50)]
        public string activity_name { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? activity_time { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? sign_end_time { get; set; }

        [StringLength(500)]
        public string activity_detail { get; set; }

        [StringLength(500)]
        public string sign_notice { get; set; }

        [StringLength(500)]
        public string activity_place { get; set; }

        [StringLength(500)]
        public string activity_photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<activityCollection> activityCollection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<photo> photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enroll> enroll { get; set; }

        public virtual organization organization { get; set; }
    }
}
