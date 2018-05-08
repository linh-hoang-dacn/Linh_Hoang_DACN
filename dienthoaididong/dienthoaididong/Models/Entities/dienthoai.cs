namespace dienthoaididong.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class dienthoai : DbContext
    {
        public dienthoai()
            : base("name=dienthoai")
        {
        }

        public virtual DbSet<chitiethoadon> chitiethoadons { get; set; }
        public virtual DbSet<hoadon> hoadons { get; set; }
        public virtual DbSet<khachhang> khachhangs { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }
        public virtual DbSet<theloaisp> theloaisps { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<hoadon>()
                .HasMany(e => e.chitiethoadons)
                .WithRequired(e => e.hoadon)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<khachhang>()
                .Property(e => e.khachhang_sdt)
                .IsFixedLength();

            modelBuilder.Entity<sanpham>()
                .Property(e => e.hinhanh_sp)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.hinhanh_sp1)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.hinhanh_sp3)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.hinhanh_sp4)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.kichthuoc_hinhanh)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.camera_truoc)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .Property(e => e.camera_sau)
                .IsUnicode(false);

            modelBuilder.Entity<sanpham>()
                .HasMany(e => e.chitiethoadons)
                .WithRequired(e => e.sanpham)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<theloaisp>()
                .Property(e => e.parent_id)
                .IsFixedLength();
        }
    }
}
