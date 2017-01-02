namespace StalRondo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserAndArticle : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Picture");
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        ArticleID = c.Guid(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        PictureID = c.Guid(),
                        Title = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => new { t.ArticleID, t.UserID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.Picture", t => t.PictureID)
                .Index(t => t.UserID)
                .Index(t => t.PictureID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserID = c.Guid(nullable: false, identity: true),
                        SurName = c.String(),
                        FirstName = c.String(),
                        Email = c.String(),
                        PasswordHash = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            AddPrimaryKey("dbo.Picture", "PictureID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Article", "PictureID", "dbo.Picture");
            DropForeignKey("dbo.Article", "UserID", "dbo.User");
            DropIndex("dbo.Article", new[] { "PictureID" });
            DropIndex("dbo.Article", new[] { "UserID" });
            DropPrimaryKey("dbo.Picture");
            DropTable("dbo.User");
            DropTable("dbo.Article");
            AddPrimaryKey("dbo.Picture", new[] { "PictureID", "HorseID" });
        }
    }
}
