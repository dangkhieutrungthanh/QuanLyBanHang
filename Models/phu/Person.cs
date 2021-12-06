using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyBanHang.Models
{
    public class Person
    {
        [Required]
        public string Ten { get; set; }
        [Required]
        public string DiaChi { get; set; }
        [Required]
        public string DienThoai { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}