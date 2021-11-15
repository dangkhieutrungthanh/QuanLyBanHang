namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(50)]
        public string MaNV { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name = "Họ")]
        public string HoNV { get; set; }
        [Required]
        [StringLength(10)]
        [Display(Name ="Tên")]
        public string TenNV { get; set; }
        [Required]
        [StringLength(50)]
        public string DiaChi { get; set; }

        [Required]
        [StringLength(15)]
        public string DienThoai { get; set; }
    }
}
