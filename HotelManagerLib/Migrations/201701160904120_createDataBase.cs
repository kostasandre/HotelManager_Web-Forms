namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        Manager = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        TaxId = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Content = c.Binary(),
                        
                        HotelId = c.Int(),
                        RoomId = c.Int(),
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Room", t => t.RoomId)
                .ForeignKey("dbo.Hotel", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        HotelId = c.Int(nullable: false),
                        RoomTypeId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoomType", t => t.RoomTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Hotel", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.RoomType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BedType = c.Int(nullable: false),
                        Code = c.String(nullable: false),
                        Sauna = c.Boolean(nullable: false),
                        Tv = c.Boolean(nullable: false),
                        View = c.Int(nullable: false),
                        WiFi = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Room", "HotelId", "dbo.Hotel");
            DropForeignKey("dbo.Picture", "Id", "dbo.Hotel");
            DropForeignKey("dbo.Room", "RoomTypeId", "dbo.RoomType");
            DropForeignKey("dbo.Picture", "RoomId", "dbo.Room");
            DropIndex("dbo.Room", new[] { "RoomTypeId" });
            DropIndex("dbo.Room", new[] { "HotelId" });
            DropIndex("dbo.Picture", new[] { "RoomId" });
            DropIndex("dbo.Picture", new[] { "Id" });
            DropTable("dbo.RoomType");
            DropTable("dbo.Room");
            DropTable("dbo.Picture");
            DropTable("dbo.Hotel");
        }
    }
}
