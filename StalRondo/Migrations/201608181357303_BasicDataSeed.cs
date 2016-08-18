namespace StalRondo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicDataSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genealogy",
                c => new
                    {
                        HorseID = c.Int(nullable: false, identity: true),
                        FatherID = c.Int(nullable: true),
                        MotherID = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.HorseID)
                .ForeignKey("dbo.Horse", t => t.HorseID)
                .ForeignKey("dbo.Horse", t => t.FatherID)
                .ForeignKey("dbo.Horse", t => t.MotherID)
                .Index(t => t.HorseID)
                .Index(t => t.FatherID)
                .Index(t => t.MotherID);
            
            CreateTable(
                "dbo.Horse",
                c => new
                    {
                        HorseID = c.Int(nullable: false),
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
                        PictureID = c.Int(nullable: false, identity: true),
                        HorseID = c.Int(nullable: false),
                        Description = c.String(),
                        Data = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.PictureID)
                .ForeignKey("dbo.Horse", t => t.HorseID, cascadeDelete: true)
                .Index(t => t.HorseID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genealogy", "MotherID", "dbo.Horse");
            DropForeignKey("dbo.Genealogy", "HorseID", "dbo.Horse");
            DropForeignKey("dbo.Genealogy", "FatherID", "dbo.Horse");
            DropForeignKey("dbo.Picture", "HorseID", "dbo.Horse");
            DropForeignKey("dbo.Horse", "HorseID", "dbo.Genealogy");
            DropIndex("dbo.Picture", new[] { "HorseID" });
            DropIndex("dbo.Horse", new[] { "HorseID" });
            DropIndex("dbo.Genealogy", new[] { "MotherID" });
            DropIndex("dbo.Genealogy", new[] { "FatherID" });
            DropIndex("dbo.Genealogy", new[] { "HorseID" });
            DropTable("dbo.Picture");
            DropTable("dbo.Horse");
            DropTable("dbo.Genealogy");
        }
    }
}
