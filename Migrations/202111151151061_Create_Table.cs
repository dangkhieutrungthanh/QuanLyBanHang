namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CTHD",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 30),
                        MaSP = c.String(nullable: false, maxLength: 50),
                        SoLuong = c.Double(nullable: false),
                        DonGiaBan = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        MaHD = c.String(nullable: false, maxLength: 10),
                        MaKH = c.String(nullable: false, maxLength: 10),
                        MaNV = c.String(nullable: false, maxLength: 10),
                        NgayLapHD = c.DateTime(nullable: false),
                        NgayGiaoHang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 10),
                        TenKH = c.String(nullable: false, maxLength: 50),
                        DiaChi = c.String(maxLength: 50),
                        DienThoai = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.LoaiSP",
                c => new
                    {
                        MaLoaiSP = c.String(nullable: false, maxLength: 10),
                        TenSP = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 50),
                        HoNV = c.String(nullable: false, maxLength: 10),
                        TenNV = c.String(nullable: false, maxLength: 10),
                        DiaChi = c.String(nullable: false, maxLength: 50),
                        DienThoai = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.String(nullable: false, maxLength: 10),
                        TenSP = c.String(nullable: false, maxLength: 50),
                        SoLuong = c.Int(nullable: false),
                        DonGiaNhap = c.Double(nullable: false),
                        DonGiaBan = c.Double(nullable: false),
                        MaLoaiSP = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.MaSP);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SanPham");
            DropTable("dbo.NhanVien");
            DropTable("dbo.LoaiSP");
            DropTable("dbo.KhachHang");
            DropTable("dbo.HoaDon");
            DropTable("dbo.CTHD");
        }
    }
}
