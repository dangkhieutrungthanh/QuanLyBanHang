namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSP { get; set; }

        public int SoLuong { get; set; }

        public double DonGiaNhap { get; set; }

        public double DonGiaBan { get; set; }
        [StringLength(10)]
        public string MaLoaiSP { get; set; }
    }
}
