namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogEntries", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogEntries", "Price");
        }
    }
}
