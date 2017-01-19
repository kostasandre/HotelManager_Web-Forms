namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11th : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Billing", "Id", "dbo.Booking");
            DropIndex("dbo.Billing", new[] { "Id" });
            AddColumn("dbo.Billing", "BookingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Billing", "BookingId");
            AddForeignKey("dbo.Billing", "BookingId", "dbo.Booking", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Billing", "BookingId", "dbo.Booking");
            DropIndex("dbo.Billing", new[] { "BookingId" });
            DropColumn("dbo.Billing", "BookingId");
            CreateIndex("dbo.Billing", "Id");
            AddForeignKey("dbo.Billing", "Id", "dbo.Booking", "Id");
        }
    }
}
