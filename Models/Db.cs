using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyBanHang.Models
{
    public partial class Db : DbContext
    {
        public Db() : base("name=DbContext")
           
        {
        }

        public virtual DbSet<ChatLieu> ChatLieus { get; set; }
        public virtual DbSet<Hang> Hangs { get; set; }
        public virtual DbSet<HDBan> HDBans { get; set; }
        public virtual DbSet<Khach> Khachs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<ChiTietHDBan> ChiTietHDBans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hang>()
                .Property(e => e.GhiChu)
                .IsFixedLength();
        }
    }
}
