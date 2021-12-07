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

        [Required,Display(Name ="Tên sản phẩm")]
        public string TenSP { get; set; }
        [Required,Display(Name = "Đơn vị tính")]
        public string DonViTinh { get; set; }
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }
        [Required]
        public string MaLoaiSP { get; set; }
        public LoaiSP LoaiSPs { get; set; }
        public ICollection<CTPN> CTPNs { get; set; }
        public ICollection<CTPX> CTPXs { get; set; }
    }
}