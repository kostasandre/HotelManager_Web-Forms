namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sixth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Service", "BillingServiceId", "dbo.BillingService");
            DropIndex("dbo.Service", new[] { "BillingServiceId" });
            AddColumn("dbo.BillingService", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.BillingService", "ServiceId");
            AddForeignKey("dbo.BillingService", "ServiceId", "dbo.Service", "Id", cascadeDelete: true);
            DropColumn("dbo.Service", "BillingServiceId");
            DropColumn("dbo.PricingLists", "BillableEntityId");
            DropColumn("dbo.PricingLists", "TypeOfBillableEntity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PricingLists", "TypeOfBillableEntity", c => c.Int(nullable: false));
            AddColumn("dbo.PricingLists", "BillableEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.Service", "BillingServiceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.BillingService", "ServiceId", "dbo.Service");
            DropIndex("dbo.BillingService", new[] { "ServiceId" });
            DropColumn("dbo.BillingService", "ServiceId");
            CreateIndex("dbo.Service", "BillingServiceId");
            AddForeignKey("dbo.Service", "BillingServiceId", "dbo.BillingService", "Id", cascadeDelete: true);
        }
    }
}
