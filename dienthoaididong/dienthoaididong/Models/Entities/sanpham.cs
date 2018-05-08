namespace dienthoaididong.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sanpham")]
    public partial class sanpham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sanpham()
        {
            chitiethoadons = new HashSet<chitiethoadon>();
        }

        [Key]
        [Display(Name = "Mã sản phẩm")]//thuoc tinh display để đặt lại tên cho cột.
        public int sanpham_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên sản phẩm")]//thuoc tinh display để đặt lại tên cho cột.

        public string sanpham_name { get; set; }
        [Display(Name = "Giá cả")]//thuoc tinh display để đặt lại tên cho cột.

        public int? gia_sanpham { get; set; }
        [Display(Name = "Số lượng")]//thuoc tinh display để đặt lại tên cho cột.

        public int? soluong_sp { get; set; }

        [StringLength(50)]
        [Display(Name = "Thể loại")]//thuoc tinh display để đặt lại tên cho cột.

        public string theloai_id { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Hình ảnh")]//thuoc tinh display để đặt lại tên cho cột.

        public string hinhanh_sp { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Hình ảnh")]//thuoc tinh display để đặt lại tên cho cột.

        public string hinhanh_sp1 { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Hình ảnh")]//thuoc tinh display để đặt lại tên cho cột.

        public string hinhanh_sp3 { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Hình ảnh")]//thuoc tinh display để đặt lại tên cho cột.

        public string hinhanh_sp4 { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Kích thước h/a")]//thuoc tinh display để đặt lại tên cho cột.

        public string kichthuoc_hinhanh { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Camera trước")]//thuoc tinh display để đặt lại tên cho cột.

        public string camera_truoc { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Camera sau")]//thuoc tinh display để đặt lại tên cho cột.

        public string camera_sau { get; set; }

        [StringLength(200)]
        [Display(Name = "Hệ điều hành")]//thuoc tinh display để đặt lại tên cho cột.

        public string he_dieu_hanh { get; set; }

        [StringLength(200)]
        [Display(Name = "CPU")]//thuoc tinh display để đặt lại tên cho cột.

        public string cpu { get; set; }

        [StringLength(200)]
        [Display(Name = "RAM")]//thuoc tinh display để đặt lại tên cho cột.

        public string ram { get; set; }

        [StringLength(200)]
        [Display(Name = "Bộ nhớ trong")]//thuoc tinh display để đặt lại tên cho cột.

        public string bo_nho_trong { get; set; }

        [StringLength(200)]
        [Display(Name = "Thẻ nhớ")]//thuoc tinh display để đặt lại tên cho cột.

        public string the_nho { get; set; }

        [StringLength(200)]
        [Display(Name = "SIM")]//thuoc tinh display để đặt lại tên cho cột.

        public string sim { get; set; }

        [StringLength(200)]
        [Display(Name = "Kết nối")]//thuoc tinh display để đặt lại tên cho cột.

        public string ket_noi { get; set; }

        [StringLength(100)]
        [Display(Name = "PIN")]//thuoc tinh display để đặt lại tên cho cột.

        public string pin { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]//thuoc tinh display để đặt lại tên cho cột.

        public string chuthich { get; set; }
        [Display(Name = "Mới")]//thuoc tinh display để đặt lại tên cho cột.


        public int? moi { get; set; }
        [Display(Name = "Style")]//thuoc tinh display để đặt lại tên cho cột.


        public int? style { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<chitiethoadon> chitiethoadons { get; set; }

        public virtual theloaisp theloaisp { get; set; }
    }
}
