namespace XiaoTuan.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("student")]
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            activityCollection = new HashSet<activityCollection>();
            enroll = new HashSet<enroll>();
            organizationalConcerns = new HashSet<organizationalConcerns>();
            orgMember = new HashSet<orgMember>();
            photo1 = new HashSet<photo>();
        }

        [Key]
        [StringLength(50)]
        public string userid { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(500)]
        public string photo { get; set; }

        [StringLength(5)]
        public string sex { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? birthday { get; set; }

        [StringLength(50)]
        public string school { get; set; }

        [StringLength(50)]
        public string major { get; set; }

        [StringLength(50)]
        public string grade { get; set; }

        [StringLength(50)]
        public string cell_number { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? to_school_time { get; set; }

        [StringLength(50)]
        public string card_number { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? graduation_time { get; set; }

        public int? state { get; set; }

        [StringLength(100)]
        public string identfily_pic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<activityCollection> activityCollection { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enroll> enroll { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<organizationalConcerns> organizationalConcerns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orgMember> orgMember { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<photo> photo1 { get; set; }
    }
}
