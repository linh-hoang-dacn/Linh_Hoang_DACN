namespace dienthoaididong.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hoadon")]
    public partial class hoadon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hoadon()
        {
            chitiethoadons = new HashSet<chitiethoadon>();
        }

        [Key]
        public int hoadon_id { get; set; }

        public DateTime? ngaygiao { get; set; }

        public DateTime? ngaydat { get; set; }

        [StringLength(50)]
        public string dathanhtoan { get; set; }

        [StringLength(50)]
        public string tinhtranggiaohang { get; set; }

        public int? khachhang_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitiethoadon> chitiethoadons { get; set; }

        public virtual khachhang khachhang { get; set; }
    }
}
