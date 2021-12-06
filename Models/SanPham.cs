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
        public string MaSP { get; set; }

        [Required]
        public string TenSP { get; set; }
        public string DonViTinh { get; set; }
        public int SoLuong { get; set; }
        public string MaLoaiSP { get; set; }
        public LoaiSP LoaiSPs { get; set; }
        public ICollection<CTPN> CTPNs { get; set; }
        public ICollection<CTPX> CTPXs { get; set; }
    }
}