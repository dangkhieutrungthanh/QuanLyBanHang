namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatLieu",
                c => new
                    {
                        MaChatLieu = c.String(nullable: false, maxLength: 50),
                        TenChatLieu = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.MaChatLieu);
            
            CreateTable(
                "dbo.ChiTietHDBan",
                c => new
                    {
                        MaHDBan = c.String(nullable: false, maxLength: 30),
                        MaHang = c.String(nullable: false, maxLength: 50),
                        SoLuong = c.Double(nullable: false),
                        DonGia = c.Double(nullable: false),
                        GiamGia = c.Double(nullable: false),
                        ThanhTien = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaHDBan);
            
            CreateTable(
                "dbo.Hang",
                c => new
                    {
                        MaHang = c.String(nullable: false, maxLength: 50),
                        TenHang = c.String(nullable: false, maxLength: 50),
                        SoLuong = c.Double(nullable: false),
                        DonGiaNhap = c.Double(nullable: false),
                        DonGiaBan = c.Double(nullable: false),
                        Anh = c.String(maxLength: 200),
                        GhiChu = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.MaHang);
            
            CreateTable(
                "dbo.HDBan",
                c => new
                    {
                        MaHDBan = c.String(nullable: false, maxLength: 30),
                        MaNhanVien = c.String(nullable: false, maxLength: 10),
                        NgayBan = c.DateTime(nullable: false),
                        MaKhach = c.String(nullable: false, maxLength: 10),
                        TongTien = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MaHDBan);
            
            CreateTable(
                "dbo.Khach",
                c => new
                    {
                        MaKhach = c.String(nullable: false, maxLength: 10),
                        TenKhach = c.String(nullable: false, maxLength: 50),
                        DiaChi = c.String(nullable: false, maxLength: 50),
                        DienThoai = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaKhach);
            
            CreateTable(
                "dbo.NhanVien",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 50),
                        TenNhanVien = c.String(nullable: false, maxLength: 50),
                        GioiTinh = c.String(nullable: false, maxLength: 10),
                        DiaChi = c.String(nullable: false, maxLength: 50),
                        DienThoai = c.String(nullable: false, maxLength: 15),
                        NgaySinh = c.DateTime(),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NhanVien");
            DropTable("dbo.Khach");
            DropTable("dbo.HDBan");
            DropTable("dbo.Hang");
            DropTable("dbo.ChiTietHDBan");
            DropTable("dbo.ChatLieu");
        }
    }
}
