namespace StalRondo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfilePicture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genealogy",
                c => new
                    {
                        HorseID = c.Int(nullable: false),
                        FatherID = c.Int(),
                        MotherID = c.Int(),
                    })
                .PrimaryKey(t => t.HorseID)
                .ForeignKey("dbo.Horse", t => t.FatherID)
                .ForeignKey("dbo.Horse", t => t.MotherID)
                .Index(t => t.FatherID)
                .Index(t => t.MotherID);
            
            CreateTable(
                "dbo.Horse",
                c => new
                    {
                        HorseID = c.Int(nullable: false),
                        ProfilePictureID = c.Guid(),
                        Name = c.String(),
                        Gender = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HorseID)
                .ForeignKey("dbo.Genealogy", t => t.HorseID)
                .Index(t => t.HorseID);
            
            CreateTable(
                "dbo.Picture",
                c => new
                    {
                        PictureID = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        HorseID = c.Int(nullable: false),
                        Description = c.String(),
                        Data = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => new { t.PictureID, t.HorseID })
                .ForeignKey("dbo.Horse", t => t.HorseID, cascadeDelete: true)
                .Index(t => t.HorseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genealogy", "MotherID", "dbo.Horse");
            DropForeignKey("dbo.Genealogy", "FatherID", "dbo.Horse");
            DropForeignKey("dbo.Picture", "HorseID", "dbo.Horse");
            DropForeignKey("dbo.Horse", "HorseID", "dbo.Genealogy");
            DropIndex("dbo.Picture", new[] { "HorseID" });
            DropIndex("dbo.Horse", new[] { "HorseID" });
            DropIndex("dbo.Genealogy", new[] { "MotherID" });
            DropIndex("dbo.Genealogy", new[] { "FatherID" });
            DropTable("dbo.Picture");
            DropTable("dbo.Horse");
            DropTable("dbo.Genealogy");
        }
    }
}
