namespace XiaoTuan.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("orgMember")]
    public partial class orgMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public orgMember()
        {
            task = new HashSet<task>();
            task1 = new HashSet<task>();
        }

        [Key]
        [StringLength(50)]
        public string org_member_id { get; set; }

        [Required]
        [StringLength(50)]
        public string org_id { get; set; }

        [Required]
        [StringLength(50)]
        public string user_id { get; set; }

        [StringLength(50)]
        public string position { get; set; }

        public virtual organization organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> task { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> task1 { get; set; }

        public virtual student student { get; set; }
    }
}
