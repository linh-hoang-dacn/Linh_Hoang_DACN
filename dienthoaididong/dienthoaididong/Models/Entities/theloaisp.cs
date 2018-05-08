namespace dienthoaididong.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("theloaisp")]
    public partial class theloaisp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public theloaisp()
        {
            sanphams = new HashSet<sanpham>();
        }

        [Key]
        [StringLength(50)]
        public string theloai_id { get; set; }

        [StringLength(50)]
        public string theloai_name { get; set; }

        public int? phukien { get; set; }

        [StringLength(10)]
        public string parent_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sanpham> sanphams { get; set; }
    }
}
