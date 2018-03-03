namespace XiaoTuan.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("organization")]
    public partial class organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public organization()
        {
            activity = new HashSet<activity>();
            organizationalConcerns = new HashSet<organizationalConcerns>();
            orgMember = new HashSet<orgMember>();
        }

        [Key]
        [StringLength(50)]
        public string org_id { get; set; }

        [StringLength(50)]
        public string org_name { get; set; }

        [StringLength(50)]
        public string user_id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? establish_time { get; set; }

        [StringLength(500)]
        public string org_introduce { get; set; }

        [StringLength(500)]
        public string Internal_construction { get; set; }

        public int? org_state { get; set; }

        [StringLength(500)]
        public string org_logo { get; set; }

        [StringLength(500)]
        public string org_enclosure { get; set; }

        [StringLength(50)]
        public string superior_org_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<activity> activity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<organizationalConcerns> organizationalConcerns { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<orgMember> orgMember { get; set; }
    }
}
