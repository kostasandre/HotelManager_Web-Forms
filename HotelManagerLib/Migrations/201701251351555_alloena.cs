namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alloena : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BillingService", "BillingId", "dbo.Billing");
            DropForeignKey("dbo.Service", "HotelId", "dbo.Hotel");
            AddForeignKey("dbo.BillingService", "BillingId", "dbo.Billing", "Id");
            AddForeignKey("dbo.Service", "HotelId", "dbo.Hotel", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Service", "HotelId", "dbo.Hotel");
            DropForeignKey("dbo.BillingService", "BillingId", "dbo.Billing");
            AddForeignKey("dbo.Service", "HotelId", "dbo.Hotel", "Id");
            AddForeignKey("dbo.BillingService", "BillingId", "dbo.Billing", "Id", cascadeDelete: true);
        }
    }
}
