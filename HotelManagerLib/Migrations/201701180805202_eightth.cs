namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eightth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Service", "Hotel_Id", "dbo.Hotel");
            DropForeignKey("dbo.Service", "Hotels_Id", "dbo.Hotel");
            DropIndex("dbo.Service", new[] { "Hotel_Id" });
            DropIndex("dbo.Service", new[] { "Hotels_Id" });
            DropColumn("dbo.Service", "Hotel_Id");
            DropColumn("dbo.Service", "Hotels_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Service", "Hotels_Id", c => c.Int());
            AddColumn("dbo.Service", "Hotel_Id", c => c.Int());
            CreateIndex("dbo.Service", "Hotels_Id");
            CreateIndex("dbo.Service", "Hotel_Id");
            AddForeignKey("dbo.Service", "Hotels_Id", "dbo.Hotel", "Id");
            AddForeignKey("dbo.Service", "Hotel_Id", "dbo.Hotel", "Id");
        }
    }
}
