namespace QuanLyBanHang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Create_Table_1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoaiSP", "TenLSP", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LoaiSP", "TenLSP", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
