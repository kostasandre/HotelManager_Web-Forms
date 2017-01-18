namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10th : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelServices",
                c => new
                    {
                        Hotel_Id = c.Int(nullable: false),
                        Service_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hotel_Id, t.Service_Id })
                .ForeignKey("dbo.Hotel", t => t.Hotel_Id, cascadeDelete: false)
                .ForeignKey("dbo.Service", t => t.Service_Id, cascadeDelete: false)
                .Index(t => t.Hotel_Id)
                .Index(t => t.Service_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HotelServices", "Service_Id", "dbo.Service");
            DropForeignKey("dbo.HotelServices", "Hotel_Id", "dbo.Hotel");
            DropIndex("dbo.HotelServices", new[] { "Service_Id" });
            DropIndex("dbo.HotelServices", new[] { "Hotel_Id" });
            DropTable("dbo.HotelServices");
        }
    }
}
