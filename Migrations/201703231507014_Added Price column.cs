namespace AutoService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPricecolumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parts", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Parts", "Price");
        }
    }
}
