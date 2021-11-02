namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hang")]
    public partial class Hang
    {
        [Key]
        [StringLength(50)]
        public string MaHang { get; set; }

        [Required]
        [StringLength(50)]
        public string TenHang { get; set; }

        public double SoLuong { get; set; }

        public double DonGiaNhap { get; set; }

        public double DonGiaBan { get; set; }

        [StringLength(200)]
        public string Anh { get; set; }

        [StringLength(10)]
        public string GhiChu { get; set; }
    }
}
