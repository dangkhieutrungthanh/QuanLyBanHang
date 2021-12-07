namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PXuat")]
    public partial class PXuat
    {
        [Key]
        public string MaPX { get; set; }

        [Required]
        public string MaKH { get; set; }

        [Required]
        public string MaNV { get; set; }

        [DataType(DataType.Date),Display(Name = "Ngày lập HĐ")]
        public DateTime NgayLapHD { get; set; }

        [DataType(DataType.Date), Display(Name = "Ngày giao hàng")]
        public DateTime NgayGiaoHang { get; set; }

        public KhachHang KhachHangs { get; set; }
        public NhanVien NhanViens { get; set; }

        public ICollection<CTPX> CTPXs { get; set; }

    }
}