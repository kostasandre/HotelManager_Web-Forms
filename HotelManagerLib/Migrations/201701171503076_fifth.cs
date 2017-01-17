namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fifth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PricingLists", "BillableEntityId", c => c.Int(nullable: false));
            AddColumn("dbo.PricingLists", "TypeOfBillableEntity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PricingLists", "TypeOfBillableEntity");
            DropColumn("dbo.PricingLists", "BillableEntityId");
        }
    }
}
