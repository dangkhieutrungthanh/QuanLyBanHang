namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        PassWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.CTPN",
                c => new
                    {
                        MaCTPN = c.String(nullable: false, maxLength: 128),
                        MaPN = c.String(nullable: false, maxLength: 128),
                        MaSP = c.String(nullable: false, maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaCTPN)
                .ForeignKey("dbo.PNhap", t => t.MaPN, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaPN)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.PNhap",
                c => new
                    {
                        MaPN = c.String(nullable: false, maxLength: 128),
                        MaNCC = c.String(nullable: false, maxLength: 128),
                        MaNV = c.String(nullable: false, maxLength: 128),
                        NgayLapHD = c.DateTime(nullable: false),
                        NgayGiaoHang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaPN)
                .ForeignKey("dbo.NCC", t => t.MaNCC, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.MaNV, cascadeDelete: true)
                .Index(t => t.MaNCC)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.NCC",
                c => new
                    {
                        MaNCC = c.String(nullable: false, maxLength: 128),
                        TenNCC = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        DienThoai = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MaNCC);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNV = c.String(nullable: false, maxLength: 128),
                        TenNV = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        DienThoai = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.String(nullable: false, maxLength: 128),
                        TenSP = c.String(nullable: false),
                        DonViTinh = c.String(),
                        SoLuong = c.Int(nullable: false),
                        MaLoaiSP = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.LoaiSP", t => t.MaLoaiSP)
                .Index(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.CTPX",
                c => new
                    {
                        MaCTPX = c.String(nullable: false, maxLength: 128),
                        MaPX = c.String(nullable: false, maxLength: 128),
                        MaSP = c.String(nullable: false, maxLength: 128),
                        SoLuong = c.Int(nullable: false),
                        DonGia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaCTPX)
                .ForeignKey("dbo.PXuat", t => t.MaPX, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.MaSP, cascadeDelete: true)
                .Index(t => t.MaPX)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.PXuat",
                c => new
                    {
                        MaPX = c.String(nullable: false, maxLength: 128),
                        MaKH = c.String(nullable: false, maxLength: 128),
                        MaNV = c.String(nullable: false, maxLength: 128),
                        NgayLapHD = c.DateTime(nullable: false),
                        NgayGiaoHang = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaPX)
                .ForeignKey("dbo.KhachHang", t => t.MaKH, cascadeDelete: true)
                .ForeignKey("dbo.NhanVien", t => t.MaNV, cascadeDelete: true)
                .Index(t => t.MaKH)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.String(nullable: false, maxLength: 128),
                        TenKH = c.String(nullable: false),
                        DiaChi = c.String(nullable: false),
                        DienThoai = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.LoaiSP",
                c => new
                    {
                        MaLoaiSP = c.String(nullable: false, maxLength: 128),
                        TenSP = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SanPham", "MaLoaiSP", "dbo.LoaiSP");
            DropForeignKey("dbo.CTPX", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.PXuat", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.PXuat", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.CTPX", "MaPX", "dbo.PXuat");
            DropForeignKey("dbo.CTPN", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.PNhap", "MaNV", "dbo.NhanVien");
            DropForeignKey("dbo.PNhap", "MaNCC", "dbo.NCC");
            DropForeignKey("dbo.CTPN", "MaPN", "dbo.PNhap");
            DropIndex("dbo.PXuat", new[] { "MaNV" });
            DropIndex("dbo.PXuat", new[] { "MaKH" });
            DropIndex("dbo.CTPX", new[] { "MaSP" });
            DropIndex("dbo.CTPX", new[] { "MaPX" });
            DropIndex("dbo.SanPham", new[] { "MaLoaiSP" });
            DropIndex("dbo.PNhap", new[] { "MaNV" });
            DropIndex("dbo.PNhap", new[] { "MaNCC" });
            DropIndex("dbo.CTPN", new[] { "MaSP" });
            DropIndex("dbo.CTPN", new[] { "MaPN" });
            DropTable("dbo.LoaiSP");
            DropTable("dbo.KhachHang");
            DropTable("dbo.PXuat");
            DropTable("dbo.CTPX");
            DropTable("dbo.SanPham");
            DropTable("dbo.NhanVien");
            DropTable("dbo.NCC");
            DropTable("dbo.PNhap");
            DropTable("dbo.CTPN");
            DropTable("dbo.Accounts");
        }
    }
}
