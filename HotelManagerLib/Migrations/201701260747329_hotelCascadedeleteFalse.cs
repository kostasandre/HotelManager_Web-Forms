namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hotelCascadedeleteFalse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Service", "HotelId", "dbo.Hotel");
            DropForeignKey("dbo.Room", "HotelId", "dbo.Hotel");
            AddForeignKey("dbo.Service", "HotelId", "dbo.Hotel", "Id");
            AddForeignKey("dbo.Room", "HotelId", "dbo.Hotel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Room", "HotelId", "dbo.Hotel");
            DropForeignKey("dbo.Service", "HotelId", "dbo.Hotel");
            AddForeignKey("dbo.Room", "HotelId", "dbo.Hotel", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Service", "HotelId", "dbo.Hotel", "Id", cascadeDelete: true);
        }
    }
}
