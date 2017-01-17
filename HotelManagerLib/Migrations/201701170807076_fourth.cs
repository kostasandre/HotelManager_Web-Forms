namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
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
                        Booking_Id = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Booking", t => t.Booking_Id, cascadeDelete: true)
                .Index(t => t.Booking_Id);
            
            CreateTable(
                "dbo.BillingService",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Billing", t => t.BillingId, cascadeDelete: true)
                .Index(t => t.BillingId);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingServiceId = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 150),
                        Description = c.String(),
                        Hotels_Id = c.Int(),
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotel", t => t.Hotels_Id)
                .ForeignKey("dbo.BillingService", t => t.BillingServiceId, cascadeDelete: true)
                .Index(t => t.BillingServiceId)
                .Index(t => t.Hotels_Id);
            
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
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
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
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PricingLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        ValidFrom = c.DateTime(nullable: false),
                        ValidTo = c.DateTime(nullable: false),
                        VatPrc = c.Double(nullable: false),
                        Created = c.DateTime(nullable: false) ,
                        CreatedBy = c.String() ,
                        Updated = c.DateTime() ,
                        UpdatedBy = c.String() ,
                        Deleted = c.DateTime() ,
                        DeletedBy = c.String() ,
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Hotel", "Services_Id", c => c.Int());
            CreateIndex("dbo.Hotel", "Services_Id");
            AddForeignKey("dbo.Hotel", "Services_Id", "dbo.Service", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billing", "Booking_Id", "dbo.Booking");
            DropForeignKey("dbo.Booking", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Booking", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.BillingService", "BillingId", "dbo.Billing");
            DropForeignKey("dbo.Service", "BillingServiceId", "dbo.BillingService");
            DropForeignKey("dbo.Service", "Hotels_Id", "dbo.Hotel");
            DropForeignKey("dbo.Hotel", "Services_Id", "dbo.Service");
            DropIndex("dbo.Booking", new[] { "RoomId" });
            DropIndex("dbo.Booking", new[] { "CustomerId" });
            DropIndex("dbo.Hotel", new[] { "Services_Id" });
            DropIndex("dbo.Service", new[] { "Hotels_Id" });
            DropIndex("dbo.Service", new[] { "BillingServiceId" });
            DropIndex("dbo.BillingService", new[] { "BillingId" });
            DropIndex("dbo.Billing", new[] { "Booking_Id" });
            DropColumn("dbo.Hotel", "Services_Id");
            DropTable("dbo.PricingLists");
            DropTable("dbo.Customer");
            DropTable("dbo.Booking");
            DropTable("dbo.Service");
            DropTable("dbo.BillingService");
            DropTable("dbo.Billing");
        }
    }
}
