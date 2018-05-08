namespace dienthoaididong.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("khachhang")]
    public partial class khachhang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public khachhang()
        {
            hoadons = new HashSet<hoadon>();
        }

        [Key]
        [Display(Name = "Mã khách hàng")]//thuoc tinh display để đặt lại tên cho cột.
        public int khachhang_id { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên khách hàng")]//thuoc tinh display để đặt lại tên cho cột.
        [Required(ErrorMessage = "{0} Không được để trống")]  //kiểm tra rỗng

        public string khachhang_name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày sinh")]//thuoc tinh display để đặt lại tên cho cột.
        [Required(ErrorMessage = "{0} Không được để trống")]  //kiểm tra rỗng

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")] //định dạng dữ liệu
        [DataType(DataType.Date)]//dùng để hỗ trợ kiểu dữ liệu ngày

        public DateTime? khachhang_ns { get; set; }

        [StringLength(50)]
        [Display(Name = "Địa chỉ")]//thuoc tinh display để đặt lại tên cho cột.
        [Required(ErrorMessage = "{0} Không được để trống")]  //kiểm tra rỗng

        public string khachhang_diachi { get; set; }

        [StringLength(15)]
        [Display(Name = "Số điện thoại")]//thuoc tinh display để đặt lại tên cho cột.
        [Required(ErrorMessage = "{0} Không được để trống")]  //kiểm tra rỗng

        public string khachhang_sdt { get; set; }

        [StringLength(50)]
        [Display(Name = "Tài khoản")]//thuoc tinh display để đặt lại tên cho cột.
        [Required(ErrorMessage = "{0} Không được để trống")]  //kiểm tra rỗng

        public string khachhang_taikhoan { get; set; }

        [StringLength(50)]
        [Display(Name = "Mật khẩu")]//thuoc tinh display để đặt lại tên cho cột.
        [Required(ErrorMessage = "{0} Không được để trống")]  //kiểm tra rỗng

        public string khachhang_matkhau { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hoadon> hoadons { get; set; }
    }
}
