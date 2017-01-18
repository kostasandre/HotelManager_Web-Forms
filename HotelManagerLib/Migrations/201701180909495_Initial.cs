namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Billing",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Paid = c.Boolean(nullable: false),
                        PriceForRoom = c.Double(nullable: false),
                        PriceForServices = c.Double(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Booking", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.BillingService",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ServiceId = c.Int(nullable: false),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Billing", t => t.BillingId, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.BillingId)
                .Index(t => t.ServiceId);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(nullable: false),
                        Email = c.String(),
                        Manager = c.String(nullable: false, maxLength: 150),
                        Name = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(nullable: false),
                        PictureId = c.Int(),
                        TaxId = c.String(nullable: false, maxLength: 11),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Picture", t => t.PictureId)
                .Index(t => t.PictureId);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 150),
                        Content = c.Binary(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Room",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 150),
                        HotelId = c.Int(nullable: false),
                        RoomTypeId = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotel", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.RoomType", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.HotelId)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.RoomType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BedType = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 150),
                        Sauna = c.Boolean(nullable: false),
                        Tv = c.Boolean(nullable: false),
                        View = c.Int(nullable: false),
                        WiFi = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AgreedPrice = c.Double(nullable: false),
                        Comments = c.String(),
                        CustomerId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        RoomId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        SystemPrice = c.Double(nullable: false),
                        To = c.DateTime(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.Room", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Email = c.String(),
                        IdNumber = c.String(),
                        Name = c.String(nullable: false, maxLength: 150),
                        Phone = c.String(),
                        Surname = c.String(nullable: false, maxLength: 150),
                        TaxId = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PricingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillableEntityId = c.Int(nullable: false),
                        TypeOfBillableEntity = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(nullable: false),
                        VatPrc = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Updated = c.DateTime(),
                        UpdatedBy = c.String(),
                        Deleted = c.DateTime(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomPictures",
                c => new
                    {
                        Room_Id = c.Int(nullable: false),
                        Picture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Id, t.Picture_Id })
                .ForeignKey("dbo.Room", t => t.Room_Id, cascadeDelete: true)
                .ForeignKey("dbo.Picture", t => t.Picture_Id, cascadeDelete: true)
                .Index(t => t.Room_Id)
                .Index(t => t.Picture_Id);
            
            CreateTable(
                "dbo.HotelServices",
                c => new
                    {
                        Hotel_Id = c.Int(nullable: false),
                        Service_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Hotel_Id, t.Service_Id })
                .ForeignKey("dbo.Hotel", t => t.Hotel_Id, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.Service_Id, cascadeDelete: true)
                .Index(t => t.Hotel_Id)
                .Index(t => t.Service_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billing", "Id", "dbo.Booking");
            DropForeignKey("dbo.Booking", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Booking", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.BillingService", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.HotelServices", "Service_Id", "dbo.Service");
            DropForeignKey("dbo.HotelServices", "Hotel_Id", "dbo.Hotel");
            DropForeignKey("dbo.Room", "RoomTypeId", "dbo.RoomType");
            DropForeignKey("dbo.RoomPictures", "Picture_Id", "dbo.Picture");
            DropForeignKey("dbo.RoomPictures", "Room_Id", "dbo.Room");
            DropForeignKey("dbo.Room", "HotelId", "dbo.Hotel");
            DropForeignKey("dbo.Hotel", "PictureId", "dbo.Picture");
            DropForeignKey("dbo.BillingService", "BillingId", "dbo.Billing");
            DropIndex("dbo.HotelServices", new[] { "Service_Id" });
            DropIndex("dbo.HotelServices", new[] { "Hotel_Id" });
            DropIndex("dbo.RoomPictures", new[] { "Picture_Id" });
            DropIndex("dbo.RoomPictures", new[] { "Room_Id" });
            DropIndex("dbo.Booking", new[] { "RoomId" });
            DropIndex("dbo.Booking", new[] { "CustomerId" });
            DropIndex("dbo.Room", new[] { "RoomTypeId" });
            DropIndex("dbo.Room", new[] { "HotelId" });
            DropIndex("dbo.Hotel", new[] { "PictureId" });
            DropIndex("dbo.BillingService", new[] { "ServiceId" });
            DropIndex("dbo.BillingService", new[] { "BillingId" });
            DropIndex("dbo.Billing", new[] { "Id" });
            DropTable("dbo.HotelServices");
            DropTable("dbo.RoomPictures");
            DropTable("dbo.PricingLists");
            DropTable("dbo.Customer");
            DropTable("dbo.Booking");
            DropTable("dbo.RoomType");
            DropTable("dbo.Room");
            DropTable("dbo.Picture");
            DropTable("dbo.Hotel");
            DropTable("dbo.Service");
            DropTable("dbo.BillingService");
            DropTable("dbo.Billing");
        }
    }
}
