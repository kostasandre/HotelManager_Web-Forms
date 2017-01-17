namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Hotel", "Services_Id", "dbo.Service");
            DropForeignKey("dbo.Service", "Hotels_Id", "dbo.Hotel");
            DropForeignKey("dbo.Service", "BillingServiceId", "dbo.BillingService");
            DropForeignKey("dbo.BillingService", "BillingId", "dbo.Billing");
            DropForeignKey("dbo.Booking", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Booking", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Billing", "Booking_Id", "dbo.Booking");
            DropIndex("dbo.Billing", new[] { "Booking_Id" });
            DropIndex("dbo.BillingService", new[] { "BillingId" });
            DropIndex("dbo.Service", new[] { "BillingServiceId" });
            DropIndex("dbo.Service", new[] { "Hotels_Id" });
            DropIndex("dbo.Hotel", new[] { "Services_Id" });
            DropIndex("dbo.Booking", new[] { "CustomerId" });
            DropIndex("dbo.Booking", new[] { "RoomId" });
            DropColumn("dbo.Hotel", "Services_Id");
            DropTable("dbo.Billing");
            DropTable("dbo.BillingService");
            DropTable("dbo.Service");
            DropTable("dbo.Booking");
            DropTable("dbo.Customer");
            DropTable("dbo.PricingLists");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Hotel", "Services_Id", c => c.Int());
            CreateIndex("dbo.Booking", "RoomId");
            CreateIndex("dbo.Booking", "CustomerId");
            CreateIndex("dbo.Hotel", "Services_Id");
            CreateIndex("dbo.Service", "Hotels_Id");
            CreateIndex("dbo.Service", "BillingServiceId");
            CreateIndex("dbo.BillingService", "BillingId");
            CreateIndex("dbo.Billing", "Booking_Id");
            AddForeignKey("dbo.Billing", "Booking_Id", "dbo.Booking", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Booking", "RoomId", "dbo.Room", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Booking", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BillingService", "BillingId", "dbo.Billing", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Service", "BillingServiceId", "dbo.BillingService", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Service", "Hotels_Id", "dbo.Hotel", "Id");
            AddForeignKey("dbo.Hotel", "Services_Id", "dbo.Service", "Id");
        }
    }
}
