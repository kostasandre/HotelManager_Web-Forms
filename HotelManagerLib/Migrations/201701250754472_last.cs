namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HotelServices", "Hotel_Id", "dbo.Hotel");
            DropForeignKey("dbo.HotelServices", "Service_Id", "dbo.Service");
            DropForeignKey("dbo.Room", "HotelId", "dbo.Hotel");
            DropIndex("dbo.HotelServices", new[] { "Hotel_Id" });
            DropIndex("dbo.HotelServices", new[] { "Service_Id" });
            AddColumn("dbo.Service", "HotelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Service", "HotelId");
            AddForeignKey("dbo.Service", "HotelId", "dbo.Hotel", "Id");
            AddForeignKey("dbo.Room", "HotelId", "dbo.Hotel", "Id");
            DropTable("dbo.HotelServices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HotelServices",
                c => new
                    {
                        Hotel_Id = c.Int(nullable: false),
                        Service_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hotel_Id, t.Service_Id });
            
            DropForeignKey("dbo.Room", "HotelId", "dbo.Hotel");
            DropForeignKey("dbo.Service", "HotelId", "dbo.Hotel");
            DropIndex("dbo.Service", new[] { "HotelId" });
            DropColumn("dbo.Service", "HotelId");
            CreateIndex("dbo.HotelServices", "Service_Id");
            CreateIndex("dbo.HotelServices", "Hotel_Id");
            AddForeignKey("dbo.Room", "HotelId", "dbo.Hotel", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HotelServices", "Service_Id", "dbo.Service", "Id", cascadeDelete: true);
            AddForeignKey("dbo.HotelServices", "Hotel_Id", "dbo.Hotel", "Id", cascadeDelete: true);
        }
    }
}
