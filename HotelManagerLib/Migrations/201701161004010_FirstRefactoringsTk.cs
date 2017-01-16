namespace HotelManagerLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstRefactoringsTk : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Picture", "RoomId", "dbo.Room");
            DropForeignKey("dbo.Picture", "Id", "dbo.Hotel");
            DropIndex("dbo.Picture", new[] { "Id" });
            DropIndex("dbo.Picture", new[] { "RoomId" });
            CreateTable(
                "dbo.RoomPictures",
                c => new
                    {
                        Room_Id = c.Int(nullable: false),
                        Picture_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Room_Id, t.Picture_Id })
                .ForeignKey("dbo.Room", t => t.Room_Id, cascadeDelete: true)
                .ForeignKey("dbo.Picture", t => t.Picture_Id, cascadeDelete: true)
                .Index(t => t.Room_Id)
                .Index(t => t.Picture_Id);
            
            AddColumn("dbo.Hotel", "PictureId", c => c.Int());
            AlterColumn("dbo.Picture", "Code", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Picture", "Content", c => c.Binary(nullable: false));
            CreateIndex("dbo.Hotel", "PictureId");
            AddForeignKey("dbo.Hotel", "PictureId", "dbo.Picture", "Id");
            DropColumn("dbo.Picture", "HotelId");
            DropColumn("dbo.Picture", "RoomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Picture", "RoomId", c => c.Int());
            AddColumn("dbo.Picture", "HotelId", c => c.Int());
            DropForeignKey("dbo.Hotel", "PictureId", "dbo.Picture");
            DropForeignKey("dbo.RoomPictures", "Picture_Id", "dbo.Picture");
            DropForeignKey("dbo.RoomPictures", "Room_Id", "dbo.Room");
            DropIndex("dbo.RoomPictures", new[] { "Picture_Id" });
            DropIndex("dbo.RoomPictures", new[] { "Room_Id" });
            DropIndex("dbo.Hotel", new[] { "PictureId" });
            AlterColumn("dbo.Picture", "Content", c => c.Binary());
            AlterColumn("dbo.Picture", "Code", c => c.String());
            DropColumn("dbo.Hotel", "PictureId");
            DropTable("dbo.RoomPictures");
            CreateIndex("dbo.Picture", "RoomId");
            CreateIndex("dbo.Picture", "Id");
            AddForeignKey("dbo.Picture", "Id", "dbo.Hotel", "Id");
            AddForeignKey("dbo.Picture", "RoomId", "dbo.Room", "Id");
        }
    }
}
