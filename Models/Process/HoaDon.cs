using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuanLyBanHang.Models
{

    public partial class HoaDon
    {
        [Required]
        public string MaKH { get; set; }
        public KhachHang KhachHangs { get; set; }
        [Required]
        public string MaNV { get; set; }
        public NhanVien NhanViens { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayLapHD { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgayGiaoHang { get; set; }
        public ICollection<CTHD> CTHDs { get; set; }
    }
}