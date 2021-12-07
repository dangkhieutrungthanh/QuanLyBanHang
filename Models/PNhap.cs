namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PNhap")]
    public partial class PNhap
    {
        [Key]
        public string MaPN { get; set; }

        [Required]
        public string MaNCC { get; set; }

        [Required]
        public string MaNV { get; set; }

        [DataType(DataType.Date), Display(Name = "Ngày lập HĐ")]
        public DateTime NgayLapHD { get; set; }

        [DataType(DataType.Date), Display(Name = "Ngày giao hàng")]
        public DateTime NgayGiaoHang { get; set; }

        public NCC NCCs { get; set; }
        public NhanVien NhanViens { get; set; }

        public ICollection<CTPN> CTPNs { get; set; }

    }
}