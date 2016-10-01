namespace StalRondo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HorseGeanologyRelationChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Horse", "HorseID", "dbo.Genealogy");
            DropIndex("dbo.Horse", new[] { "HorseID" });
            CreateIndex("dbo.Genealogy", "HorseID");
            AddForeignKey("dbo.Genealogy", "HorseID", "dbo.Horse", "HorseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Genealogy", "HorseID", "dbo.Horse");
            DropIndex("dbo.Genealogy", new[] { "HorseID" });
            CreateIndex("dbo.Horse", "HorseID");
            AddForeignKey("dbo.Horse", "HorseID", "dbo.Genealogy", "HorseID");
        }
    }
}
