namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class beforepresentation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Room", "HotelId", "dbo.Hotel");
            AddForeignKey("dbo.Room", "HotelId", "dbo.Hotel", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Room", "HotelId", "dbo.Hotel");
            AddForeignKey("dbo.Room", "HotelId", "dbo.Hotel", "Id");
        }
    }
}
