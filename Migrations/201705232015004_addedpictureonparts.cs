namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpictureonparts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "Content");
        }
    }
}
