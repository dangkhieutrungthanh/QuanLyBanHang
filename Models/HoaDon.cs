namespace QuanLyBanHang.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [StringLength(10)]
        public string MaHD{ get; set; }

        [Required]
        [StringLength(10)]
        public string MaKH { get; set; }
        [Required]
        [StringLength(10)]
        public string MaNV { get; set; }
        public DateTime NgayLapHD { get; set; }


        public DateTime NgayGiaoHang { get; set; }
    }
}
