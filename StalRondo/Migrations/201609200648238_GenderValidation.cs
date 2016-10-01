namespace StalRondo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenderValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Horse", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Horse", "Gender", c => c.String());
        }
    }
}
