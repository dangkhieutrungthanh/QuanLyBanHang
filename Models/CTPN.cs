namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTPN")]
    public partial class CTPN
    {
        [Key]
        public string MaCTPN { get; set; }
        [Required]
        public string MaPN { get; set; }

        [Required]
        public string MaSP { get; set; }

        [Required]
        public int SoLuong { get; set; }

        [Required, DataType(DataType.Currency)]
        public int DonGia { get; set; }

        public PNhap PNhaps { get; set; }
        public SanPham SanPhams { get; set; }
    }
}