namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerCascadeDeleteFalse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Booking", "CustomerId", "dbo.Customer");
            AddForeignKey("dbo.Booking", "CustomerId", "dbo.Customer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "CustomerId", "dbo.Customer");
            AddForeignKey("dbo.Booking", "CustomerId", "dbo.Customer", "Id", cascadeDelete: true);
        }
    }
}
