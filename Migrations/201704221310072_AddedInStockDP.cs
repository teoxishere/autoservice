namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInStockDP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "InStock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "InStock");
        }
    }
}
