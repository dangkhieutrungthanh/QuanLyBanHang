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
        public string MaNV { get; set; }

        [Required]
        public string TenNV { get; set; }
        [Required]
        public string DiaChi { get; set; }

        [Required]
        public string DienThoai { get; set; }
    }
}